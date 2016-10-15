using System;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ATmegaProgrammer
{
    public partial class ProgForm : Form
    {
        //Vars
        private SerialPort _port;
        private string _programBufferFile;

        private string _argHexFile;
        private string _argCom;
        private int _argBaud;

        //UI
        public ProgForm(string[] args)
        {
            InitializeComponent();
        }

        private void ProgForm_Load(object sender, EventArgs e)
        {
            btnComRefresh_Click(sender, e);
        }

        private void btnComRefresh_Click(object sender, EventArgs e)
        {
            string save = "";
            if (cbCom.SelectedIndex > -1)
                save = (string)cbCom.Items[cbCom.SelectedIndex];

            cbCom.Items.Clear();
            cbCom.Items.AddRange(SerialPort.GetPortNames());

            for (int x = 0; x < cbCom.Items.Count; x++)
            {
                if((string)cbCom.Items[x] == save)
                {
                    cbCom.SelectedIndex = x;
                    break;
                }
            }

            if (cbCom.SelectedIndex < 0 && cbCom.Items.Count > 0)
                cbCom.SelectedIndex = 0;
        }

        private void Error(string msg)
        {
            MessageBox.Show(this, msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Info(string msg)
        {
            MessageBox.Show(this, msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCon_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                if (_port != null)
                {
                    _port.Close();
                }

                _port = new SerialPort((string)cbCom.Items[cbCom.SelectedIndex], (int)numBaud.Value);
                _port.Open();
                _port.DtrEnable = true;

                STK.Init(_port);

                if (!STK.Poll())
                {
                    throw new Exception("Failed to poll programmer!");
                }
                else
                {
                    //Request programmer data
                    btnRefreshProgInfo_Click(sender, e);
                }

                //Enable stuff
                btnDisc.Enabled = progGroup.Enabled = groupProg.Enabled = groupBaud.Enabled = true;
                btnEnterProgramming.Enabled = true;
                btnExitProgramming.Enabled = false;

                //Disable connect button
                btnCon.Enabled = false;

                Cursor = Cursors.Default;
            }
            catch(Exception ex)
            {
                Cursor = Cursors.Default;
                if (_port != null)
                {
                    _port.Close();
                }

                btnDisc.Enabled = false;
                cbCom_SelectedIndexChanged(sender, e);

                Error("Error while opening COM port: " + ex.Message);
            }
        }

        private void btnDisc_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                if (_port != null)
                {
                    if(btnExitProgramming.Enabled) //We are in programming mode -> exit it
                    {
                        STK.EndProgramming(); //Don't care if it's ok or not
                    }

                    _port.Close();
                }

                //Disable stuff
                btnDisc.Enabled = progGroup.Enabled = groupProg.Enabled = groupBaud.Enabled = false;
                btnEnterProgramming.Enabled = true;
                btnExitProgramming.Enabled = false;

                //Check connect button
                cbCom_SelectedIndexChanged(sender, e);

                //Reset programmer data
                lblProgName.Text = lblProgVer.Text = "-";

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                Error("Error while closing COM port: " + ex.Message);
            }
        }

        private void cbCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCon.Enabled = (cbCom.SelectedIndex > -1);
        }

        private void ProgForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnDisc_Click(sender, e);
        }

        private void btnRefreshProgInfo_Click(object sender, EventArgs e)
        {
            lblProgName.Text = STK.GetISPName();
            lblProgVer.Text = STK.GetISPVersion();
        }

        private void btnCheckIHex_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "Intel hex (*.hex)|*.hex|All files (*.*)|*.*";
                if(opf.ShowDialog(this) == DialogResult.OK)
                {
                    IntelHEX hex = new IntelHEX();
                    if(hex.ParseFile(opf.FileName))
                    {
                        int dt = 0;
                        foreach (IntelHEX.Record r in hex.Records)
                            if (r.Type == IntelHEX.RecordType.Data)
                                dt++;

                        Info("The file seems valid.\nRecords: " + hex.Records.Count.ToString() + "\nData records: " + dt.ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                Error("Failed to check file: " + ex.Message);
            }
        }

        private void btnCheckICompHex_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "Intel hex (*.hex)|*.hex|All files (*.*)|*.*";
                if (opf.ShowDialog(this) == DialogResult.OK)
                {
                    IntelHEX hex = new IntelHEX();
                    if (hex.ParseFile(opf.FileName))
                    {
                        bool ok = true;
                        int dt = 0;
                        foreach (IntelHEX.Record r in hex.Records)
                        {
                            if (r.Type == IntelHEX.RecordType.Data)
                                dt++;
                            if (r.Type == IntelHEX.RecordType.ExtendedAddressBase || r.Type == IntelHEX.RecordType.ExtendedLinearAddress || r.Type == IntelHEX.RecordType.LinearAddressBase)
                                ok = false;
                        }

                        Info("The file seems valid.\nRecords: " + hex.Records.Count.ToString() + "\nData records: " + dt.ToString() + "\nContains extended records: " + (ok ? "No" : "Yes") + "-> " + (ok ? "Compatible" : "Not compatible") + " with ATmega328P chips.");
                    }
                }
            }
            catch (Exception ex)
            {
                Error("Failed to check file: " + ex.Message);
            }
        }

        private void btnWires_Click(object sender, EventArgs e)
        {
            using (WiringForm wf = new WiringForm())
                wf.ShowDialog(this);
        }

        private void btnEnterProgramming_Click(object sender, EventArgs e)
        {
            _port.Write(cbSPILow.Checked ? "r" : "t");

            //if (!cbSPILow.Checked && (int)numSpiClockDiv.Value != 32)
            //{
            //    int spiClock = (1000000 / (int)numSpiClockDiv.Value);

            //    byte a = (byte)(spiClock / 65536);
            //    byte b = (byte)(spiClock / 256);
            //    byte c = (byte)(spiClock % 256);

            //    _port.Write(new byte[] { (byte)'s', a, b, c }, 0, 4);
            //    string rd = _port.ReadLine();
            //}

            if (STK.EnterProgramming())
            {
                btnEnterProgramming.Enabled = false;
                btnExitProgramming.Enabled = true;
                cbSPILow.Enabled = false;

                btnReadSignature_Click(sender, e);
                btnFuseRead_Click(sender, e);
            }
            else
            {
                Error("Failed to enter programming mode!");
            }
        }

        private void btnExitProgramming_Click(object sender, EventArgs e)
        {
            if (STK.EndProgramming())
            {
                btnEnterProgramming.Enabled = true;
                btnExitProgramming.Enabled = false;
                cbSPILow.Enabled = true;
            }
            else
            {
                Error("Failed to exit programming mode!");
            }
        }

        private void btnEnterProgramming_EnabledChanged(object sender, EventArgs e)
        {
            groupFuses.Enabled = groupSig.Enabled = groupFlash.Enabled = btnExitProgramming.Enabled;
        }

        private void btnFuseRead_Click(object sender, EventArgs e)
        {
            tbBitsLow.Text = tbBitsHigh.Text = tbBitsExtended.Text = lblLockBits.Text = "...";
            Refresh();

            tbBitsLow.Text = STK.ReadFuseBitsLow().ToString("X2");
            tbBitsHigh.Text = STK.ReadFuseBitsHigh().ToString("X2");
            tbBitsExtended.Text = STK.ReadExtendedFuseBits().ToString("X2");
            lblLockBits.Text = STK.ReadLockBits().ToString("X2");
        }

        private void btnFuseWrite_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(this, "Are you sure want to write fuses (fuse bits low/high and extended fuse bits)?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    byte low = Convert.ToByte(tbBitsLow.Text, 16);
                    byte high = Convert.ToByte(tbBitsHigh.Text, 16);
                    byte ext = Convert.ToByte(tbBitsExtended.Text, 16);

                    while (!STK.IsReady())
                        Thread.Sleep(100);
                    bool lowOk = STK.WriteFuseLowBits(low);

                    while (!STK.IsReady())
                        Thread.Sleep(100);
                    bool highOk = STK.WriteFuseHighBits(high);

                    while (!STK.IsReady())
                        Thread.Sleep(100);
                    bool extOk = STK.WriteExtendedFuseBits(ext);

                    while (!STK.IsReady())
                        Thread.Sleep(100);

                    btnFuseRead_Click(sender, e);

                    byte nLow = STK.ReadFuseBitsLow();
                    byte nHigh = STK.ReadFuseBitsHigh();
                    byte nExt = STK.ReadExtendedFuseBits();

                    lowOk = (lowOk && low == nLow);
                    highOk = (highOk && high == nHigh);
                    extOk = (extOk && ext == nExt);

                    Info("Fuse report:\nLow: " + (lowOk ? "OK" : "Failed") + "\nHigh: " + (highOk ? "OK" : "Failed") + "\nExt: " + (extOk ? "OK" : "Failed"));
                }
                catch(Exception ex)
                {
                    Cursor = Cursors.Default;
                    Error("An error ocurred: " + ex.Message);
                }
                Cursor = Cursors.Default;
            }
        }

        private void btnReadSignature_Click(object sender, EventArgs e)
        {
            lblSig.Text = "...";
            this.Refresh();
            byte[] sig = STK.ReadSignature();
            lblSig.Text = "0x" + sig[0].ToString("X2") + sig[1].ToString("X2") + sig[2].ToString("X2");
        }

        private void cbPWM_CheckedChanged(object sender, EventArgs e)
        {
            if (_port != null)
            {
                _port.Write(cbPWM.Checked ? "q" : "w");
            }
        }

        private void btnBufLoad_Click(object sender, EventArgs e)
        {
            lblProgBuf.Text = "-";
            btnFlash.Enabled = false;

            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "Intel hex (*.hex)|*.hex|All files (*.*)|*.*";
                if (opf.ShowDialog(this) == DialogResult.OK)
                {
                    IntelHEX hex = new IntelHEX();
                    if (hex.ParseFile(opf.FileName))
                    {
                        lblProgBuf.Text = Path.GetFileName(opf.FileName);

                        _programBufferFile = opf.FileName;
                        btnFlash.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Error("Failed to load hex: " + ex.Message);
            }
        }

        private void btnFlash_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure want to flash the program memory?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                IntelHEX hex = new IntelHEX();
                if (hex.ParseFile(_programBufferFile))
                {
                    using (FlashProgress prog = new FlashProgress(hex, cbPaged.Checked))
                        prog.ShowDialog(this);
                }
                else
                {
                    Error("Invalid file!");
                }
            }
        }

        private void cbSPILow_CheckedChanged(object sender, EventArgs e)
        {
            numSpiClockDiv.Enabled = !cbSPILow.Checked;
        }

        private void btnBaudChange_Click(object sender, EventArgs e)
        {
            _port.Write(new byte[] { (byte)'S' }, 0, 1);
            _port.BaseStream.Flush();

            while (_port.BytesToWrite > 0)
                Thread.Sleep(100);

            btnDisc_Click(sender, e);

            Thread.Sleep(1500);

            numBaud.Value = 115200;

            //Thread.Sleep(1500);
            //btnCon_Click(sender, e);
        }
    }
}
