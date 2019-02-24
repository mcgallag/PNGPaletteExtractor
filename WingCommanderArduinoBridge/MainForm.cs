using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using WingCommanderMemoryReader;

namespace WingCommanderArduinoBridge
{
    public partial class MainForm : Form
    {
        OpenFileDialog openPNGDialog;
        OpenFileDialog openPaletteDialog;
        SaveFileDialog savePaletteDialog;

        Color[] palette = null;

        Color DisabledLight = Color.FromArgb(113, 0, 0);
        Color EnabledLight = Color.FromArgb(255, 0, 0);

        MemoryReader mem;

        string CurrentPlayerShip;

        public GameState CurrentGameState;

        public MainForm()
        {
            InitializeComponent();

            // create the memory reader interface
            mem = new MemoryReader(GameMode.WC2);

            openPNGDialog = new OpenFileDialog
            {
                Filter = "PNG files (*.png)|*.png|All Files (*.*)|*.*",
                RestoreDirectory = true
            };
            openPaletteDialog = new OpenFileDialog
            {
                Filter = "DAT files (*.dat)|*.dat|All Files(*.*)|*.*",
                RestoreDirectory = true
            };
            savePaletteDialog = new SaveFileDialog
            {
                Filter = "DAT files (*.dat)|*.dat|All Files(*.*)|*.*",
                RestoreDirectory = true
            };


            // HACK - for debug purposes
            PaletteInputFileTextBox.Text = "F:\\GOG Games\\Wing Commander II\\capture\\palette.dat";
            palette = LoadPaletteFromFile(PaletteInputFileTextBox.Text);
            mem.Palette = palette;

            DOSBoxTimer.Interval = 1000 / (int)FPSValueUpDown.Value;

            AutoPilotLightPictureBox.BackColor = DisabledLight;
            MissileLockLightPictureBox.BackColor = DisabledLight;
            EjectBoxLightPictureBox.BackColor = DisabledLight;

            BindingSource bs = new BindingSource();
            bs.DataSource = typeof(GameState);
            bs.Add(CurrentGameState);
            PlayerCallsignTextBox.DataBindings.Add("Text", bs, "PlayerCallsign");
        }

        /// <summary>
        /// opens a PNG from disk and generates a palette from it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenPNGButton_Click(object sender, EventArgs e)
        {
            if (openPNGDialog.ShowDialog() == DialogResult.OK)
            {
                PNGInputFileTextBox.Text = openPNGDialog.FileName;
                VGAPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                VGAPictureBox.Image = Image.FromFile(openPNGDialog.FileName);
                palette = VGAPictureBox.Image.Palette.Entries;
                openPaletteDialog.InitialDirectory = openPNGDialog.FileName;
                ExtractButton.Enabled = true;
            }
        }

        /// <summary>
        /// opens an extracted palette file from disk
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenPaletteButton_Click(object sender, EventArgs e)
        {
            if (openPaletteDialog.ShowDialog() == DialogResult.OK)
            {
                PaletteInputFileTextBox.Text = openPaletteDialog.FileName;
                palette = LoadPaletteFromFile(PaletteInputFileTextBox.Text);
            }
        }

        /// <summary>
        /// generates a palette from a file
        /// </summary>
        /// <param name="filename">.DAT File from which to load</param>
        /// <returns>Color array with palette loaded by index</returns>
        private Color[] LoadPaletteFromFile(string filename)
        {
            Color[] inputPalette = new Color[256];

            using (FileStream inputStream = File.OpenRead(filename))
            {
                // my .dat palette files are 256*3 bytes long
                // each 3-byte tuple is (red,green,blue)
                for (int i = 0; i < inputPalette.Length; i++)
                {
                    int r, g, b;
                    r = inputStream.ReadByte();
                    g = inputStream.ReadByte();
                    b = inputStream.ReadByte();
                    inputPalette[i] = Color.FromArgb(r, g, b);
                }
            }
            return inputPalette;
        }

        /// <summary>
        /// Generates a .DAT palette and writes it to disk
        /// </summary>
        /// <param name="filename">filename to save</param>
        /// <param name="paletteArray">color palette</param>
        private void WritePaletteToFile(string filename, Color[] paletteArray)
        {
            using (FileStream outputStream = File.OpenWrite(filename))
            {
                // write each 3-byte tuple to disk in R/G/B order
                foreach (Color c in paletteArray)
                {
                    outputStream.WriteByte(c.R);
                    outputStream.WriteByte(c.G);
                    outputStream.WriteByte(c.B);
                }
            }
        }

        /// <summary>
        /// prompt user for filename and save palette to disk
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExtractButton_Click(object sender, EventArgs e)
        {
            if (savePaletteDialog.ShowDialog() == DialogResult.OK)
            {
                WritePaletteToFile(savePaletteDialog.FileName, VGAPictureBox.Image.Palette.Entries);
                MessageBox.Show("Palette extracted to output file.");
            }
        }

