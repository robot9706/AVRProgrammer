using System;
using System.IO;

namespace AVRProgrammer.Tasking
{
	class DumpEEPROMTask : Task
	{
		private string _file;
		private ISP _isp;
		private int _bytes;

		public DumpEEPROMTask(string file, ISP isp, int bytes)
		{
			_file = file;
			_isp = isp;
			_bytes = bytes;
		}

		public void DoTask(ITaskReport report)
		{
			report.SetTitle("Reading EEPROM");
			report.SetStatus("Preparing...");

			MemoryStream data = new MemoryStream();

			report.SetStatus("Reading EEPROM...");
			report.SetMax((_bytes / 512) * 2);
			report.SetProgress(0);

			byte[] buffer = new byte[512];

			int byteOffset = 0;
			for (int offset = 0; offset < _bytes; offset += 512)
			{
				report.SetProgress((offset / 512) * 2);
				report.SetStatus("Reading EEPROM (filling buffer)");
				if (!_isp.ReadEEPROMToBuffer(512, (uint)offset))
					throw new Exception("Program memory write failed!");

				report.SetProgress((offset / 512) * 2 + 1);
				report.SetStatus("Reading EEPROM (transfering buffer)");
				if (!_isp.ReadBuffer(buffer))
					throw new Exception("Failed to fill programmer buffer!");		

				byteOffset += 512;

				data.Write(buffer, 0, buffer.Length);
			}

			report.SetStatus("Writing file...");

			data.Position = 0;
			using (Stream outFile = File.OpenWrite(_file))
			{
				data.CopyTo(outFile);
			}

			data.Close();
		}
	}
}
