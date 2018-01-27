namespace AVRProgrammer
{
	partial class ProgressForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.progressBar = new MetroFramework.Controls.MetroProgressBar();
			this.lblStatus = new MetroFramework.Controls.MetroLabel();
			this.lblProgress = new MetroFramework.Controls.MetroLabel();
			this.btnCancel = new MetroFramework.Controls.MetroButton();
			this.SuspendLayout();
			// 
			// progressBar
			// 
			this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar.Location = new System.Drawing.Point(41, 96);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(422, 23);
			this.progressBar.TabIndex = 0;
			// 
			// lblStatus
			// 
			this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblStatus.Location = new System.Drawing.Point(41, 70);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(422, 23);
			this.lblStatus.TabIndex = 1;
			this.lblStatus.Text = "?";
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblProgress
			// 
			this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblProgress.Location = new System.Drawing.Point(469, 96);
			this.lblProgress.Name = "lblProgress";
			this.lblProgress.Size = new System.Drawing.Size(56, 23);
			this.lblProgress.TabIndex = 2;
			this.lblProgress.Text = "0%";
			this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnCancel.Location = new System.Drawing.Point(205, 144);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(94, 35);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseSelectable = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// ProgressForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(522, 207);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.lblProgress);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.progressBar);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProgressForm";
			this.Text = "-";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProgressForm_FormClosing);
			this.Load += new System.EventHandler(this.ProgressForm_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private MetroFramework.Controls.MetroProgressBar progressBar;
		private MetroFramework.Controls.MetroLabel lblStatus;
		private MetroFramework.Controls.MetroLabel lblProgress;
		private MetroFramework.Controls.MetroButton btnCancel;
	}
}