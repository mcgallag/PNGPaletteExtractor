namespace WingCommanderArduinoBridge
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.OpenPNGButton = new System.Windows.Forms.Button();
            this.PNGInputFileTextBox = new System.Windows.Forms.TextBox();
            this.PaletteInputFileTextBox = new System.Windows.Forms.TextBox();
            this.LoadPaletteButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ExtractButton = new System.Windows.Forms.Button();
            this.VGAPictureBox = new System.Windows.Forms.PictureBox();
            this.DOSBoxButton = new System.Windows.Forms.Button();
            this.PlayerCallsignTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DOSBoxTimer = new System.Windows.Forms.Timer(this.components);
            this.LeftVDUPictureBox = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FPSValueUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.PlayerFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PlayerLastNameTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.RightVDUPictureBox = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.WingmanCallsignTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.PlayerCurrentKillsTextBox = new System.Windows.Forms.TextBox();
            this.WingmanCurrentKillsTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.PlayerShipTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.DOSBoxTextPanel = new System.Windows.Forms.Panel();
            this.PlayerTotalKillsTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.VGAPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftVDUPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FPSValueUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightVDUPictureBox)).BeginInit();
            this.DOSBoxTextPanel.SuspendLayout();
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
            // OpenPNGButton
            // 
            this.OpenPNGButton.Location = new System.Drawing.Point(400, 11);
            this.OpenPNGButton.Name = "OpenPNGButton";
            this.OpenPNGButton.Size = new System.Drawing.Size(75, 23);
            this.OpenPNGButton.TabIndex = 1;
            this.OpenPNGButton.Text = "Open";
            this.OpenPNGButton.UseVisualStyleBackColor = true;
            this.OpenPNGButton.Click += new System.EventHandler(this.OpenPNGButton_Click);
            // 
            // PNGInputFileTextBox
            // 
            this.PNGInputFileTextBox.Location = new System.Drawing.Point(92, 12);
            this.PNGInputFileTextBox.Name = "PNGInputFileTextBox";
            this.PNGInputFileTextBox.Size = new System.Drawing.Size(302, 20);
            this.PNGInputFileTextBox.TabIndex = 2;
            // 
            // PaletteInputFileTextBox
            // 
            this.PaletteInputFileTextBox.Location = new System.Drawing.Point(92, 38);
            this.PaletteInputFileTextBox.Name = "PaletteInputFileTextBox";
            this.PaletteInputFileTextBox.Size = new System.Drawing.Size(302, 20);
            this.PaletteInputFileTextBox.TabIndex = 4;
            // 
            // LoadPaletteButton
            // 
            this.LoadPaletteButton.Location = new System.Drawing.Point(400, 37);
            this.LoadPaletteButton.Name = "LoadPaletteButton";
            this.LoadPaletteButton.Size = new System.Drawing.Size(75, 23);
            this.LoadPaletteButton.TabIndex = 5;
            this.LoadPaletteButton.Text = "Open";
            this.LoadPaletteButton.UseVisualStyleBackColor = true;
            this.LoadPaletteButton.Click += new System.EventHandler(this.OpenPaletteButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Palette Input:";
            // 
            // ExtractButton
            // 
            this.ExtractButton.Enabled = false;
            this.ExtractButton.Location = new System.Drawing.Point(484, 11);
            this.ExtractButton.Name = "ExtractButton";
            this.ExtractButton.Size = new System.Drawing.Size(106, 23);
            this.ExtractButton.TabIndex = 7;
            this.ExtractButton.Text = "Extract Palette";
            this.ExtractButton.UseVisualStyleBackColor = true;
            this.ExtractButton.Click += new System.EventHandler(this.ExtractButton_Click);
            // 
            // VGAPictureBox
            // 
            this.VGAPictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.VGAPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VGAPictureBox.Location = new System.Drawing.Point(29, 72);
            this.VGAPictureBox.Name = "VGAPictureBox";
            this.VGAPictureBox.Size = new System.Drawing.Size(320, 200);
            this.VGAPictureBox.TabIndex = 8;
            this.VGAPictureBox.TabStop = false;
            // 
            // DOSBoxButton
            // 
            this.DOSBoxButton.Location = new System.Drawing.Point(366, 72);
            this.DOSBoxButton.Name = "DOSBoxButton";
            this.DOSBoxButton.Size = new System.Drawing.Size(106, 23);
            this.DOSBoxButton.TabIndex = 9;
            this.DOSBoxButton.Text = "Attach to DOSBox";
            this.DOSBoxButton.UseVisualStyleBackColor = true;
            this.DOSBoxButton.Click += new System.EventHandler(this.AttachDOSBoxButton_Click);
            // 
            // PlayerCallsignTextBox
            // 
            this.PlayerCallsignTextBox.Location = new System.Drawing.Point(3, 19);
            this.PlayerCallsignTextBox.Name = "PlayerCallsignTextBox";
            this.PlayerCallsignTextBox.ReadOnly = true;
            this.PlayerCallsignTextBox.Size = new System.Drawing.Size(106, 20);
            this.PlayerCallsignTextBox.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Player Callsign:";
            // 
            // DOSBoxTimer
            // 
            this.DOSBoxTimer.Tick += new System.EventHandler(this.DOSBoxTimer_Tick);
            // 
            // LeftVDUPictureBox
            // 
            this.LeftVDUPictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.LeftVDUPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LeftVDUPictureBox.Location = new System.Drawing.Point(29, 302);
            this.LeftVDUPictureBox.Name = "LeftVDUPictureBox";
            this.LeftVDUPictureBox.Size = new System.Drawing.Size(150, 150);
            this.LeftVDUPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LeftVDUPictureBox.TabIndex = 12;
            this.LeftVDUPictureBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Left VDU:";
            // 
            // FPSValueUpDown
            // 
            this.FPSValueUpDown.Location = new System.Drawing.Point(515, 74);
            this.FPSValueUpDown.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.FPSValueUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FPSValueUpDown.Name = "FPSValueUpDown";
            this.FPSValueUpDown.Size = new System.Drawing.Size(75, 20);
            this.FPSValueUpDown.TabIndex = 14;
            this.FPSValueUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.FPSValueUpDown.ValueChanged += new System.EventHandler(this.FPSValueUpDown_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(481, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "FPS:";
            // 
            // PlayerFirstNameTextBox
            // 
            this.PlayerFirstNameTextBox.Location = new System.Drawing.Point(3, 136);
            this.PlayerFirstNameTextBox.Name = "PlayerFirstNameTextBox";
            this.PlayerFirstNameTextBox.ReadOnly = true;
            this.PlayerFirstNameTextBox.Size = new System.Drawing.Size(106, 20);
            this.PlayerFirstNameTextBox.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Player First Name:";
            // 
            // PlayerLastNameTextBox
            // 
            this.PlayerLastNameTextBox.Location = new System.Drawing.Point(3, 175);
            this.PlayerLastNameTextBox.Name = "PlayerLastNameTextBox";
            this.PlayerLastNameTextBox.ReadOnly = true;
            this.PlayerLastNameTextBox.Size = new System.Drawing.Size(106, 20);
            this.PlayerLastNameTextBox.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Player Last Name:";
            // 
            // RightVDUPictureBox
            // 
            this.RightVDUPictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.RightVDUPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RightVDUPictureBox.Location = new System.Drawing.Point(199, 302);
            this.RightVDUPictureBox.Name = "RightVDUPictureBox";
            this.RightVDUPictureBox.Size = new System.Drawing.Size(150, 150);
            this.RightVDUPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RightVDUPictureBox.TabIndex = 19;
            this.RightVDUPictureBox.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(196, 284);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Right VDU:";
            // 
            // WingmanCallsignTextBox
            // 
            this.WingmanCallsignTextBox.Location = new System.Drawing.Point(119, 19);
            this.WingmanCallsignTextBox.Name = "WingmanCallsignTextBox";
            this.WingmanCallsignTextBox.ReadOnly = true;
            this.WingmanCallsignTextBox.Size = new System.Drawing.Size(106, 20);
            this.WingmanCallsignTextBox.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(119, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Wingman Callsign:";
            // 
            // PlayerCurrentKillsTextBox
            // 
            this.PlayerCurrentKillsTextBox.Location = new System.Drawing.Point(3, 58);
            this.PlayerCurrentKillsTextBox.Name = "PlayerCurrentKillsTextBox";
            this.PlayerCurrentKillsTextBox.ReadOnly = true;
            this.PlayerCurrentKillsTextBox.Size = new System.Drawing.Size(106, 20);
            this.PlayerCurrentKillsTextBox.TabIndex = 23;
            // 
            // WingmanCurrentKillsTextBox
            // 
            this.WingmanCurrentKillsTextBox.Location = new System.Drawing.Point(119, 58);
            this.WingmanCurrentKillsTextBox.Name = "WingmanCurrentKillsTextBox";
            this.WingmanCurrentKillsTextBox.ReadOnly = true;
            this.WingmanCurrentKillsTextBox.Size = new System.Drawing.Size(106, 20);
            this.WingmanCurrentKillsTextBox.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Player Kills (mission):";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(119, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Wingman Kills (mission):";
            // 
            // PlayerShipTextBox
            // 
            this.PlayerShipTextBox.Location = new System.Drawing.Point(119, 136);
            this.PlayerShipTextBox.Name = "PlayerShipTextBox";
            this.PlayerShipTextBox.ReadOnly = true;
            this.PlayerShipTextBox.Size = new System.Drawing.Size(106, 20);
            this.PlayerShipTextBox.TabIndex = 27;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(119, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Player Ship Name:";
            // 
            // DOSBoxTextPanel
            // 
            this.DOSBoxTextPanel.Controls.Add(this.PlayerTotalKillsTextBox);
            this.DOSBoxTextPanel.Controls.Add(this.label13);
            this.DOSBoxTextPanel.Controls.Add(this.label3);
            this.DOSBoxTextPanel.Controls.Add(this.label12);
            this.DOSBoxTextPanel.Controls.Add(this.PlayerCallsignTextBox);
            this.DOSBoxTextPanel.Controls.Add(this.PlayerShipTextBox);
            this.DOSBoxTextPanel.Controls.Add(this.label6);
            this.DOSBoxTextPanel.Controls.Add(this.label11);
            this.DOSBoxTextPanel.Controls.Add(this.PlayerFirstNameTextBox);
            this.DOSBoxTextPanel.Controls.Add(this.label10);
            this.DOSBoxTextPanel.Controls.Add(this.label7);
            this.DOSBoxTextPanel.Controls.Add(this.WingmanCurrentKillsTextBox);
            this.DOSBoxTextPanel.Controls.Add(this.PlayerLastNameTextBox);
            this.DOSBoxTextPanel.Controls.Add(this.PlayerCurrentKillsTextBox);
            this.DOSBoxTextPanel.Controls.Add(this.WingmanCallsignTextBox);
            this.DOSBoxTextPanel.Controls.Add(this.label9);
            this.DOSBoxTextPanel.Location = new System.Drawing.Point(366, 99);
            this.DOSBoxTextPanel.Name = "DOSBoxTextPanel";
            this.DOSBoxTextPanel.Size = new System.Drawing.Size(241, 302);
            this.DOSBoxTextPanel.TabIndex = 29;
            // 
            // PlayerTotalKillsTextBox
            // 
            this.PlayerTotalKillsTextBox.Location = new System.Drawing.Point(3, 97);
            this.PlayerTotalKillsTextBox.Name = "PlayerTotalKillsTextBox";
            this.PlayerTotalKillsTextBox.ReadOnly = true;
            this.PlayerTotalKillsTextBox.Size = new System.Drawing.Size(106, 20);
            this.PlayerTotalKillsTextBox.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Player Kills (total):";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 464);
            this.Controls.Add(this.DOSBoxTextPanel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.RightVDUPictureBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FPSValueUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LeftVDUPictureBox);
            this.Controls.Add(this.DOSBoxButton);
            this.Controls.Add(this.VGAPictureBox);
            this.Controls.Add(this.ExtractButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LoadPaletteButton);
            this.Controls.Add(this.PaletteInputFileTextBox);
            this.Controls.Add(this.PNGInputFileTextBox);
            this.Controls.Add(this.OpenPNGButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainForm";
            this.Text = "Wing Commander Arduino Bridge";
            ((System.ComponentModel.ISupportInitialize)(this.VGAPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftVDUPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FPSValueUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightVDUPictureBox)).EndInit();
            this.DOSBoxTextPanel.ResumeLayout(false);
            this.DOSBoxTextPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OpenPNGButton;
        private System.Windows.Forms.TextBox PNGInputFileTextBox;
        private System.Windows.Forms.TextBox PaletteInputFileTextBox;
        private System.Windows.Forms.Button LoadPaletteButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ExtractButton;
        private System.Windows.Forms.PictureBox VGAPictureBox;
        private System.Windows.Forms.Button DOSBoxButton;
        private System.Windows.Forms.TextBox PlayerCallsignTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer DOSBoxTimer;
        private System.Windows.Forms.PictureBox LeftVDUPictureBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown FPSValueUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PlayerFirstNameTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox PlayerLastNameTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox RightVDUPictureBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox WingmanCallsignTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox PlayerCurrentKillsTextBox;
        private System.Windows.Forms.TextBox WingmanCurrentKillsTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox PlayerShipTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel DOSBoxTextPanel;
        private System.Windows.Forms.TextBox PlayerTotalKillsTextBox;
        private System.Windows.Forms.Label label13;
    }
}

