namespace ATmegaProgrammer
{
    partial class FlashProgress
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
            this.prog = new System.Windows.Forms.ProgressBar();
            this.lblTask = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblProg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // prog
            // 
            this.prog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prog.Location = new System.Drawing.Point(12, 59);
            this.prog.Name = "prog";
            this.prog.Size = new System.Drawing.Size(493, 23);
            this.prog.TabIndex = 0;
            // 
            // lblTask
            // 
            this.lblTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTask.Location = new System.Drawing.Point(12, 24);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(493, 18);
            this.lblTask.TabIndex = 2;
            this.lblTask.Text = "-";
            this.lblTask.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(202, 115);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 27);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblProg
            // 
            this.lblProg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProg.Location = new System.Drawing.Point(12, 85);
            this.lblProg.Name = "lblProg";
            this.lblProg.Size = new System.Drawing.Size(493, 18);
            this.lblProg.TabIndex = 5;
            this.lblProg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FlashProgress
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(522, 154);
            this.Controls.Add(this.lblProg);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTask);
            this.Controls.Add(this.prog);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FlashProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Flash progress";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FlashProgress_FormClosing);
            this.Shown += new System.EventHandler(this.FlashProgress_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar prog;
        private System.Windows.Forms.Label lblTask;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblProg;
    }
}