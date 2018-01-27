using System;
using System.IO;

namespace AVRProgrammer.Tasking
{
	class FlashProgramMemoryTask : Task
	{
		private string _file;
		private ISP _isp;

		public FlashProgramMemoryTask(string file, ISP isp)
		{
			_file = file;
			_isp = isp;
		}

		public void DoTask(ITaskReport report)
		{
			report.SetTitle("Flashing program");
			report.SetStatus("Preparing hex...");

			IntelHEX hex = new IntelHEX();
			if (!hex.ParseFile(_file))
			{
				throw new Exception("Invalid intel hex!");
			}

			MemoryStream data = hex.GetRawData();

			report.SetStatus("Writing memory...");
			report.SetMax((int)data.Length);
			report.SetProgress(0);

			byte[] buffer = new byte[512];
			int read;

			int wordOffset = 0;
			while ((read = data.Read(buffer, 0, buffer.Length)) > 0)
			{
				report.SetStatus("Writing memory (filling buffer)");

				if (!_isp.FillBuffer(buffer, read))
					throw new Exception("Failed to fill programmer buffer!");

				report.SetStatus("Writing memory (flashing)");
				ushort ins = (ushort)(Math.Ceiling((float)read / 2.0f));
				if (!_isp.WriteBufferToProgramMemory(ins, (uint)wordOffset, true))
					throw new Exception("Program memory write failed!");

				wordOffset += ins;

				report.SetProgress(wordOffset * 2);
			}

			data.Close();
		}
	}
}
