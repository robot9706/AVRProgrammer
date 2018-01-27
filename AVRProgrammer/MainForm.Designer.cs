namespace AVRProgrammer
{
	partial class MainForm
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
			this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
			this.btnDisconnect = new MetroFramework.Controls.MetroButton();
			this.btnConnect = new MetroFramework.Controls.MetroButton();
			this.cbProgCom = new MetroFramework.Controls.MetroComboBox();
			this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.lblProgInfo = new MetroFramework.Controls.MetroLabel();
			this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
			this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
			this.btnISPExit = new MetroFramework.Controls.MetroButton();
			this.btnISPEnter = new MetroFramework.Controls.MetroButton();
			this.lblCPUSig = new MetroFramework.Controls.MetroLabel();
			this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
			this.metroPanel4 = new MetroFramework.Controls.MetroPanel();
			this.btnFuseHelp = new MetroFramework.Controls.MetroButton();
			this.lblFuseLock = new MetroFramework.Controls.MetroLabel();
			this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
			this.tbFuseExt = new MetroFramework.Controls.MetroTextBox();
			this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
			this.tbFuseHigh = new MetroFramework.Controls.MetroTextBox();
			this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
			this.tbFuseLow = new MetroFramework.Controls.MetroTextBox();
			this.btnFuseWrite = new MetroFramework.Controls.MetroButton();
			this.btnFuseRead = new MetroFramework.Controls.MetroButton();
			this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
			this.metroPanel5 = new MetroFramework.Controls.MetroPanel();
			this.btnHexToBin = new MetroFramework.Controls.MetroButton();
			this.btnChipErase = new MetroFramework.Controls.MetroButton();
			this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
			this.metroPanel6 = new MetroFramework.Controls.MetroPanel();
			this.tbEEPROMSize = new MetroFramework.Controls.MetroTextBox();
			this.metroLabel15 = new MetroFramework.Controls.MetroLabel();
			this.btnReadEEPROM = new MetroFramework.Controls.MetroButton();
			this.btnWriteEEPROM = new MetroFramework.Controls.MetroButton();
			this.tbProgDumpSize = new MetroFramework.Controls.MetroTextBox();
			this.metroLabel14 = new MetroFramework.Controls.MetroLabel();
			this.btnReadProgram = new MetroFramework.Controls.MetroButton();
			this.btnWriteProgram = new MetroFramework.Controls.MetroButton();
			this.lblDev = new MetroFramework.Controls.MetroLabel();
			this.metroPanel1.SuspendLayout();
			this.metroPanel3.SuspendLayout();
			this.metroPanel4.SuspendLayout();
			this.metroPanel5.SuspendLayout();
			this.metroPanel6.SuspendLayout();
			this.SuspendLayout();
			// 
			// metroPanel1
			// 
			this.metroPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.metroPanel1.Controls.Add(this.lblProgInfo);
			this.metroPanel1.Controls.Add(this.btnDisconnect);
			this.metroPanel1.Controls.Add(this.metroLabel3);
			this.metroPanel1.Controls.Add(this.btnConnect);
			this.metroPanel1.Controls.Add(this.cbProgCom);
			this.metroPanel1.Controls.Add(this.metroLabel2);
			this.metroPanel1.HorizontalScrollbarBarColor = true;
			this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
			this.metroPanel1.HorizontalScrollbarSize = 10;
			this.metroPanel1.Location = new System.Drawing.Point(23, 75);
			this.metroPanel1.Name = "metroPanel1";
			this.metroPanel1.Size = new System.Drawing.Size(474, 100);
			this.metroPanel1.TabIndex = 0;
			this.metroPanel1.VerticalScrollbarBarColor = true;
			this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
			this.metroPanel1.VerticalScrollbarSize = 10;
			// 
			// btnDisconnect
			// 
			this.btnDisconnect.Enabled = false;
			this.btnDisconnect.Location = new System.Drawing.Point(341, 20);
			this.btnDisconnect.Name = "btnDisconnect";
			this.btnDisconnect.Size = new System.Drawing.Size(106, 29);
			this.btnDisconnect.TabIndex = 5;
			this.btnDisconnect.Text = "Disconnect";
			this.btnDisconnect.UseSelectable = true;
			this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
			// 
			// btnConnect
			// 
			this.btnConnect.Enabled = false;
			this.btnConnect.Location = new System.Drawing.Point(229, 20);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(106, 29);
			this.btnConnect.TabIndex = 4;
			this.btnConnect.Text = "Connect";
			this.btnConnect.UseSelectable = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// cbProgCom
			// 
			this.cbProgCom.FormattingEnabled = true;
			this.cbProgCom.ItemHeight = 23;
			this.cbProgCom.Location = new System.Drawing.Point(62, 20);
			this.cbProgCom.Name = "cbProgCom";
			this.cbProgCom.Size = new System.Drawing.Size(161, 29);
			this.cbProgCom.TabIndex = 3;
			this.cbProgCom.UseSelectable = true;
			this.cbProgCom.SelectedIndexChanged += new System.EventHandler(this.cbProgCom_SelectedIndexChanged);
			// 
			// metroLabel2
			// 
			this.metroLabel2.AutoSize = true;
			this.metroLabel2.Location = new System.Drawing.Point(19, 23);
			this.metroLabel2.Name = "metroLabel2";
			this.metroLabel2.Size = new System.Drawing.Size(37, 19);
			this.metroLabel2.TabIndex = 2;
			this.metroLabel2.Text = "Port:";
			// 
			// metroLabel1
			// 
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.Location = new System.Drawing.Point(27, 66);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(157, 19);
			this.metroLabel1.TabIndex = 1;
			this.metroLabel1.Text = "#1 - Programmer (COM)";
			// 
			// lblProgInfo
			// 
			this.lblProgInfo.AutoSize = true;
			this.lblProgInfo.Location = new System.Drawing.Point(106, 63);
			this.lblProgInfo.Name = "lblProgInfo";
			this.lblProgInfo.Size = new System.Drawing.Size(15, 19);
			this.lblProgInfo.TabIndex = 3;
			this.lblProgInfo.Text = "?";
			// 
			// metroLabel3
			// 
			this.metroLabel3.AutoSize = true;
			this.metroLabel3.Location = new System.Drawing.Point(19, 63);
			this.metroLabel3.Name = "metroLabel3";
			this.metroLabel3.Size = new System.Drawing.Size(90, 19);
			this.metroLabel3.TabIndex = 2;
			this.metroLabel3.Text = "Programmer:";
			// 
			// metroLabel5
			// 
			this.metroLabel5.AutoSize = true;
			this.metroLabel5.Location = new System.Drawing.Point(509, 66);
			this.metroLabel5.Name = "metroLabel5";
			this.metroLabel5.Size = new System.Drawing.Size(95, 19);
			this.metroLabel5.TabIndex = 9;
			this.metroLabel5.Text = "#2 - Processor";
			// 
			// metroPanel3
			// 
			this.metroPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.metroPanel3.Controls.Add(this.btnISPExit);
			this.metroPanel3.Controls.Add(this.btnISPEnter);
			this.metroPanel3.Controls.Add(this.lblCPUSig);
			this.metroPanel3.Controls.Add(this.metroLabel7);
			this.metroPanel3.HorizontalScrollbarBarColor = true;
			this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
			this.metroPanel3.HorizontalScrollbarSize = 10;
			this.metroPanel3.Location = new System.Drawing.Point(503, 75);
			this.metroPanel3.Name = "metroPanel3";
			this.metroPanel3.Size = new System.Drawing.Size(263, 100);
			this.metroPanel3.TabIndex = 8;
			this.metroPanel3.VerticalScrollbarBarColor = true;
			this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
			this.metroPanel3.VerticalScrollbarSize = 10;
			// 
			// btnISPExit
			// 
			this.btnISPExit.Enabled = false;
			this.btnISPExit.Location = new System.Drawing.Point(134, 53);
			this.btnISPExit.Name = "btnISPExit";
			this.btnISPExit.Size = new System.Drawing.Size(106, 29);
			this.btnISPExit.TabIndex = 7;
			this.btnISPExit.Text = "Exit ISP mode";
			this.btnISPExit.UseSelectable = true;
			this.btnISPExit.Click += new System.EventHandler(this.btnISPExit_Click);
			// 
			// btnISPEnter
			// 
			this.btnISPEnter.Enabled = false;
			this.btnISPEnter.Location = new System.Drawing.Point(22, 53);
			this.btnISPEnter.Name = "btnISPEnter";
			this.btnISPEnter.Size = new System.Drawing.Size(106, 29);
			this.btnISPEnter.TabIndex = 6;
			this.btnISPEnter.Text = "Enter ISP mode";
			this.btnISPEnter.UseSelectable = true;
			this.btnISPEnter.Click += new System.EventHandler(this.btnISPEnter_Click);
			// 
			// lblCPUSig
			// 
			this.lblCPUSig.AutoSize = true;
			this.lblCPUSig.Location = new System.Drawing.Point(86, 18);
			this.lblCPUSig.Name = "lblCPUSig";
			this.lblCPUSig.Size = new System.Drawing.Size(15, 19);
			this.lblCPUSig.TabIndex = 3;
			this.lblCPUSig.Text = "?";
			// 
			// metroLabel7
			// 
			this.metroLabel7.AutoSize = true;
			this.metroLabel7.Location = new System.Drawing.Point(22, 18);
			this.metroLabel7.Name = "metroLabel7";
			this.metroLabel7.Size = new System.Drawing.Size(67, 19);
			this.metroLabel7.TabIndex = 2;
			this.metroLabel7.Text = "Signature:";
			// 
			// metroLabel6
			// 
			this.metroLabel6.AutoSize = true;
			this.metroLabel6.Location = new System.Drawing.Point(28, 177);
			this.metroLabel6.Name = "metroLabel6";
			this.metroLabel6.Size = new System.Drawing.Size(69, 19);
			this.metroLabel6.TabIndex = 11;
			this.metroLabel6.Text = "#3 - Fuses";
			// 
			// metroPanel4
			// 
			this.metroPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.metroPanel4.Controls.Add(this.btnFuseHelp);
			this.metroPanel4.Controls.Add(this.lblFuseLock);
			this.metroPanel4.Controls.Add(this.metroLabel11);
			this.metroPanel4.Controls.Add(this.tbFuseExt);
			this.metroPanel4.Controls.Add(this.metroLabel10);
			this.metroPanel4.Controls.Add(this.tbFuseHigh);
			this.metroPanel4.Controls.Add(this.metroLabel8);
			this.metroPanel4.Controls.Add(this.tbFuseLow);
			this.metroPanel4.Controls.Add(this.btnFuseWrite);
			this.metroPanel4.Controls.Add(this.btnFuseRead);
			this.metroPanel4.Controls.Add(this.metroLabel9);
			this.metroPanel4.HorizontalScrollbarBarColor = true;
			this.metroPanel4.HorizontalScrollbarHighlightOnWheel = false;
			this.metroPanel4.HorizontalScrollbarSize = 10;
			this.metroPanel4.Location = new System.Drawing.Point(23, 188);
			this.metroPanel4.Name = "metroPanel4";
			this.metroPanel4.Size = new System.Drawing.Size(263, 194);
			this.metroPanel4.TabIndex = 10;
			this.metroPanel4.VerticalScrollbarBarColor = true;
			this.metroPanel4.VerticalScrollbarHighlightOnWheel = false;
			this.metroPanel4.VerticalScrollbarSize = 10;
			// 
			// btnFuseHelp
			// 
			this.btnFuseHelp.Enabled = false;
			this.btnFuseHelp.Location = new System.Drawing.Point(169, 21);
			this.btnFuseHelp.Name = "btnFuseHelp";
			this.btnFuseHelp.Size = new System.Drawing.Size(68, 29);
			this.btnFuseHelp.TabIndex = 15;
			this.btnFuseHelp.Text = "Help";
			this.btnFuseHelp.UseSelectable = true;
			this.btnFuseHelp.Click += new System.EventHandler(this.btnFuseHelp_Click);
			// 
			// lblFuseLock
			// 
			this.lblFuseLock.AutoSize = true;
			this.lblFuseLock.Location = new System.Drawing.Point(85, 108);
			this.lblFuseLock.Name = "lblFuseLock";
			this.lblFuseLock.Size = new System.Drawing.Size(15, 19);
			this.lblFuseLock.TabIndex = 14;
			this.lblFuseLock.Text = "?";
			// 
			// metroLabel11
			// 
			this.metroLabel11.AutoSize = true;
			this.metroLabel11.Location = new System.Drawing.Point(43, 108);
			this.metroLabel11.Name = "metroLabel11";
			this.metroLabel11.Size = new System.Drawing.Size(38, 19);
			this.metroLabel11.TabIndex = 13;
			this.metroLabel11.Text = "Lock:";
			// 
			// tbFuseExt
			// 
			// 
			// 
			// 
			this.tbFuseExt.CustomButton.Image = null;
			this.tbFuseExt.CustomButton.Location = new System.Drawing.Point(38, 1);
			this.tbFuseExt.CustomButton.Name = "";
			this.tbFuseExt.CustomButton.Size = new System.Drawing.Size(21, 21);
			this.tbFuseExt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.tbFuseExt.CustomButton.TabIndex = 1;
			this.tbFuseExt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.tbFuseExt.CustomButton.UseSelectable = true;
			this.tbFuseExt.CustomButton.Visible = false;
			this.tbFuseExt.Lines = new string[] {
        "0"};
			this.tbFuseExt.Location = new System.Drawing.Point(85, 79);
			this.tbFuseExt.MaxLength = 32767;
			this.tbFuseExt.Name = "tbFuseExt";
			this.tbFuseExt.PasswordChar = '\0';
			this.tbFuseExt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.tbFuseExt.SelectedText = "";
			this.tbFuseExt.SelectionLength = 0;
			this.tbFuseExt.SelectionStart = 0;
			this.tbFuseExt.ShortcutsEnabled = true;
			this.tbFuseExt.Size = new System.Drawing.Size(60, 23);
			this.tbFuseExt.TabIndex = 12;
			this.tbFuseExt.Text = "0";
			this.tbFuseExt.UseSelectable = true;
			this.tbFuseExt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.tbFuseExt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// metroLabel10
			// 
			this.metroLabel10.AutoSize = true;
			this.metroLabel10.Location = new System.Drawing.Point(42, 80);
			this.metroLabel10.Name = "metroLabel10";
			this.metroLabel10.Size = new System.Drawing.Size(46, 19);
			this.metroLabel10.TabIndex = 11;
			this.metroLabel10.Text = "Ext: 0x";
			// 
			// tbFuseHigh
			// 
			// 
			// 
			// 
			this.tbFuseHigh.CustomButton.Image = null;
			this.tbFuseHigh.CustomButton.Location = new System.Drawing.Point(38, 1);
			this.tbFuseHigh.CustomButton.Name = "";
			this.tbFuseHigh.CustomButton.Size = new System.Drawing.Size(21, 21);
			this.tbFuseHigh.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.tbFuseHigh.CustomButton.TabIndex = 1;
			this.tbFuseHigh.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.tbFuseHigh.CustomButton.UseSelectable = true;
			this.tbFuseHigh.CustomButton.Visible = false;
			this.tbFuseHigh.Lines = new string[] {
        "0"};
			this.tbFuseHigh.Location = new System.Drawing.Point(85, 50);
			this.tbFuseHigh.MaxLength = 32767;
			this.tbFuseHigh.Name = "tbFuseHigh";
			this.tbFuseHigh.PasswordChar = '\0';
			this.tbFuseHigh.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.tbFuseHigh.SelectedText = "";
			this.tbFuseHigh.SelectionLength = 0;
			this.tbFuseHigh.SelectionStart = 0;
			this.tbFuseHigh.ShortcutsEnabled = true;
			this.tbFuseHigh.Size = new System.Drawing.Size(60, 23);
			this.tbFuseHigh.TabIndex = 10;
			this.tbFuseHigh.Text = "0";
			this.tbFuseHigh.UseSelectable = true;
			this.tbFuseHigh.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.tbFuseHigh.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// metroLabel8
			// 
			this.metroLabel8.AutoSize = true;
			this.metroLabel8.Location = new System.Drawing.Point(32, 51);
			this.metroLabel8.Name = "metroLabel8";
			this.metroLabel8.Size = new System.Drawing.Size(56, 19);
			this.metroLabel8.TabIndex = 9;
			this.metroLabel8.Text = "High: 0x";
			// 
			// tbFuseLow
			// 
			// 
			// 
			// 
			this.tbFuseLow.CustomButton.Image = null;
			this.tbFuseLow.CustomButton.Location = new System.Drawing.Point(38, 1);
			this.tbFuseLow.CustomButton.Name = "";
			this.tbFuseLow.CustomButton.Size = new System.Drawing.Size(21, 21);
			this.tbFuseLow.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.tbFuseLow.CustomButton.TabIndex = 1;
			this.tbFuseLow.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.tbFuseLow.CustomButton.UseSelectable = true;
			this.tbFuseLow.CustomButton.Visible = false;
			this.tbFuseLow.Lines = new string[] {
        "0"};
			this.tbFuseLow.Location = new System.Drawing.Point(85, 21);
			this.tbFuseLow.MaxLength = 32767;
			this.tbFuseLow.Name = "tbFuseLow";
			this.tbFuseLow.PasswordChar = '\0';
			this.tbFuseLow.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.tbFuseLow.SelectedText = "";
			this.tbFuseLow.SelectionLength = 0;
			this.tbFuseLow.SelectionStart = 0;
			this.tbFuseLow.ShortcutsEnabled = true;
			this.tbFuseLow.Size = new System.Drawing.Size(60, 23);
			this.tbFuseLow.TabIndex = 8;
			this.tbFuseLow.Text = "0";
			this.tbFuseLow.UseSelectable = true;
			this.tbFuseLow.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.tbFuseLow.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// btnFuseWrite
			// 
			this.btnFuseWrite.Enabled = false;
			this.btnFuseWrite.Location = new System.Drawing.Point(131, 141);
			this.btnFuseWrite.Name = "btnFuseWrite";
			this.btnFuseWrite.Size = new System.Drawing.Size(106, 29);
			this.btnFuseWrite.TabIndex = 7;
			this.btnFuseWrite.Text = "Write";
			this.btnFuseWrite.UseSelectable = true;
			this.btnFuseWrite.Click += new System.EventHandler(this.btnFuseWrite_Click);
			// 
			// btnFuseRead
			// 
			this.btnFuseRead.Enabled = false;
			this.btnFuseRead.Location = new System.Drawing.Point(19, 141);
			this.btnFuseRead.Name = "btnFuseRead";
			this.btnFuseRead.Size = new System.Drawing.Size(106, 29);
			this.btnFuseRead.TabIndex = 6;
			this.btnFuseRead.Text = "Read";
			this.btnFuseRead.UseSelectable = true;
			this.btnFuseRead.Click += new System.EventHandler(this.btnFuseRead_Click);
			// 
			// metroLabel9
			// 
			this.metroLabel9.AutoSize = true;
			this.metroLabel9.Location = new System.Drawing.Point(36, 22);
			this.metroLabel9.Name = "metroLabel9";
			this.metroLabel9.Size = new System.Drawing.Size(52, 19);
			this.metroLabel9.TabIndex = 2;
			this.metroLabel9.Text = "Low: 0x";
			// 
			// metroLabel12
			// 
			this.metroLabel12.AutoSize = true;
			this.metroLabel12.Location = new System.Drawing.Point(297, 316);
			this.metroLabel12.Name = "metroLabel12";
			this.metroLabel12.Size = new System.Drawing.Size(38, 19);
			this.metroLabel12.TabIndex = 11;
			this.metroLabel12.Text = "Tools";
			// 
			// metroPanel5
			// 
			this.metroPanel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.metroPanel5.Controls.Add(this.btnHexToBin);
			this.metroPanel5.HorizontalScrollbarBarColor = true;
			this.metroPanel5.HorizontalScrollbarHighlightOnWheel = false;
			this.metroPanel5.HorizontalScrollbarSize = 10;
			this.metroPanel5.Location = new System.Drawing.Point(292, 326);
			this.metroPanel5.Name = "metroPanel5";
			this.metroPanel5.Size = new System.Drawing.Size(263, 56);
			this.metroPanel5.TabIndex = 10;
			this.metroPanel5.VerticalScrollbarBarColor = true;
			this.metroPanel5.VerticalScrollbarHighlightOnWheel = false;
			this.metroPanel5.VerticalScrollbarSize = 10;
			// 
			// btnHexToBin
			// 
			this.btnHexToBin.Location = new System.Drawing.Point(72, 13);
			this.btnHexToBin.Name = "btnHexToBin";
			this.btnHexToBin.Size = new System.Drawing.Size(106, 29);
			this.btnHexToBin.TabIndex = 17;
			this.btnHexToBin.Text = "Intel HEX to BIN";
			this.btnHexToBin.UseSelectable = true;
			this.btnHexToBin.Click += new System.EventHandler(this.btnHexToBin_Click);
			// 
			// btnChipErase
			// 
			this.btnChipErase.Enabled = false;
			this.btnChipErase.Location = new System.Drawing.Point(13, 40);
			this.btnChipErase.Name = "btnChipErase";
			this.btnChipErase.Size = new System.Drawing.Size(106, 29);
			this.btnChipErase.TabIndex = 16;
			this.btnChipErase.Text = "Chip erase";
			this.btnChipErase.UseSelectable = true;
			this.btnChipErase.Click += new System.EventHandler(this.btnChipErase_Click);
			// 
			// metroLabel13
			// 
			this.metroLabel13.AutoSize = true;
			this.metroLabel13.Location = new System.Drawing.Point(297, 178);
			this.metroLabel13.Name = "metroLabel13";
			this.metroLabel13.Size = new System.Drawing.Size(212, 19);
			this.metroLabel13.TabIndex = 11;
			this.metroLabel13.Text = "#4 - Program memory / EEPROM";
			// 
			// metroPanel6
			// 
			this.metroPanel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.metroPanel6.Controls.Add(this.tbEEPROMSize);
			this.metroPanel6.Controls.Add(this.metroLabel15);
			this.metroPanel6.Controls.Add(this.btnReadEEPROM);
			this.metroPanel6.Controls.Add(this.btnWriteEEPROM);
			this.metroPanel6.Controls.Add(this.tbProgDumpSize);
			this.metroPanel6.Controls.Add(this.metroLabel14);
			this.metroPanel6.Controls.Add(this.btnChipErase);
			this.metroPanel6.Controls.Add(this.btnReadProgram);
			this.metroPanel6.Controls.Add(this.btnWriteProgram);
			this.metroPanel6.HorizontalScrollbarBarColor = true;
			this.metroPanel6.HorizontalScrollbarHighlightOnWheel = false;
			this.metroPanel6.HorizontalScrollbarSize = 10;
			this.metroPanel6.Location = new System.Drawing.Point(292, 188);
			this.metroPanel6.Name = "metroPanel6";
			this.metroPanel6.Size = new System.Drawing.Size(474, 125);
			this.metroPanel6.TabIndex = 10;
			this.metroPanel6.VerticalScrollbarBarColor = true;
			this.metroPanel6.VerticalScrollbarHighlightOnWheel = false;
			this.metroPanel6.VerticalScrollbarSize = 10;
			// 
			// tbEEPROMSize
			// 
			// 
			// 
			// 
			this.tbEEPROMSize.CustomButton.Image = null;
			this.tbEEPROMSize.CustomButton.Location = new System.Drawing.Point(89, 1);
			this.tbEEPROMSize.CustomButton.Name = "";
			this.tbEEPROMSize.CustomButton.Size = new System.Drawing.Size(21, 21);
			this.tbEEPROMSize.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.tbEEPROMSize.CustomButton.TabIndex = 1;
			this.tbEEPROMSize.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.tbEEPROMSize.CustomButton.UseSelectable = true;
			this.tbEEPROMSize.CustomButton.Visible = false;
			this.tbEEPROMSize.Lines = new string[] {
        "512"};
			this.tbEEPROMSize.Location = new System.Drawing.Point(346, 90);
			this.tbEEPROMSize.MaxLength = 32767;
			this.tbEEPROMSize.Name = "tbEEPROMSize";
			this.tbEEPROMSize.PasswordChar = '\0';
			this.tbEEPROMSize.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.tbEEPROMSize.SelectedText = "";
			this.tbEEPROMSize.SelectionLength = 0;
			this.tbEEPROMSize.SelectionStart = 0;
			this.tbEEPROMSize.ShortcutsEnabled = true;
			this.tbEEPROMSize.Size = new System.Drawing.Size(111, 23);
			this.tbEEPROMSize.TabIndex = 20;
			this.tbEEPROMSize.Text = "512";
			this.tbEEPROMSize.UseSelectable = true;
			this.tbEEPROMSize.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.tbEEPROMSize.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// metroLabel15
			// 
			this.metroLabel15.AutoSize = true;
			this.metroLabel15.Location = new System.Drawing.Point(311, 91);
			this.metroLabel15.Name = "metroLabel15";
			this.metroLabel15.Size = new System.Drawing.Size(35, 19);
			this.metroLabel15.TabIndex = 19;
			this.metroLabel15.Text = "Size:";
			// 
			// btnReadEEPROM
			// 
			this.btnReadEEPROM.Enabled = false;
			this.btnReadEEPROM.Location = new System.Drawing.Point(308, 55);
			this.btnReadEEPROM.Name = "btnReadEEPROM";
			this.btnReadEEPROM.Size = new System.Drawing.Size(149, 29);
			this.btnReadEEPROM.TabIndex = 18;
			this.btnReadEEPROM.Text = "Dump EEPROM";
			this.btnReadEEPROM.UseSelectable = true;
			this.btnReadEEPROM.Click += new System.EventHandler(this.btnReadEEPROM_Click);
			// 
			// btnWriteEEPROM
			// 
			this.btnWriteEEPROM.Enabled = false;
			this.btnWriteEEPROM.Location = new System.Drawing.Point(308, 20);
			this.btnWriteEEPROM.Name = "btnWriteEEPROM";
			this.btnWriteEEPROM.Size = new System.Drawing.Size(149, 29);
			this.btnWriteEEPROM.TabIndex = 17;
			this.btnWriteEEPROM.Text = "Write EEPROM";
			this.btnWriteEEPROM.UseSelectable = true;
			this.btnWriteEEPROM.Click += new System.EventHandler(this.btnWriteEEPROM_Click);
			// 
			// tbProgDumpSize
			// 
			// 
			// 
			// 
			this.tbProgDumpSize.CustomButton.Image = null;
			this.tbProgDumpSize.CustomButton.Location = new System.Drawing.Point(89, 1);
			this.tbProgDumpSize.CustomButton.Name = "";
			this.tbProgDumpSize.CustomButton.Size = new System.Drawing.Size(21, 21);
			this.tbProgDumpSize.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.tbProgDumpSize.CustomButton.TabIndex = 1;
			this.tbProgDumpSize.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.tbProgDumpSize.CustomButton.UseSelectable = true;
			this.tbProgDumpSize.CustomButton.Visible = false;
			this.tbProgDumpSize.Lines = new string[] {
        "32768"};
			this.tbProgDumpSize.Location = new System.Drawing.Point(176, 90);
			this.tbProgDumpSize.MaxLength = 32767;
			this.tbProgDumpSize.Name = "tbProgDumpSize";
			this.tbProgDumpSize.PasswordChar = '\0';
			this.tbProgDumpSize.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.tbProgDumpSize.SelectedText = "";
			this.tbProgDumpSize.SelectionLength = 0;
			this.tbProgDumpSize.SelectionStart = 0;
			this.tbProgDumpSize.ShortcutsEnabled = true;
			this.tbProgDumpSize.Size = new System.Drawing.Size(111, 23);
			this.tbProgDumpSize.TabIndex = 16;
			this.tbProgDumpSize.Text = "32768";
			this.tbProgDumpSize.UseSelectable = true;
			this.tbProgDumpSize.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.tbProgDumpSize.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// metroLabel14
			// 
			this.metroLabel14.AutoSize = true;
			this.metroLabel14.Location = new System.Drawing.Point(141, 91);
			this.metroLabel14.Name = "metroLabel14";
			this.metroLabel14.Size = new System.Drawing.Size(35, 19);
			this.metroLabel14.TabIndex = 8;
			this.metroLabel14.Text = "Size:";
			// 
			// btnReadProgram
			// 
			this.btnReadProgram.Enabled = false;
			this.btnReadProgram.Location = new System.Drawing.Point(138, 55);
			this.btnReadProgram.Name = "btnReadProgram";
			this.btnReadProgram.Size = new System.Drawing.Size(149, 29);
			this.btnReadProgram.TabIndex = 7;
			this.btnReadProgram.Text = "Dump program memory";
			this.btnReadProgram.UseSelectable = true;
			this.btnReadProgram.Click += new System.EventHandler(this.btnReadProgram_Click);
			// 
			// btnWriteProgram
			// 
			this.btnWriteProgram.Enabled = false;
			this.btnWriteProgram.Location = new System.Drawing.Point(138, 20);
			this.btnWriteProgram.Name = "btnWriteProgram";
			this.btnWriteProgram.Size = new System.Drawing.Size(149, 29);
			this.btnWriteProgram.TabIndex = 6;
			this.btnWriteProgram.Text = "Write program memory";
			this.btnWriteProgram.UseSelectable = true;
			this.btnWriteProgram.Click += new System.EventHandler(this.btnWriteProgram_Click);
			// 
			// lblDev
			// 
			this.lblDev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDev.AutoSize = true;
			this.lblDev.ForeColor = System.Drawing.Color.Gainsboro;
			this.lblDev.Location = new System.Drawing.Point(650, 376);
			this.lblDev.Name = "lblDev";
			this.lblDev.Size = new System.Drawing.Size(120, 19);
			this.lblDev.TabIndex = 12;
			this.lblDev.Text = "Robot9706 @ 2018";
			// 
			// MainForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(784, 406);
			this.Controls.Add(this.lblDev);
			this.Controls.Add(this.metroLabel13);
			this.Controls.Add(this.metroLabel12);
			this.Controls.Add(this.metroPanel6);
			this.Controls.Add(this.metroLabel6);
			this.Controls.Add(this.metroPanel5);
			this.Controls.Add(this.metroLabel5);
			this.Controls.Add(this.metroPanel4);
			this.Controls.Add(this.metroPanel3);
			this.Controls.Add(this.metroLabel1);
			this.Controls.Add(this.metroPanel1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.Name = "MainForm";
			this.Text = "AVR Programmer";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.metroPanel1.ResumeLayout(false);
			this.metroPanel1.PerformLayout();
			this.metroPanel3.ResumeLayout(false);
			this.metroPanel3.PerformLayout();
			this.metroPanel4.ResumeLayout(false);
			this.metroPanel4.PerformLayout();
			this.metroPanel5.ResumeLayout(false);
			this.metroPanel6.ResumeLayout(false);
			this.metroPanel6.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MetroFramework.Controls.MetroPanel metroPanel1;
		private MetroFramework.Controls.MetroButton btnDisconnect;
		private MetroFramework.Controls.MetroButton btnConnect;
		private MetroFramework.Controls.MetroComboBox cbProgCom;
		private MetroFramework.Controls.MetroLabel metroLabel2;
		private MetroFramework.Controls.MetroLabel metroLabel1;
		private MetroFramework.Controls.MetroLabel metroLabel3;
		private MetroFramework.Controls.MetroLabel lblProgInfo;
		private MetroFramework.Controls.MetroLabel metroLabel5;
		private MetroFramework.Controls.MetroPanel metroPanel3;
		private MetroFramework.Controls.MetroButton btnISPExit;
		private MetroFramework.Controls.MetroButton btnISPEnter;
		private MetroFramework.Controls.MetroLabel lblCPUSig;
		private MetroFramework.Controls.MetroLabel metroLabel7;
		private MetroFramework.Controls.MetroLabel metroLabel6;
		private MetroFramework.Controls.MetroPanel metroPanel4;
		private MetroFramework.Controls.MetroTextBox tbFuseLow;
		private MetroFramework.Controls.MetroButton btnFuseWrite;
		private MetroFramework.Controls.MetroButton btnFuseRead;
		private MetroFramework.Controls.MetroLabel metroLabel9;
		private MetroFramework.Controls.MetroLabel lblFuseLock;
		private MetroFramework.Controls.MetroLabel metroLabel11;
		private MetroFramework.Controls.MetroTextBox tbFuseExt;
		private MetroFramework.Controls.MetroLabel metroLabel10;
		private MetroFramework.Controls.MetroTextBox tbFuseHigh;
		private MetroFramework.Controls.MetroLabel metroLabel8;
		private MetroFramework.Controls.MetroButton btnFuseHelp;
		private MetroFramework.Controls.MetroLabel metroLabel12;
		private MetroFramework.Controls.MetroPanel metroPanel5;
		private MetroFramework.Controls.MetroButton btnChipErase;
		private MetroFramework.Controls.MetroLabel metroLabel13;
		private MetroFramework.Controls.MetroPanel metroPanel6;
		private MetroFramework.Controls.MetroButton btnReadProgram;
		private MetroFramework.Controls.MetroButton btnWriteProgram;
		private MetroFramework.Controls.MetroButton btnHexToBin;
		private MetroFramework.Controls.MetroTextBox tbProgDumpSize;
		private MetroFramework.Controls.MetroLabel metroLabel14;
		private MetroFramework.Controls.MetroTextBox tbEEPROMSize;
		private MetroFramework.Controls.MetroLabel metroLabel15;
		private MetroFramework.Controls.MetroButton btnReadEEPROM;
		private MetroFramework.Controls.MetroButton btnWriteEEPROM;
		private MetroFramework.Controls.MetroLabel lblDev;
	}
}

