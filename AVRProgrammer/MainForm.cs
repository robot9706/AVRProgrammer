using AVRProgrammer.Tasking;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AVRProgrammer
{
	public partial class MainForm : MetroForm
	{
		private const string _fuseLink = "http://eleccelerator.com/fusecalc/fusecalc.php?chip={0}&LOW={1}&HIGH={2}&EXTENDED={3}&LOCKBIT={4}";

		private ISP _isp;
		private uint _cpuID;

		private Dictionary<uint, string> _cpuLink = new Dictionary<uint, string>()
		{
			{ 0x001E950F, "atmega328p" }
		};

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			//Load serial ports
			cbProgCom.Items.AddRange(SerialPort.GetPortNames().Distinct().ToArray());
			if (cbProgCom.Items.Count > 0)
			{
				cbProgCom.SelectedIndex = 0;
			}

			//Init the UI state
			SetUISerialState(false);
		}

		private void SetUISerialState(bool connected)
		{
			if (connected)
				SetUICPUState(false, true);
			else
				SetUICPUState(false, false);

			btnConnect.Enabled = !connected;
			if (btnConnect.Enabled)
			{
				cbProgCom_SelectedIndexChanged(null, null);
			}

			cbProgCom.Enabled = !connected;
			btnDisconnect.Enabled = connected;
		}

		private void SetUICPUState(bool cpuOK, bool en)
		{
			btnISPEnter.Enabled = (!cpuOK && en);
			btnISPExit.Enabled = (cpuOK && en);

			btnReadEEPROM.Enabled = btnWriteEEPROM.Enabled = btnChipErase.Enabled = btnWriteProgram.Enabled = btnReadProgram.Enabled = btnFuseHelp.Enabled = btnFuseRead.Enabled = btnFuseWrite.Enabled = (cpuOK && en);
		}

		private void Error(string msg)
		{
			MetroMessageBox.Show(this, msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void Info(string msg)
		{
			MetroMessageBox.Show(this, msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private bool Ask(string msg, string title)
		{
			return (MetroMessageBox.Show(this, msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
		}

		private bool TryAction(Func<bool> act)
		{
			try
			{
				return act();
			}
			catch (Exception ex)
			{
				Error(ex.Message);
			}

			return false;
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			ISP isp = new ISP((string)cbProgCom.Items[cbProgCom.SelectedIndex]);

			if (TryAction(() => isp.Poll()))
			{
				_isp = isp;

				SetUISerialState(true);

				TryAction(() =>
				{
					lblProgInfo.Text = _isp.GetInfo();

					return !(string.IsNullOrEmpty(lblProgInfo.Text));
				});
			}
			else
			{
				isp.Close();
			}
		}

		private void btnDisconnect_Click(object sender, EventArgs e)
		{
			if (_isp != null)
			{
				_isp.Close();

				SetUISerialState(false);
			}
		}

		private void cbProgCom_SelectedIndexChanged(object sender, EventArgs e)
		{
			btnConnect.Enabled = (cbProgCom.SelectedIndex > -1);
		}

		private void btnISPEnter_Click(object sender, EventArgs e)
		{
			if(TryAction(() =>
			{
				if (!_isp.EnterISP())
					return false;

				if (!_isp.IsCPUReady())
					return false;

				byte[] sig = _isp.ReadCPUSignature();

				lblCPUSig.Text = sig[0].ToString("X2") + sig[1].ToString("X2") + sig[2].ToString("X2");
				_cpuID = (uint)sig[2] | (uint)(sig[1] << 8) | (uint)(sig[0] << 16);

				if(_cpuLink.ContainsKey(_cpuID))
				{
					lblCPUSig.Text += " (" + _cpuLink[_cpuID] + ")";
				}
				else
				{
					lblCPUSig.Text += " (???)";
				}

				btnFuseRead_Click(null, null);

				return true;
			}))
			{
				SetUICPUState(true, true);
			}
			else
			{
				SetUICPUState(false, true);

				Error("Failed to enter ISP mode.");
			}
		}

		private void btnISPExit_Click(object sender, EventArgs e)
		{
			SetUICPUState(false, true);

			TryAction(() => _isp.ExitISP());
		}

		private void btnFuseRead_Click(object sender, EventArgs e)
		{
			if(!TryAction(() =>
			{
				tbFuseLow.Text = _isp.ReadFuse(Fuse.Low).ToString("X2");
				tbFuseHigh.Text = _isp.ReadFuse(Fuse.High).ToString("X2");
				tbFuseExt.Text = _isp.ReadFuse(Fuse.Extended).ToString("X2");
				lblFuseLock.Text = "0x" + _isp.ReadFuse(Fuse.Lock).ToString("X2");

				return true;
			}))
			{
				Error("Failed to read fuses!");
			}
		}

		private void btnFuseHelp_Click(object sender, EventArgs e)
		{
			if (_cpuLink.ContainsKey(_cpuID))
			{
				Process.Start(String.Format(_fuseLink, _cpuLink[_cpuID], tbFuseLow.Text, tbFuseHigh.Text, tbFuseExt.Text, lblFuseLock.Text.Substring(2)));
			}
			else
			{
				Error("Unknown chip ID!");
			}
		}

		private void btnFuseWrite_Click(object sender, EventArgs e)
		{
			byte low;
			if (!Byte.TryParse(tbFuseLow.Text, NumberStyles.HexNumber, null, out low))
			{
				Error("Fuse low not hex!");
				return;
			}

			byte high;
			if (!Byte.TryParse(tbFuseHigh.Text, NumberStyles.HexNumber, null, out high))
			{
				Error("Fuse high not hex!");
				return;
			}

			byte ext;
			if (!Byte.TryParse(tbFuseExt.Text, NumberStyles.HexNumber, null, out ext))
			{
				Error("Fuse extended not hex!");
				return;
			}

			//Bit 1 = unprogrammed, 0 = programmed => fuse bits are reversed
			if ((high & (1 << 5)) == (1 << 5)) //Check the SPIEN bit, the serial program enable bit
			{
				if (!Ask("The serial programming enable fuse bit is DISABLED. Are you sure want to continue?", "Are you sure?"))
					return;
			}

			if (!Ask("Do you want to program the fuses to the following?\nLow: 0x" + low.ToString("X2") + "\nHigh: 0x" + high.ToString("X2") + "\nExtended: 0x" + ext.ToString("X2"), "Are you sure?"))
				return;

			if (TryAction(() =>
			{
				if (!_isp.WriteFuse(Fuse.Low, low))
					return false;

				if (!_isp.WriteFuse(Fuse.High, high))
					return false;

				if (!_isp.WriteFuse(Fuse.Extended, ext))
					return false;

				return true;
			}))
			{
				btnFuseRead_Click(null, null);

				Info("Fuses written!");
			}
			else
			{
				Error("Failed to write fuses!");
			}
		}

		private void btnChipErase_Click(object sender, EventArgs e)
		{
			if (!Ask("Do you want to erase the chip (program memory and EEPROM)?", "Are you sure?"))
				return;

			if (TryAction(() => _isp.ChipErase()))
			{
				btnFuseRead_Click(null, null);

				Info("Chip erased!");
			}
			else
			{
				Error("Failed to erase chip!");
			}
		}

		private void btnWriteProgram_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog opf = new OpenFileDialog())
			{
				opf.Filter = "Intel HEX (*.hex)|*.hex";

				if (opf.ShowDialog() == DialogResult.OK)
				{
					if (!Ask("Do you want to flash the following file into the program memory: \"" + opf.FileName + "\"?", "Are you sure?"))
						return;

					using (ProgressForm prog = new ProgressForm(new FlashProgramMemoryTask(opf.FileName, _isp)))
					{
						prog.ShowDialog(this);
					}
				}
			}
		}

		private void btnReadProgram_Click(object sender, EventArgs e)
		{
			int size;
			if (!Int32.TryParse(tbProgDumpSize.Text, out size))
			{
				Error("Unable to parse dump size!");
				return;
			}

			using (SaveFileDialog svf = new SaveFileDialog())
			{
				svf.Filter = "Bin files (*.bin)|*.bin|All files|*.*";

				if (svf.ShowDialog() == DialogResult.OK)
				{
					using (ProgressForm prog = new ProgressForm(new DumpProgramMemoryTask(svf.FileName, _isp, size)))
					{
						prog.ShowDialog(this);
					}
				}
			}
		}

		private void btnHexToBin_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog opf = new OpenFileDialog())
			{
				opf.Filter = "Intel HEX (*.hex)|*.hex";

				if (opf.ShowDialog() == DialogResult.OK)
				{
					IntelHEX hex = new IntelHEX();
					try
					{
						if (!hex.ParseFile(opf.FileName))
						{
							Error("Unable to load hex!");
							return;
						}

						using (SaveFileDialog svf = new SaveFileDialog())
						{
							svf.Filter = "Bin files (*.bin)|*.bin|All files|*.*";
							if (svf.ShowDialog() == DialogResult.OK)
							{
								using (MemoryStream convert = hex.GetRawData())
								{
									using (Stream file = File.OpenWrite(svf.FileName))
									{
										convert.CopyTo(file);
									}
								}
							}
						}
					}
					catch (Exception ex)
					{
						Error("Unable to convert hex!\nError: " + ex.Message);
					}
				}
			}
		}

		private void btnWriteEEPROM_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog opf = new OpenFileDialog())
			{
				opf.Filter = "Bin files (*.bin)|*.bin|All files|*.*";

				if (opf.ShowDialog() == DialogResult.OK)
				{
					if (!Ask("Do you want to flash the following file into the EEPROM: \"" + opf.FileName + "\"?", "Are you sure?"))
						return;

					using (ProgressForm prog = new ProgressForm(new FlashEEPROMTask(opf.FileName, _isp)))
					{
						prog.ShowDialog(this);
					}
				}
			}
		}

		private void btnReadEEPROM_Click(object sender, EventArgs e)
		{
			int size;
			if (!Int32.TryParse(tbEEPROMSize.Text, out size))
			{
				Error("Unable to parse dump size!");
				return;
			}

			using (SaveFileDialog svf = new SaveFileDialog())
			{
				svf.Filter = "Bin files (*.bin)|*.bin|All files|*.*";

				if (svf.ShowDialog() == DialogResult.OK)
				{
					using (ProgressForm prog = new ProgressForm(new DumpEEPROMTask(svf.FileName, _isp, size)))
					{
						prog.ShowDialog(this);
					}
				}
			}
		}
	}
}
