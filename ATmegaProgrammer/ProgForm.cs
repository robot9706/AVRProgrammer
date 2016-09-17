using System;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace ATmegaProgrammer
{
    public partial class ProgForm : Form
    {
        //Vars
        private SerialPort _port;

        //UI
        public ProgForm()
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
                btnDisc.Enabled = progGroup.Enabled = true;

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
                    _port.Close();
                }

                //Disable stuff
                btnDisc.Enabled = progGroup.Enabled = false;

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

        private void btnResetProg_Click(object sender, EventArgs e)
        {
            if(_port != null)
            {
                Cursor = Cursors.WaitCursor;

                _port.DtrEnable = false;
                Thread.Sleep(1000);
                _port.DtrEnable = true;

                Cursor = Cursors.Default;
            }
        }

        private void btnCheckIHex_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "Intel hex (*.hex)|*.hex|All files (*.*)|*.*";
                if(opf.ShowDialog(this) == DialogResult.OK)
                {

                }
            }
            catch(Exception ex)
            {
                Error("Failed to check file: " + ex.Message);
            }
        }

        private void btnCheckICompHex_Click(object sender, EventArgs e)
        {

        }

        private void btnWires_Click(object sender, EventArgs e)
        {

        }
    }
}
