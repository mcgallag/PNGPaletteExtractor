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

namespace PNGPaletteExtractor
{
    public partial class MainForm : Form
    {
        OpenFileDialog openFileDialog;
        SaveFileDialog saveFileDialog;
        Image inputImage;

        public MainForm()
        {
            InitializeComponent();

            openFileDialog = new OpenFileDialog
            {
                Filter = "PNG files (*.png)|*.png|All Files (*.*)|*.*",
                RestoreDirectory = true
            };
            saveFileDialog = new SaveFileDialog
            {
                Filter = "DAT files (*.dat)|*.dat|All Files(*.*)|*.*",
                RestoreDirectory = true
            };
        }

        private void InputBrowseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PNGInputFileTextBox.Text = openFileDialog.FileName;
                inputImage = Image.FromFile(openFileDialog.FileName);
                PNGInputPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                PNGInputPictureBox.Image = inputImage;
                saveFileDialog.InitialDirectory = openFileDialog.FileName;
                OutputBrowseButton.Enabled = true;
            }
        }

        private void OutputBrowseButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                PaletteOutputFileTextBox.Text = saveFileDialog.FileName;
                ExtractButton.Enabled = true;
            }
        }

        private void ExtractButton_Click(object sender, EventArgs e)
        {
            System.Drawing.Imaging.ColorPalette palette = inputImage.Palette;
            FileStream outputStream = File.OpenWrite(PaletteOutputFileTextBox.Text);
            foreach (Color c in palette.Entries)
            {
                outputStream.WriteByte(c.R);
                outputStream.WriteByte(c.G);
                outputStream.WriteByte(c.B);
            }
            outputStream.Close();
            MessageBox.Show("Palette extracted to output file.");
        }
    }
}
