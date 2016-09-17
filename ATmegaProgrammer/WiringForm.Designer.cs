namespace ATmegaProgrammer
{
    partial class WiringForm
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
            this.fitPictureBox = new ATmegaProgrammer.FitPictureBox();
            this.SuspendLayout();
            // 
            // fitPictureBox
            // 
            this.fitPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fitPictureBox.Image = global::ATmegaProgrammer.Properties.Resources.Breadboard;
            this.fitPictureBox.Location = new System.Drawing.Point(0, 0);
            this.fitPictureBox.Name = "fitPictureBox";
            this.fitPictureBox.SimpleBorder = false;
            this.fitPictureBox.Size = new System.Drawing.Size(627, 415);
            this.fitPictureBox.TabIndex = 0;
            this.fitPictureBox.Text = "fitPictureBox1";
            // 
            // WiringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 415);
            this.Controls.Add(this.fitPictureBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "WiringForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wiring for ATmega328P-PU";
            this.Resize += new System.EventHandler(this.WiringForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private FitPictureBox fitPictureBox;
    }
}