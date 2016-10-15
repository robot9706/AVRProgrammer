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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgForm));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDisc = new System.Windows.Forms.Button();
            this.btnCon = new System.Windows.Forms.Button();
            this.btnComRefresh = new System.Windows.Forms.Button();
            this.numBaud = new System.Windows.Forms.NumericUpDown();
            this.cbCom = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progGroup = new System.Windows.Forms.GroupBox();
            this.btnRefreshProgInfo = new System.Windows.Forms.Button();
            this.lblProgVer = new System.Windows.Forms.Label();
            this.lblProgName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnWires = new System.Windows.Forms.Button();
            this.btnCheckICompHex = new System.Windows.Forms.Button();
            this.groupFuses = new System.Windows.Forms.GroupBox();
            this.lblLockBits = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnFuseWrite = new System.Windows.Forms.Button();
            this.btnFuseRead = new System.Windows.Forms.Button();
            this.tbBitsExtended = new System.Windows.Forms.TextBox();
            this.tbBitsHigh = new System.Windows.Forms.TextBox();
            this.tbBitsLow = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupProg = new System.Windows.Forms.GroupBox();
            this.numSpiClockDiv = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSPILow = new System.Windows.Forms.CheckBox();
            this.cbPWM = new System.Windows.Forms.CheckBox();
            this.btnExitProgramming = new System.Windows.Forms.Button();
            this.btnEnterProgramming = new System.Windows.Forms.Button();
            this.groupSig = new System.Windows.Forms.GroupBox();
            this.btnReadSignature = new System.Windows.Forms.Button();
            this.lblSig = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupFlash = new System.Windows.Forms.GroupBox();
            this.btnFlash = new System.Windows.Forms.Button();
            this.btnBufLoad = new System.Windows.Forms.Button();
            this.lblProgBuf = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBaud = new System.Windows.Forms.GroupBox();
            this.btnBaudChange = new System.Windows.Forms.Button();
            this.cbPaged = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBaud)).BeginInit();
            this.progGroup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupFuses.SuspendLayout();
            this.groupProg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpiClockDiv)).BeginInit();
            this.groupSig.SuspendLayout();
            this.groupFlash.SuspendLayout();
            this.groupBaud.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(904, 424);
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
            this.groupBox1.Size = new System.Drawing.Size(335, 199);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Programmer - Serial port";
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
            // numBaud
            // 
            this.numBaud.Location = new System.Drawing.Point(76, 69);
            this.numBaud.Maximum = new decimal(new int[] {
            10000000,
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
            // cbCom
            // 
            this.cbCom.FormattingEnabled = true;
            this.cbCom.Location = new System.Drawing.Point(76, 31);
            this.cbCom.Name = "cbCom";
            this.cbCom.Size = new System.Drawing.Size(134, 26);
            this.cbCom.TabIndex = 2;
            this.cbCom.SelectedIndexChanged += new System.EventHandler(this.cbCom_SelectedIndexChanged);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "COM:";
            // 
            // progGroup
            // 
            this.progGroup.Controls.Add(this.btnRefreshProgInfo);
            this.progGroup.Controls.Add(this.lblProgVer);
            this.progGroup.Controls.Add(this.lblProgName);
            this.progGroup.Controls.Add(this.label5);
            this.progGroup.Controls.Add(this.label4);
            this.progGroup.Enabled = false;
            this.progGroup.Location = new System.Drawing.Point(353, 12);
            this.progGroup.Name = "progGroup";
            this.progGroup.Size = new System.Drawing.Size(335, 199);
            this.progGroup.TabIndex = 2;
            this.progGroup.TabStop = false;
            this.progGroup.Text = "Programmer - Info";
            // 
            // btnRefreshProgInfo
            // 
            this.btnRefreshProgInfo.Location = new System.Drawing.Point(17, 94);
            this.btnRefreshProgInfo.Name = "btnRefreshProgInfo";
            this.btnRefreshProgInfo.Size = new System.Drawing.Size(102, 27);
            this.btnRefreshProgInfo.TabIndex = 9;
            this.btnRefreshProgInfo.Text = "Refresh";
            this.btnRefreshProgInfo.UseVisualStyleBackColor = true;
            this.btnRefreshProgInfo.Click += new System.EventHandler(this.btnRefreshProgInfo_Click);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "Version:";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnWires);
            this.groupBox2.Controls.Add(this.btnCheckICompHex);
            this.groupBox2.Location = new System.Drawing.Point(12, 338);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 81);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Help";
            // 
            // btnWires
            // 
            this.btnWires.Location = new System.Drawing.Point(226, 32);
            this.btnWires.Name = "btnWires";
            this.btnWires.Size = new System.Drawing.Size(99, 32);
            this.btnWires.TabIndex = 3;
            this.btnWires.Text = "Show wiring";
            this.btnWires.UseVisualStyleBackColor = true;
            this.btnWires.Click += new System.EventHandler(this.btnWires_Click);
            // 
            // btnCheckICompHex
            // 
            this.btnCheckICompHex.Location = new System.Drawing.Point(11, 32);
            this.btnCheckICompHex.Name = "btnCheckICompHex";
            this.btnCheckICompHex.Size = new System.Drawing.Size(209, 32);
            this.btnCheckICompHex.TabIndex = 1;
            this.btnCheckICompHex.Text = "Check Intel hex compatibility";
            this.btnCheckICompHex.UseVisualStyleBackColor = true;
            this.btnCheckICompHex.Click += new System.EventHandler(this.btnCheckICompHex_Click);
            // 
            // groupFuses
            // 
            this.groupFuses.Controls.Add(this.lblLockBits);
            this.groupFuses.Controls.Add(this.label11);
            this.groupFuses.Controls.Add(this.btnFuseWrite);
            this.groupFuses.Controls.Add(this.btnFuseRead);
            this.groupFuses.Controls.Add(this.tbBitsExtended);
            this.groupFuses.Controls.Add(this.tbBitsHigh);
            this.groupFuses.Controls.Add(this.tbBitsLow);
            this.groupFuses.Controls.Add(this.label10);
            this.groupFuses.Controls.Add(this.label9);
            this.groupFuses.Controls.Add(this.label8);
            this.groupFuses.Enabled = false;
            this.groupFuses.Location = new System.Drawing.Point(353, 217);
            this.groupFuses.Name = "groupFuses";
            this.groupFuses.Size = new System.Drawing.Size(335, 202);
            this.groupFuses.TabIndex = 4;
            this.groupFuses.TabStop = false;
            this.groupFuses.Text = "Fuses";
            // 
            // lblLockBits
            // 
            this.lblLockBits.AutoSize = true;
            this.lblLockBits.Location = new System.Drawing.Point(134, 112);
            this.lblLockBits.Name = "lblLockBits";
            this.lblLockBits.Size = new System.Drawing.Size(13, 18);
            this.lblLockBits.TabIndex = 10;
            this.lblLockBits.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(45, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 18);
            this.label11.TabIndex = 9;
            this.label11.Text = "Lock bits: 0x";
            // 
            // btnFuseWrite
            // 
            this.btnFuseWrite.Location = new System.Drawing.Point(166, 152);
            this.btnFuseWrite.Name = "btnFuseWrite";
            this.btnFuseWrite.Size = new System.Drawing.Size(102, 27);
            this.btnFuseWrite.TabIndex = 8;
            this.btnFuseWrite.Text = "Write";
            this.btnFuseWrite.UseVisualStyleBackColor = true;
            this.btnFuseWrite.Click += new System.EventHandler(this.btnFuseWrite_Click);
            // 
            // btnFuseRead
            // 
            this.btnFuseRead.Location = new System.Drawing.Point(58, 152);
            this.btnFuseRead.Name = "btnFuseRead";
            this.btnFuseRead.Size = new System.Drawing.Size(102, 27);
            this.btnFuseRead.TabIndex = 7;
            this.btnFuseRead.Text = "Read";
            this.btnFuseRead.UseVisualStyleBackColor = true;
            this.btnFuseRead.Click += new System.EventHandler(this.btnFuseRead_Click);
            // 
            // tbBitsExtended
            // 
            this.tbBitsExtended.Location = new System.Drawing.Point(138, 81);
            this.tbBitsExtended.Name = "tbBitsExtended";
            this.tbBitsExtended.Size = new System.Drawing.Size(47, 24);
            this.tbBitsExtended.TabIndex = 5;
            // 
            // tbBitsHigh
            // 
            this.tbBitsHigh.Location = new System.Drawing.Point(138, 51);
            this.tbBitsHigh.Name = "tbBitsHigh";
            this.tbBitsHigh.Size = new System.Drawing.Size(47, 24);
            this.tbBitsHigh.TabIndex = 4;
            // 
            // tbBitsLow
            // 
            this.tbBitsLow.Location = new System.Drawing.Point(138, 21);
            this.tbBitsLow.Name = "tbBitsLow";
            this.tbBitsLow.Size = new System.Drawing.Size(47, 24);
            this.tbBitsLow.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 18);
            this.label10.TabIndex = 2;
            this.label10.Text = "Extended bits 0x:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 18);
            this.label9.TabIndex = 1;
            this.label9.Text = "Fuse bits high 0x:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "Fuse bits low 0x:";
            // 
            // groupProg
            // 
            this.groupProg.Controls.Add(this.numSpiClockDiv);
            this.groupProg.Controls.Add(this.label7);
            this.groupProg.Controls.Add(this.cbSPILow);
            this.groupProg.Controls.Add(this.cbPWM);
            this.groupProg.Controls.Add(this.btnExitProgramming);
            this.groupProg.Controls.Add(this.btnEnterProgramming);
            this.groupProg.Enabled = false;
            this.groupProg.Location = new System.Drawing.Point(694, 12);
            this.groupProg.Name = "groupProg";
            this.groupProg.Size = new System.Drawing.Size(340, 199);
            this.groupProg.TabIndex = 5;
            this.groupProg.TabStop = false;
            this.groupProg.Text = "Programmer - Tools";
            // 
            // numSpiClockDiv
            // 
            this.numSpiClockDiv.Location = new System.Drawing.Point(177, 82);
            this.numSpiClockDiv.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSpiClockDiv.Name = "numSpiClockDiv";
            this.numSpiClockDiv.Size = new System.Drawing.Size(120, 24);
            this.numSpiClockDiv.TabIndex = 15;
            this.numSpiClockDiv.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 18);
            this.label7.TabIndex = 14;
            this.label7.Text = "SPI clock divider:";
            // 
            // cbSPILow
            // 
            this.cbSPILow.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbSPILow.AutoSize = true;
            this.cbSPILow.Location = new System.Drawing.Point(63, 55);
            this.cbSPILow.Name = "cbSPILow";
            this.cbSPILow.Size = new System.Drawing.Size(150, 22);
            this.cbSPILow.TabIndex = 13;
            this.cbSPILow.Text = "Very low SPI clock";
            this.cbSPILow.UseVisualStyleBackColor = true;
            this.cbSPILow.CheckedChanged += new System.EventHandler(this.cbSPILow_CheckedChanged);
            // 
            // cbPWM
            // 
            this.cbPWM.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbPWM.AutoSize = true;
            this.cbPWM.Location = new System.Drawing.Point(63, 28);
            this.cbPWM.Name = "cbPWM";
            this.cbPWM.Size = new System.Drawing.Size(121, 22);
            this.cbPWM.TabIndex = 12;
            this.cbPWM.Text = "PWM on pin 9";
            this.cbPWM.UseVisualStyleBackColor = true;
            this.cbPWM.CheckedChanged += new System.EventHandler(this.cbPWM_CheckedChanged);
            // 
            // btnExitProgramming
            // 
            this.btnExitProgramming.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnExitProgramming.Enabled = false;
            this.btnExitProgramming.Location = new System.Drawing.Point(63, 154);
            this.btnExitProgramming.Name = "btnExitProgramming";
            this.btnExitProgramming.Size = new System.Drawing.Size(210, 32);
            this.btnExitProgramming.TabIndex = 11;
            this.btnExitProgramming.Text = "Exit programming mode";
            this.btnExitProgramming.UseVisualStyleBackColor = true;
            this.btnExitProgramming.EnabledChanged += new System.EventHandler(this.btnEnterProgramming_EnabledChanged);
            this.btnExitProgramming.Click += new System.EventHandler(this.btnExitProgramming_Click);
            // 
            // btnEnterProgramming
            // 
            this.btnEnterProgramming.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEnterProgramming.Location = new System.Drawing.Point(63, 116);
            this.btnEnterProgramming.Name = "btnEnterProgramming";
            this.btnEnterProgramming.Size = new System.Drawing.Size(210, 32);
            this.btnEnterProgramming.TabIndex = 10;
            this.btnEnterProgramming.Text = "Enter programming mode";
            this.btnEnterProgramming.UseVisualStyleBackColor = true;
            this.btnEnterProgramming.EnabledChanged += new System.EventHandler(this.btnEnterProgramming_EnabledChanged);
            this.btnEnterProgramming.Click += new System.EventHandler(this.btnEnterProgramming_Click);
            // 
            // groupSig
            // 
            this.groupSig.Controls.Add(this.btnReadSignature);
            this.groupSig.Controls.Add(this.lblSig);
            this.groupSig.Controls.Add(this.label12);
            this.groupSig.Enabled = false;
            this.groupSig.Location = new System.Drawing.Point(12, 217);
            this.groupSig.Name = "groupSig";
            this.groupSig.Size = new System.Drawing.Size(335, 115);
            this.groupSig.TabIndex = 6;
            this.groupSig.TabStop = false;
            this.groupSig.Text = "CPU Signature";
            // 
            // btnReadSignature
            // 
            this.btnReadSignature.Location = new System.Drawing.Point(20, 62);
            this.btnReadSignature.Name = "btnReadSignature";
            this.btnReadSignature.Size = new System.Drawing.Size(102, 27);
            this.btnReadSignature.TabIndex = 10;
            this.btnReadSignature.Text = "Read";
            this.btnReadSignature.UseVisualStyleBackColor = true;
            this.btnReadSignature.Click += new System.EventHandler(this.btnReadSignature_Click);
            // 
            // lblSig
            // 
            this.lblSig.AutoSize = true;
            this.lblSig.Location = new System.Drawing.Point(97, 24);
            this.lblSig.Name = "lblSig";
            this.lblSig.Size = new System.Drawing.Size(13, 18);
            this.lblSig.TabIndex = 1;
            this.lblSig.Text = "-";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 18);
            this.label12.TabIndex = 0;
            this.label12.Text = "Signature:";
            // 
            // groupFlash
            // 
            this.groupFlash.Controls.Add(this.cbPaged);
            this.groupFlash.Controls.Add(this.btnFlash);
            this.groupFlash.Controls.Add(this.btnBufLoad);
            this.groupFlash.Controls.Add(this.lblProgBuf);
            this.groupFlash.Controls.Add(this.label6);
            this.groupFlash.Location = new System.Drawing.Point(694, 217);
            this.groupFlash.Name = "groupFlash";
            this.groupFlash.Size = new System.Drawing.Size(339, 133);
            this.groupFlash.TabIndex = 7;
            this.groupFlash.TabStop = false;
            this.groupFlash.Text = "Flash program memory";
            // 
            // btnFlash
            // 
            this.btnFlash.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFlash.Enabled = false;
            this.btnFlash.Location = new System.Drawing.Point(121, 60);
            this.btnFlash.Name = "btnFlash";
            this.btnFlash.Size = new System.Drawing.Size(210, 32);
            this.btnFlash.TabIndex = 14;
            this.btnFlash.Text = "Write program memory";
            this.btnFlash.UseVisualStyleBackColor = true;
            this.btnFlash.Click += new System.EventHandler(this.btnFlash_Click);
            // 
            // btnBufLoad
            // 
            this.btnBufLoad.Location = new System.Drawing.Point(15, 60);
            this.btnBufLoad.Name = "btnBufLoad";
            this.btnBufLoad.Size = new System.Drawing.Size(102, 32);
            this.btnBufLoad.TabIndex = 11;
            this.btnBufLoad.Text = "Browse";
            this.btnBufLoad.UseVisualStyleBackColor = true;
            this.btnBufLoad.Click += new System.EventHandler(this.btnBufLoad_Click);
            // 
            // lblProgBuf
            // 
            this.lblProgBuf.AutoSize = true;
            this.lblProgBuf.Location = new System.Drawing.Point(71, 37);
            this.lblProgBuf.Name = "lblProgBuf";
            this.lblProgBuf.Size = new System.Drawing.Size(13, 18);
            this.lblProgBuf.TabIndex = 1;
            this.lblProgBuf.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "File:";
            // 
            // groupBaud
            // 
            this.groupBaud.Controls.Add(this.btnBaudChange);
            this.groupBaud.Enabled = false;
            this.groupBaud.Location = new System.Drawing.Point(694, 356);
            this.groupBaud.Name = "groupBaud";
            this.groupBaud.Size = new System.Drawing.Size(339, 63);
            this.groupBaud.TabIndex = 8;
            this.groupBaud.TabStop = false;
            this.groupBaud.Text = "Change baud";
            // 
            // btnBaudChange
            // 
            this.btnBaudChange.Location = new System.Drawing.Point(91, 23);
            this.btnBaudChange.Name = "btnBaudChange";
            this.btnBaudChange.Size = new System.Drawing.Size(169, 32);
            this.btnBaudChange.TabIndex = 15;
            this.btnBaudChange.Text = "Change to \"high speed\"";
            this.btnBaudChange.UseVisualStyleBackColor = true;
            this.btnBaudChange.Click += new System.EventHandler(this.btnBaudChange_Click);
            // 
            // cbPaged
            // 
            this.cbPaged.AutoSize = true;
            this.cbPaged.Location = new System.Drawing.Point(17, 97);
            this.cbPaged.Name = "cbPaged";
            this.cbPaged.Size = new System.Drawing.Size(104, 22);
            this.cbPaged.TabIndex = 15;
            this.cbPaged.Text = "Paged write";
            this.cbPaged.UseVisualStyleBackColor = true;
            // 
            // ProgForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1046, 451);
            this.Controls.Add(this.groupBaud);
            this.Controls.Add(this.groupFlash);
            this.Controls.Add(this.groupSig);
            this.Controls.Add(this.groupProg);
            this.Controls.Add(this.groupFuses);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.progGroup);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            this.groupFuses.ResumeLayout(false);
            this.groupFuses.PerformLayout();
            this.groupProg.ResumeLayout(false);
            this.groupProg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpiClockDiv)).EndInit();
            this.groupSig.ResumeLayout(false);
            this.groupSig.PerformLayout();
            this.groupFlash.ResumeLayout(false);
            this.groupFlash.PerformLayout();
            this.groupBaud.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnDisc;
        private System.Windows.Forms.Button btnCon;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCheckICompHex;
        private System.Windows.Forms.Button btnWires;
        private System.Windows.Forms.GroupBox groupFuses;
        private System.Windows.Forms.Button btnFuseWrite;
        private System.Windows.Forms.Button btnFuseRead;
        private System.Windows.Forms.TextBox tbBitsExtended;
        private System.Windows.Forms.TextBox tbBitsHigh;
        private System.Windows.Forms.TextBox tbBitsLow;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupProg;
        private System.Windows.Forms.Button btnExitProgramming;
        private System.Windows.Forms.Button btnEnterProgramming;
        private System.Windows.Forms.Label lblLockBits;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupSig;
        private System.Windows.Forms.Button btnReadSignature;
        private System.Windows.Forms.Label lblSig;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox cbSPILow;
        private System.Windows.Forms.CheckBox cbPWM;
        private System.Windows.Forms.GroupBox groupFlash;
        private System.Windows.Forms.Button btnBufLoad;
        private System.Windows.Forms.Label lblProgBuf;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnFlash;
        private System.Windows.Forms.NumericUpDown numSpiClockDiv;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBaud;
        private System.Windows.Forms.Button btnBaudChange;
        private System.Windows.Forms.CheckBox cbPaged;
    }
}

