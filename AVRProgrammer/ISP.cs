using System;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace AVRProgrammer
{
	enum Command : byte
	{
		Poll = 1,
		Info = 2,
		Enter = 3,
		Exit = 4,
		ISPCommand = 5,
		FillBuffer = 6,
		BufferToProgramMemory = 7,
		ProgramMemoryToBuffer = 8,
		ReadBuffer = 9,
		BufferToEEPROM = 10,
		EEPROMToBuffer = 11
	}

	enum Fuse
	{
		Low,
		High,
		Extended,
		Lock
	}

	class ISP
	{
		private int _timeoutMax = 1000;

		private SerialPort _port;

		public ISP(string comName)
		{
			_port = new SerialPort(comName, 115200); //Using a virtual serial port (ATmega32u4), the baud shouldn't matter
			_port.Open();

			_port.DtrEnable = false; //Arduinos use DTR to reset

			Thread.Sleep(500);

			_port.DtrEnable = true;

			Thread.Sleep(1000);
		}

		public void Close()
		{
			_port.Close();
		}

		private void WriteCommand(Command cmd)
		{
			_port.Write(new byte[] { (byte)cmd }, 0, 1);
		}

		private byte ReadByte()
		{
			int i = _port.ReadByte();
			if (i < 0)
				throw new Exception("Communication error!");

			return (byte)i;
		}

		private void WriteByte(byte b)
		{
			_port.Write(new byte[] { b }, 0, 1);
		}

		private void WriteU16(ushort i)
		{
			WriteByte((byte)(i & 0x00FF));
			WriteByte((byte)((i & 0xFF00) >> 8));
		}

		private void WriteU32(uint i)
		{
			WriteByte((byte)(i & 0x000000FF));
			WriteByte((byte)((i & 0x0000FF00) >> 8));
			WriteByte((byte)((i & 0x00FF0000) >> 16));
			WriteByte((byte)((i & 0xFF000000) >> 24));
		}

		private bool WaitForBytes(int bytesIn)
		{
			DateTime time = DateTime.Now;

			while ((DateTime.Now - time).TotalMilliseconds < _timeoutMax && _port.BytesToRead < bytesIn)
			{ }

			return (_port.BytesToRead >= bytesIn); ;
		}

		private bool WaitForStatus()
		{
			if (!WaitForBytes(1))
				return false;

			return (ReadByte() > 0);
		}

		private bool WaitForBytesForever(int bytesIn)
		{
			while (_port.BytesToRead < bytesIn)
			{ }

			return (_port.BytesToRead >= bytesIn); ;
		}

		private bool WaitForStatusNoTimeout()
		{
			if (!WaitForBytesForever(1))
				return false;

			return (ReadByte() > 0);
		}



		public bool Poll()
		{
			WriteCommand(Command.Poll);

			return WaitForStatus();
		}

		public string GetInfo()
		{
			WriteCommand(Command.Info);

			if (!WaitForStatus())
				return null;

			byte strLen = ReadByte();
			byte[] strBuf = new byte[strLen];
			_port.Read(strBuf, 0, strBuf.Length);

			return Encoding.ASCII.GetString(strBuf);
		}

		public bool EnterISP()
		{
			WriteCommand(Command.Enter);

			if (!WaitForStatus())
				throw new Exception();

			return (ReadByte() == 0);
		}

		public bool ExitISP()
		{
			WriteCommand(Command.Exit);

			return WaitForStatus();
		}

		public byte ISPCommand(byte a, byte b, byte c, byte d)
		{
			WriteCommand(Command.ISPCommand);

			_port.Write(new byte[] { a, b, c, d }, 0, 4);

			if (!WaitForStatus())
				throw new Exception();

			return ReadByte();
		}

		public bool IsCPUReady()
		{
			byte val = ISPCommand(0xF0, 0x00, 0x00, 0x00);

			return (val == 254);
		}

		public byte[] ReadCPUSignature()
		{
			byte[] sig = new byte[3];

			sig[0] = ISPCommand(0x30, 0x00, 0x00, 0x00);
			sig[1] = ISPCommand(0x30, 0x00, 0x01, 0x00);
			sig[2] = ISPCommand(0x30, 0x00, 0x02, 0x00);

			return sig;
		}

		public byte ReadFuse(Fuse fuse)
		{
			switch (fuse)
			{
				case Fuse.Low:
					return ISPCommand(0x50, 0x00, 0x00, 0x00);
				case Fuse.High:
					return ISPCommand(0x58, 0x08, 0x00, 0x00);
				case Fuse.Extended:
					return ISPCommand(0x50, 0x08, 0x00, 0x00);
				case Fuse.Lock:
					return ISPCommand(0x58, 0x00, 0x00, 0x00);
			}

			return 0x0;
		}

		public bool WriteFuse(Fuse fuse, byte value)
		{
			switch (fuse)
			{
				case Fuse.Low:
					return (ISPCommand(0xAC, 0xA0, 0x00, value) == 0);
				case Fuse.High:
					return (ISPCommand(0xAC, 0xA8, 0x00, value) == 0);
				case Fuse.Extended:
					return (ISPCommand(0xAC, 0xA4, 0x00, value) == 0);
			}

			return false;
		}

		public bool ChipErase()
		{
			return (ISPCommand(0xAC, 0x80, 0x00, 0x00) == 0x0);
		}

		public bool FillBuffer(byte[] data, int length)
		{
			if (data.Length > 512)
				return false;

			WriteCommand(Command.FillBuffer);

			WriteU16((ushort)length);

			if (!WaitForStatus()) //Device cannot accept data
				return false;

			for (int x = 0; x < length; x++)
			{
				if (x >= data.Length)
					WriteByte(0);
				else
					WriteByte(data[x]);
			}

			return WaitForStatusNoTimeout(); //Might require some time to copy data
		}

		public bool ReadBuffer(byte[] target)
		{
			if (target.Length < 512)
				return false;

			WriteCommand(Command.ReadBuffer);

			if (!WaitForStatus())
				return false;

			for (int x = 0; x < 512; x++)
			{
				target[x] = ReadByte();
			}

			return WaitForStatus();
		}

		public bool WriteBufferToProgramMemory(ushort numInstructions, uint startOffset, bool verify)
		{
			WriteCommand(Command.BufferToProgramMemory);

			WriteU16(numInstructions);

			if (!WaitForStatus())
				return false; //Device cannot accept data

			WriteU32(startOffset);
			WriteByte((byte)(verify ? 0xFF : 0x00));

			return WaitForStatusNoTimeout(); //Might require some time to flash
		}

		public bool ReadProgramMemoryToBuffer(ushort numInstructions, uint startOffset)
		{
			WriteCommand(Command.ProgramMemoryToBuffer);

			WriteU16(numInstructions);

			if (!WaitForStatus())
				return false; //Command error

			WriteU32(startOffset);

			return WaitForStatusNoTimeout(); //Might require some time to flash
		}

		public bool WriteBufferToEEPROM(ushort bytes, uint offset, bool verify)
		{
			WriteCommand(Command.BufferToEEPROM);

			WriteU16(bytes);

			if (!WaitForStatus())
				return false; //Device cannot accept data

			WriteU32(offset);
			WriteByte((byte)(verify ? 0xFF : 0x00));

			return WaitForStatusNoTimeout(); //Might require some time to flash
		}

		public bool ReadEEPROMToBuffer(ushort bytes, uint startOffset)
		{
			WriteCommand(Command.EEPROMToBuffer);

			WriteU16(bytes);

			if (!WaitForStatus())
				return false; //Command error

			WriteU32(startOffset);

			return WaitForStatusNoTimeout(); //Might require some time to flash
		}
	}
}
