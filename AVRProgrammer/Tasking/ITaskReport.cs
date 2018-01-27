namespace AVRProgrammer.Tasking
{
	public interface ITaskReport
	{
		void SetTitle(string title);
		void SetStatus(string status);

		void SetMax(int max);
		void SetProgress(int progress);
	}
}
