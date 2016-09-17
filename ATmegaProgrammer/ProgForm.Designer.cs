namespace ATmegaProgrammer
{
    partial class ProgForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCom = new System.Windows.Forms.ComboBox();
            this.numBaud = new System.Windows.Forms.NumericUpDown();
            this.btnComRefresh = new System.Windows.Forms.Button();
            this.progGroup = new System.Windows.Forms.GroupBox();
            this.btnResetProg = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblProgVer = new System.Windows.Forms.Label();
            this.lblProgName = new System.Windows.Forms.Label();
            this.btnRefreshProgInfo = new System.Windows.Forms.Button();
            this.btnCon = new System.Windows.Forms.Button();
            this.btnDisc = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCheckIHex = new System.Windows.Forms.Button();
            this.btnCheckICompHex = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnWires = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBaud)).BeginInit();
            this.progGroup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(859, 581);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "robot9706 @ 2016";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDisc);
            this.groupBox1.Controls.Add(this.btnCon);
            this.groupBox1.Controls.Add(this.btnComRefresh);
            this.groupBox1.Controls.Add(this.numBaud);
            this.groupBox1.Controls.Add(this.cbCom);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 146);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Programmer - Serial port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "COM:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Baud:";
            // 
            // cbCom
            // 
            this.cbCom.FormattingEnabled = true;
            this.cbCom.Location = new System.Drawing.Point(76, 31);
            this.cbCom.Name = "cbCom";
            this.cbCom.Size = new System.Drawing.Size(134, 26);
            this.cbCom.TabIndex = 2;
            this.cbCom.SelectedIndexChanged += new System.EventHandler(this.cbCom_SelectedIndexChanged);
            // 
            // numBaud
            // 
            this.numBaud.Location = new System.Drawing.Point(76, 69);
            this.numBaud.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numBaud.Name = "numBaud";
            this.numBaud.Size = new System.Drawing.Size(134, 24);
            this.numBaud.TabIndex = 3;
            this.numBaud.Value = new decimal(new int[] {
            19200,
            0,
            0,
            0});
            // 
            // btnComRefresh
            // 
            this.btnComRefresh.Location = new System.Drawing.Point(216, 31);
            this.btnComRefresh.Name = "btnComRefresh";
            this.btnComRefresh.Size = new System.Drawing.Size(75, 25);
            this.btnComRefresh.TabIndex = 4;
            this.btnComRefresh.Text = "Refresh";
            this.btnComRefresh.UseVisualStyleBackColor = true;
            this.btnComRefresh.Click += new System.EventHandler(this.btnComRefresh_Click);
            // 
            // progGroup
            // 
            this.progGroup.Controls.Add(this.btnRefreshProgInfo);
            this.progGroup.Controls.Add(this.lblProgVer);
            this.progGroup.Controls.Add(this.lblProgName);
            this.progGroup.Controls.Add(this.label5);
            this.progGroup.Controls.Add(this.label4);
            this.progGroup.Controls.Add(this.btnResetProg);
            this.progGroup.Enabled = false;
            this.progGroup.Location = new System.Drawing.Point(12, 164);
            this.progGroup.Name = "progGroup";
            this.progGroup.Size = new System.Drawing.Size(335, 142);
            this.progGroup.TabIndex = 2;
            this.progGroup.TabStop = false;
            this.progGroup.Text = "Programmer - Tools";
            // 
            // btnResetProg
            // 
            this.btnResetProg.Location = new System.Drawing.Point(25, 99);
            this.btnResetProg.Name = "btnResetProg";
            this.btnResetProg.Size = new System.Drawing.Size(103, 27);
            this.btnResetProg.TabIndex = 0;
            this.btnResetProg.Text = "Reset";
            this.btnResetProg.UseVisualStyleBackColor = true;
            this.btnResetProg.Click += new System.EventHandler(this.btnResetProg_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "Version:";
            // 
            // lblProgVer
            // 
            this.lblProgVer.AutoSize = true;
            this.lblProgVer.Location = new System.Drawing.Point(79, 60);
            this.lblProgVer.Name = "lblProgVer";
            this.lblProgVer.Size = new System.Drawing.Size(13, 18);
            this.lblProgVer.TabIndex = 8;
            this.lblProgVer.Text = "-";
            // 
            // lblProgName
            // 
            this.lblProgName.AutoSize = true;
            this.lblProgName.Location = new System.Drawing.Point(79, 32);
            this.lblProgName.Name = "lblProgName";
            this.lblProgName.Size = new System.Drawing.Size(13, 18);
            this.lblProgName.TabIndex = 7;
            this.lblProgName.Text = "-";
            // 
            // btnRefreshProgInfo
            // 
            this.btnRefreshProgInfo.Location = new System.Drawing.Point(134, 99);
            this.btnRefreshProgInfo.Name = "btnRefreshProgInfo";
            this.btnRefreshProgInfo.Size = new System.Drawing.Size(103, 27);
            this.btnRefreshProgInfo.TabIndex = 9;
            this.btnRefreshProgInfo.Text = "Refresh";
            this.btnRefreshProgInfo.UseVisualStyleBackColor = true;
            this.btnRefreshProgInfo.Click += new System.EventHandler(this.btnRefreshProgInfo_Click);
            // 
            // btnCon
            // 
            this.btnCon.Enabled = false;
            this.btnCon.Location = new System.Drawing.Point(43, 105);
            this.btnCon.Name = "btnCon";
            this.btnCon.Size = new System.Drawing.Size(102, 27);
            this.btnCon.TabIndex = 5;
            this.btnCon.Text = "Connect";
            this.btnCon.UseVisualStyleBackColor = true;
            this.btnCon.Click += new System.EventHandler(this.btnCon_Click);
            // 
            // btnDisc
            // 
            this.btnDisc.Enabled = false;
            this.btnDisc.Location = new System.Drawing.Point(151, 105);
            this.btnDisc.Name = "btnDisc";
            this.btnDisc.Size = new System.Drawing.Size(102, 27);
            this.btnDisc.TabIndex = 6;
            this.btnDisc.Text = "Disconnect";
            this.btnDisc.UseVisualStyleBackColor = true;
            this.btnDisc.Click += new System.EventHandler(this.btnDisc_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnWires);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnCheckICompHex);
            this.groupBox2.Controls.Add(this.btnCheckIHex);
            this.groupBox2.Location = new System.Drawing.Point(12, 435);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 161);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tools";
            // 
            // btnCheckIHex
            // 
            this.btnCheckIHex.Location = new System.Drawing.Point(19, 58);
            this.btnCheckIHex.Name = "btnCheckIHex";
            this.btnCheckIHex.Size = new System.Drawing.Size(99, 32);
            this.btnCheckIHex.TabIndex = 0;
            this.btnCheckIHex.Text = "Check file";
            this.btnCheckIHex.UseVisualStyleBackColor = true;
            this.btnCheckIHex.Click += new System.EventHandler(this.btnCheckIHex_Click);
            // 
            // btnCheckICompHex
            // 
            this.btnCheckICompHex.Location = new System.Drawing.Point(124, 58);
            this.btnCheckICompHex.Name = "btnCheckICompHex";
            this.btnCheckICompHex.Size = new System.Drawing.Size(153, 32);
            this.btnCheckICompHex.TabIndex = 1;
            this.btnCheckICompHex.Text = "Check compatibility";
            this.btnCheckICompHex.UseVisualStyleBackColor = true;
            this.btnCheckICompHex.Click += new System.EventHandler(this.btnCheckICompHex_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 18);
            this.label6.TabIndex = 2;
            this.label6.Text = "Intel HEX:";
            // 
            // btnWires
            // 
            this.btnWires.Location = new System.Drawing.Point(17, 123);
            this.btnWires.Name = "btnWires";
            this.btnWires.Size = new System.Drawing.Size(99, 32);
            this.btnWires.TabIndex = 3;
            this.btnWires.Text = "Show wiring";
            this.btnWires.UseVisualStyleBackColor = true;
            this.btnWires.Click += new System.EventHandler(this.btnWires_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 18);
            this.label7.TabIndex = 4;
            this.label7.Text = "Wiring:";
            // 
            // ProgForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1001, 608);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.progGroup);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "ProgForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ATmega programmer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProgForm_FormClosing);
            this.Load += new System.EventHandler(this.ProgForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBaud)).EndInit();
            this.progGroup.ResumeLayout(false);
            this.progGroup.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnComRefresh;
        private System.Windows.Forms.NumericUpDown numBaud;
        private System.Windows.Forms.ComboBox cbCom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox progGroup;
        private System.Windows.Forms.Button btnRefreshProgInfo;
        private System.Windows.Forms.Label lblProgVer;
        private System.Windows.Forms.Label lblProgName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnResetProg;
        private System.Windows.Forms.Button btnDisc;
        private System.Windows.Forms.Button btnCon;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCheckICompHex;
        private System.Windows.Forms.Button btnCheckIHex;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnWires;
    }
}

