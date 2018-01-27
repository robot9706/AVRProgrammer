using System;
using System.IO;

namespace AVRProgrammer.Tasking
{
	class FlashEEPROMTask : Task
	{
		private string _file;
		private ISP _isp;

		public FlashEEPROMTask(string file, ISP isp)
		{
			_file = file;
			_isp = isp;
		}

		public void DoTask(ITaskReport report)
		{
			report.SetTitle("Flashing EEPROM");
			report.SetStatus("Preparing data...");

			MemoryStream data = new MemoryStream();
			using (Stream inFile = File.OpenRead(_file))
			{
				inFile.CopyTo(data);
			}
			data.Position = 0;

			report.SetStatus("Writing EEPROM...");
			report.SetMax((int)(data.Length / 512) * 2);
			report.SetProgress(0);

			byte[] buffer = new byte[512];
			int read;

			int byteOffset = 0;
			while ((read = data.Read(buffer, 0, buffer.Length)) > 0)
			{
				report.SetProgress((byteOffset / 512));
				report.SetStatus("Writing EEPROM (filling buffer)");

				if (!_isp.FillBuffer(buffer, read))
					throw new Exception("Failed to fill programmer buffer!");

				report.SetProgress((byteOffset / 512) + 1);
				report.SetStatus("Writing EEPROM (flashing)");
				if (!_isp.WriteBufferToEEPROM((ushort)read, (uint)byteOffset, true))
					throw new Exception("Program memory write failed!");

				byteOffset += read;
			}

			data.Close();
		}
	}
}
