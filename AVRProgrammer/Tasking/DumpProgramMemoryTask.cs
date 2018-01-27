using System;
using System.IO;

namespace AVRProgrammer.Tasking
{
	class DumpProgramMemoryTask : Task
	{
		private string _file;
		private ISP _isp;
		private int _size;

		public DumpProgramMemoryTask(string file, ISP isp, int dumpSize)
		{
			_file = file;
			_isp = isp;
			_size = dumpSize;
		}

		public void DoTask(ITaskReport report)
		{
			report.SetTitle("Dumping program");
			report.SetStatus("Preparing out file...");

			MemoryStream data = new MemoryStream();

			report.SetStatus("Reading memory...");
			report.SetMax((_size / 512) * 3);
			report.SetProgress(0);

			byte[] buffer = new byte[512];

			for (int prog = 0; prog < _size; prog += 512)
			{
				int progBar = (prog / 512) * 3;

				report.SetStatus("Reading memory (filling buffer)");
				report.SetProgress(progBar);

				if (!_isp.ReadProgramMemoryToBuffer(512 / 2, (uint)(prog / 2)))
					throw new Exception("Failed to fill programmer buffer!");

				report.SetStatus("Reading memory (transfering buffer)");
				report.SetProgress(progBar + 1);

				if (!_isp.ReadBuffer(buffer))
					throw new Exception("Failed to read programmer buffer!");

				data.Write(buffer, 0, buffer.Length);

				report.SetProgress(progBar + 2);
			}

			report.SetStatus("Writing file...");

			data.Position = 0;
			using(Stream outFile = File.OpenWrite(_file))
			{
				data.CopyTo(outFile);
			}

			data.Close();
		}
	}
}