        /// <summary>
        /// detach from DOSBox process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetachDOSBoxButton_Click(object sender, EventArgs e)
        {
            if (DOSBoxTimer.Enabled)
            {
                DOSBoxTimer.Enabled = false;
                DOSBoxButton.Text = "Attach";
                DOSBoxButton.Click -= DetachDOSBoxButton_Click;
                DOSBoxButton.Click += AttachDOSBoxButton_Click;
                ResetForm(); // clear DOSBox's text fields
            }
        }

        /// <summary>
        /// clears all DOSBox form controls
        /// </summary>
        private void ResetForm()
        {
            VGAPictureBox.Image = null;
            LeftVDUPictureBox.Image = null;
            RightVDUPictureBox.Image = null;

            AfterburnerFuelLevel.Value = 0;

            // HACK - probably a more elegant way of doing this, but it works
            foreach (Control control in DOSBoxTextPanel.Controls)
            {
                if (control is TextBox)
                    control.Text = "";
            }
        }

        /// <summary>
        /// attach the memory interface to the DOSBox process, starts the form update timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttachDOSBoxButton_Click(object sender, EventArgs e)
        {
            if (mem.OpenProc == false)
            {
                mem.Attach();
            }
            DOSBoxTimer.Enabled = true;
            DOSBoxButton.Text = "Detach";
            DOSBoxButton.Click -= AttachDOSBoxButton_Click;
            DOSBoxButton.Click += DetachDOSBoxButton_Click;
        }

        /// <summary>
        /// called every frame, updates text fields and image captures
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DOSBoxTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // TODO - maybe data binding
                CurrentGameState = mem.GetGameState();
                //PlayerCallsignTextBox.Text = CurrentGameState.PlayerCallsign;
                PlayerFirstNameTextBox.Text = CurrentGameState.PlayerFirstName;
                PlayerLastNameTextBox.Text = CurrentGameState.PlayerLastName;
                WingmanCallsignTextBox.Text = CurrentGameState.WingmanCallsign;
                PlayerCurrentKillsTextBox.Text = CurrentGameState.PlayerMissionKillCount.ToString();
                WingmanCurrentKillsTextBox.Text = CurrentGameState.WingmanMissionKillCount.ToString();
                if (CurrentGameState.PlayerShipName != CurrentPlayerShip)
                {
                    CurrentPlayerShip = CurrentGameState.PlayerShipName;
                    PlayerShipTextBox.Text = CurrentPlayerShip;
                    AfterburnerFuelLevel.Maximum = CurrentGameState.MaximumFuel;
                }
                PlayerTotalKillsTextBox.Text = CurrentGameState.PlayerTotalKillCount.ToString();

                int fuel = CurrentGameState.RemainingFuel;
                if (fuel > 0)
                {
                    float fuelPercentage = (float)fuel / AfterburnerFuelLevel.Maximum;
                    if (fuelPercentage < 0.25)
                    {
                        AfterburnerFuelLevel.ForeColor = Color.Red;
                        AfterburnerFuelLevel.BackColor = Color.DarkRed;
                    }
                    else if (fuelPercentage < 0.6)
                    {
                        AfterburnerFuelLevel.ForeColor = Color.Yellow;
                        AfterburnerFuelLevel.BackColor = Color.Gold;
                    }
                    else
                    {
                        AfterburnerFuelLevel.ForeColor = Color.LightGreen;
                        AfterburnerFuelLevel.BackColor = Color.DarkGreen;
                    }
                }

                // clamp fuel between 0 and maximum because the memory isn't always consistent
                // in edge cases (occasionally gets set out of bounds when you die) HACK ?
                fuel = (fuel < AfterburnerFuelLevel.Maximum) ? fuel : AfterburnerFuelLevel.Maximum;
                fuel = (fuel >= 0) ? fuel : 0;
                AfterburnerFuelLevel.Value = fuel;

                // capture the VGA buffer and separate into VDUs
                VGAPictureBox.Image = CurrentGameState.VGABuffer;
                RightVDUPictureBox.Image = CurrentGameState.RightVDU;
                LeftVDUPictureBox.Image = CurrentGameState.LeftVDU;

                // update indicator lights
                AutoPilotLightPictureBox.BackColor = (CurrentGameState.AutoPilotLight) ? EnabledLight : DisabledLight;
                MissileLockLightPictureBox.BackColor = (CurrentGameState.MissileLockLight) ? EnabledLight : DisabledLight;
                EjectBoxLightPictureBox.BackColor = (CurrentGameState.EjectLight) ? EnabledLight : DisabledLight;
            } catch (NullReferenceException)
            {
                DetachDOSBoxButton_Click(this, null);
            }
        }

        /// <summary>
        /// Update the rate at which to call the Timer function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FPSValueUpDown_ValueChanged(object sender, EventArgs e)
        {
            DOSBoxTimer.Interval = 1000 / (int)FPSValueUpDown.Value;
        }
    }

/*    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }*/
}
