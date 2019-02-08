namespace PNGPaletteExtractor
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
            this.label1 = new System.Windows.Forms.Label();
            this.InputBrowseButton = new System.Windows.Forms.Button();
            this.PNGInputFileTextBox = new System.Windows.Forms.TextBox();
            this.PNGInputPictureBox = new System.Windows.Forms.PictureBox();
            this.PaletteOutputFileTextBox = new System.Windows.Forms.TextBox();
            this.OutputBrowseButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ExtractButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PNGInputPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PNG Input:";
            // 
            // InputBrowseButton
            // 
            this.InputBrowseButton.Location = new System.Drawing.Point(400, 11);
            this.InputBrowseButton.Name = "InputBrowseButton";
            this.InputBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.InputBrowseButton.TabIndex = 1;
            this.InputBrowseButton.Text = "Browse";
            this.InputBrowseButton.UseVisualStyleBackColor = true;
            this.InputBrowseButton.Click += new System.EventHandler(this.InputBrowseButton_Click);
            // 
            // PNGInputFileTextBox
            // 
            this.PNGInputFileTextBox.Location = new System.Drawing.Point(92, 12);
            this.PNGInputFileTextBox.Name = "PNGInputFileTextBox";
            this.PNGInputFileTextBox.Size = new System.Drawing.Size(302, 20);
            this.PNGInputFileTextBox.TabIndex = 2;
            // 
            // PNGInputPictureBox
            // 
            this.PNGInputPictureBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PNGInputPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PNGInputPictureBox.Location = new System.Drawing.Point(109, 64);
            this.PNGInputPictureBox.Name = "PNGInputPictureBox";
            this.PNGInputPictureBox.Size = new System.Drawing.Size(265, 157);
            this.PNGInputPictureBox.TabIndex = 3;
            this.PNGInputPictureBox.TabStop = false;
            // 
            // PaletteOutputFileTextBox
            // 
            this.PaletteOutputFileTextBox.Location = new System.Drawing.Point(92, 38);
            this.PaletteOutputFileTextBox.Name = "PaletteOutputFileTextBox";
            this.PaletteOutputFileTextBox.Size = new System.Drawing.Size(302, 20);
            this.PaletteOutputFileTextBox.TabIndex = 4;
            // 
            // OutputBrowseButton
            // 
            this.OutputBrowseButton.Enabled = false;
            this.OutputBrowseButton.Location = new System.Drawing.Point(400, 37);
            this.OutputBrowseButton.Name = "OutputBrowseButton";
            this.OutputBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.OutputBrowseButton.TabIndex = 5;
            this.OutputBrowseButton.Text = "Browse";
            this.OutputBrowseButton.UseVisualStyleBackColor = true;
            this.OutputBrowseButton.Click += new System.EventHandler(this.OutputBrowseButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Palette Output:";
            // 
            // ExtractButton
            // 
            this.ExtractButton.Enabled = false;
            this.ExtractButton.Location = new System.Drawing.Point(400, 131);
            this.ExtractButton.Name = "ExtractButton";
            this.ExtractButton.Size = new System.Drawing.Size(75, 23);
            this.ExtractButton.TabIndex = 7;
            this.ExtractButton.Text = "Extract Palette";
            this.ExtractButton.UseVisualStyleBackColor = true;
            this.ExtractButton.Click += new System.EventHandler(this.ExtractButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 228);
            this.Controls.Add(this.ExtractButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OutputBrowseButton);
            this.Controls.Add(this.PaletteOutputFileTextBox);
            this.Controls.Add(this.PNGInputPictureBox);
            this.Controls.Add(this.PNGInputFileTextBox);
            this.Controls.Add(this.InputBrowseButton);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "PNG Palette Extractor";
            ((System.ComponentModel.ISupportInitialize)(this.PNGInputPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button InputBrowseButton;
        private System.Windows.Forms.TextBox PNGInputFileTextBox;
        private System.Windows.Forms.PictureBox PNGInputPictureBox;
        private System.Windows.Forms.TextBox PaletteOutputFileTextBox;
        private System.Windows.Forms.Button OutputBrowseButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ExtractButton;
    }
}

