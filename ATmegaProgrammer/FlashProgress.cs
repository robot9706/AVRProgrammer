using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATmegaProgrammer
{
    public partial class FlashProgress : Form
    {
        private IntelHEX _hex;
        private Thread _flasher;
        private bool _doFlash = true;

        private bool _pagedWrite = true;

        public FlashProgress(IntelHEX hex, bool paged)
        {
            InitializeComponent();

            _pagedWrite = paged;
            _hex = hex;
        }

        private void SetTask(string task)
        {
            if (InvokeRequired)
                Invoke(new Action(() => SetTask(task)));
            else
                lblTask.Text = task;
        }

        private void SetMaxProgress(int max)
        {
            if (InvokeRequired)
                Invoke(new Action(() => SetMaxProgress(max)));
            else
            {
                prog.Value = 0;
                prog.Maximum = max;
            }
        }

        private void SetProgress(int value)
        {
            if (InvokeRequired)
                Invoke(new Action(() => SetProgress(value)));
            else
            {
                if (value > prog.Maximum)
                    value = prog.Maximum;
                prog.Value = value;

                lblProg.Text = ((int)Math.Floor(((float)prog.Value / (float)prog.Maximum) * 100.0f)).ToString() + "%";
            }
        }

        private void FlashProgress_Shown(object sender, EventArgs e)
        {
            _flasher = new Thread(DoFlash);
            _flasher.IsBackground = true;
            _flasher.Start();
        }

        private void FlashProgress_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_doFlash && !_flasher.IsAlive)
            {
                e.Cancel = true;
                MessageBox.Show(this, "Flashing in progress!", "Wait", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            _doFlash = false;
        }

        private void Error(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Info(string msg)
        {
            MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InvokeClose()
        {
            Invoke(new Action(() => Close()));
        }

        private void DoFlash()
        {
            SetTask("Preparing..");

            Thread.Sleep(100);

            while (!STK.IsReady())
                Thread.Sleep(500);

            SetTask("Erasing chip...");

            bool er = STK.ChipErase();

            while (!STK.IsReady())
                Thread.Sleep(500);

            if(!er)
            {
                SetTask("ERROR: Chip erase.");
                Error("Failed to erase chip!");

                InvokeClose();
            }
            else
            {
                if (!_doFlash)
                    return;

                SetTask("Collecting HEX data...");

                int allWords = 0;
                foreach (IntelHEX.Record rec in _hex.Records)
                {
                    if (rec.Type == IntelHEX.RecordType.Data)
                    {
                        allWords += rec.ByteCount / 2;
                    }
                }

                SetMaxProgress(allWords);
                SetProgress(0);

                DateTime startTime = DateTime.Now;

                SetTask("Flashing...");

                int writtenWords = 0;
                for (int ri = 0; ri < _hex.Records.Count; ri++) //Go through records and write the data into the proper locations
                {
                    if (!_doFlash)
                        return;

                    IntelHEX.Record rec = _hex.Records[ri];
                    if (rec.Type != IntelHEX.RecordType.Data)
                        continue;

                    if (_pagedWrite)
                    {
                        #region Paged

                        int words = rec.ByteCount / 2;

                        for (int x = 0; x < words; x++) //Write each word
                        {
                            if (!_doFlash)
                                return;

                            int adr = (rec.Address / 2) + x;

                            byte[] buffer = new byte[2];
                            buffer[0] = rec.Data[x * 2];
                            buffer[1] = rec.Data[(x * 2) + 1];

                            if (!STK.LoadProgramLowByte(adr, buffer[0]))
                            {
                                Error("An error ocurred while flashing at address: 0x" + adr.ToString());
                                InvokeClose();
                                return;
                            }

                            while (!STK.IsReady())
                                Thread.Yield();

                            if (!STK.LoadProgramHighByte(adr, buffer[1]))
                            {
                                Error("An error ocurred while flashing at address: 0x" + adr.ToString());
                                InvokeClose();
                                return;
                            }

                            while (!STK.IsReady())
                                Thread.Yield();
                        }

                        int pageAdr = (rec.Address / 2) & 0xFFFFE0;
                        if (!STK.WriteProgramMemoryPage(pageAdr))
                        {
                            Error("An error ocurred while flashing at address: 0x" + pageAdr.ToString());
                            InvokeClose();
                            return;
                        }

                        while (!STK.IsReady())
                            Thread.Yield();

                        writtenWords += words;
                        SetProgress(writtenWords);

                        #endregion
                    }
                    else
                    {
                        #region Non-paged
                        int pos = rec.Address / 2; //Address is in bytes, but we need word position (1 word is 2 bytes)
                        int words = rec.ByteCount / 2;

                        for (int x = 0; x < words; x++) //Write each word
                        {
                            if (!_doFlash)
                                return;

                            int adr = pos + x;

                            byte[] buffer = new byte[2];
                            buffer[0] = rec.Data[x * 2];
                            buffer[1] = rec.Data[(x * 2) + 1];

                            if (!STK.LoadProgramLowByte(adr, buffer[0]))
                            {
                                Error("An error ocurred while flashing at address: 0x" + adr.ToString());
                                InvokeClose();
                                return;
                            }

                            while (!STK.IsReady())
                                Thread.Yield();

                            if (!STK.LoadProgramHighByte(adr, buffer[1]))
                            {
                                Error("An error ocurred while flashing at address: 0x" + adr.ToString());
                                InvokeClose();
                                return;
                            }

                            while (!STK.IsReady())
                                Thread.Yield();

                            if (!STK.WriteProgramMemoryPage(adr))
                            {
                                Error("An error ocurred while flashing at address: 0x" + adr.ToString());
                                InvokeClose();
                                return;
                            }

                            while (!STK.IsReady())
                                Thread.Yield();

                            //Verify
                            byte lo;
                            byte hi;

                            lo = STK.ReadFlashLowByte(adr);
                            hi = STK.ReadFlashHighByte(adr);

                            if (lo != buffer[0] || hi != buffer[1])
                            {
                                Error("An error ocurred while verifying location: 0x" + adr.ToString("X2"));
                                InvokeClose();
                                return;
                            }

                            writtenWords++;
                            SetProgress(writtenWords);
                        }
                        #endregion
                    }
                }

                SetTask("Done!");
                Info("Done!\nElapsed time: " + (DateTime.Now - startTime).ToString());
            }

            InvokeClose();
        }
    }
}
