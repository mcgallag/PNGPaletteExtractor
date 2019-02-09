using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WingCommanderMemoryReader;

namespace PNGPaletteExtractor
{
    public partial class MainForm : Form
    {
        OpenFileDialog openPNGDialog;
        OpenFileDialog openPaletteDialog;
        SaveFileDialog savePaletteDialog;
        Bitmap capturedImage;
        Bitmap rightVDUImage;
        Color[] palette = null;
        MemoryReader mem;

        public MainForm()
        {
            InitializeComponent();

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

            capturedImage = new Bitmap(320, 200);
            rightVDUImage = new Bitmap(75, 65);
            PaletteInputFileTextBox.Text = "F:\\GOG Games\\Wing Commander II\\capture\\palette.dat";
            palette = LoadPaletteFromFile(PaletteInputFileTextBox.Text);
            DOSBoxTimer.Interval = 1000 / (int)FPSValueUpDown.Value;
        }

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

        private void OpenPaletteButton_Click(object sender, EventArgs e)
        {
            if (openPaletteDialog.ShowDialog() == DialogResult.OK)
            {
                PaletteInputFileTextBox.Text = openPaletteDialog.FileName;
                palette = LoadPaletteFromFile(PaletteInputFileTextBox.Text);
            }
        }

        private Color[] LoadPaletteFromFile(string filename)
        {
            Color[] inputPalette = new Color[256];
            using (FileStream inputStream = File.OpenRead(filename))
            {
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

        private void WritePaletteToFile(string filename, Color[] paletteArray)
        {
            using (FileStream outputStream = File.OpenWrite(filename))
            {
                foreach (Color c in paletteArray)
                {
                    outputStream.WriteByte(c.R);
                    outputStream.WriteByte(c.G);
                    outputStream.WriteByte(c.B);
                }
            }
        }

        private void ExtractButton_Click(object sender, EventArgs e)
        {
            if (savePaletteDialog.ShowDialog() == DialogResult.OK)
            {
                WritePaletteToFile(savePaletteDialog.FileName, VGAPictureBox.Image.Palette.Entries);
                MessageBox.Show("Palette extracted to output file.");
            }
        }

        private void DetachDOSBoxButton_Click(object sender, EventArgs e)
        {
            if (DOSBoxTimer.Enabled)
            {
                DOSBoxTimer.Enabled = false;
                DOSBoxButton.Text = "Attach";
                DOSBoxButton.Click -= DetachDOSBoxButton_Click;
                DOSBoxButton.Click += AttachDOSBoxButton_Click;
                ResetForm();
            }
        }

        private void ResetForm()
        {
            VGAPictureBox.Image = null;
            LeftVDUPictureBox.Image = null;
            PlayerCallsignTextBox.Text = null;
        }

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

        private void DOSBoxTimer_Tick(object sender, EventArgs e)
        {
            PlayerCallsignTextBox.Text = mem.GetPlayerCallsign();
            PlayerFirstNameTextBox.Text = mem.GetPlayerFirstName();
            PlayerLastNameTextBox.Text = mem.GetPlayerLastName();
            WingmanCallsignTextBox.Text = mem.GetWingmanCallsign();
            PlayerCurrentKillsTextBox.Text = mem.GetCurrentKills().ToString();
            WingmanCurrentKillsTextBox.Text = mem.GetWingmanKills().ToString();

            byte[] buffer = mem.GetVGABuffer();
            for (int i = 0; i < buffer.Length; i++)
            {
                capturedImage.SetPixel(i % 320, i / 320, palette[buffer[i]]);
                if (i / 320 >= 98 && (i / 320 < (98+65)))
                {
                    if (i % 320 >= 122 && (i % 320) < (122 + 75))
                    {
                        rightVDUImage.SetPixel((i % 320) - 122, (i / 320) - 98, palette[buffer[i]]);
                    }
                }
            }
            VGAPictureBox.Image = capturedImage;
            RightVDUPictureBox.Image = rightVDUImage;
        }

        private void FPSValueUpDown_ValueChanged(object sender, EventArgs e)
        {
            DOSBoxTimer.Interval = 1000 / (int)FPSValueUpDown.Value;
        }
    }
}
