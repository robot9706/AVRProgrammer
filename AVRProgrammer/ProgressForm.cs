using AVRProgrammer.Tasking;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Threading;
using System.Windows.Forms;

namespace AVRProgrammer
{
	public partial class ProgressForm : MetroForm, ITaskReport
	{
		private Task _task;

		private Thread _thread;
		private bool _done = false;

		public ProgressForm(Task task)
		{
			InitializeComponent();

			_task = task;
		}

		public void SetMax(int max)
		{
			if (InvokeRequired)
				Invoke(new Action(() => SetMax(max)));
			else
			{
				if (progressBar.Value > max)
					progressBar.Value = max;

				progressBar.Maximum = max;
			}
		}

		public void SetProgress(int progress)
		{
			if (InvokeRequired)
				Invoke(new Action(() => SetProgress(progress)));
			else
			{
				if (progress < 0) progress = 0;
				if (progress > progressBar.Maximum) progress = progressBar.Maximum;

				progressBar.Value = progress;

				lblProgress.Text = ((int)Math.Round(((float)progressBar.Value / progressBar.Maximum) * 100.0f)).ToString() + "%";
			}
		}

		public void SetStatus(string status)
		{
			if (InvokeRequired)
				Invoke(new Action(() => SetStatus(status)));
			else
				lblStatus.Text = status;
		}

		public void SetTitle(string title)
		{
			if (InvokeRequired)
				Invoke(new Action(() => SetTitle(title)));
			else
				Text = title;
		}

		private void Thread_TaskRunner()
		{
			try
			{
				_task.DoTask(this);

				_done = true;
				Invoke(new Action(() =>
				{
					MetroMessageBox.Show(this, "Task finished!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

					DialogResult = DialogResult.OK;
					Close();
				}));

				return;
			}
			catch (ThreadAbortException) { }
			catch (Exception ex)
			{
				_done = true;

				Invoke(new Action(() =>
				{
					MetroMessageBox.Show(this, "An error ocurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

					DialogResult = DialogResult.Abort;
					Close();
				}));

				return;
			}

			_done = true;
			Invoke(new Action(() =>
			{
				DialogResult = DialogResult.Cancel;
				Close();
			}));
		}

		private void ProgressForm_Load(object sender, EventArgs e)
		{
			_thread = new Thread(Thread_TaskRunner);
			_thread.IsBackground = true;
			_thread.Start();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			_thread.Abort();
			_done = true;

			Close();
		}

		private void ProgressForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (_done)
				return;

			e.Cancel = true;
			btnCancel_Click(sender, e);
		}
	}
}
