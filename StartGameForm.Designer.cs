﻿namespace Assignment7
{
    partial class StartGameForm
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
            textBoxLvl = new TextBox();
            lblStartingLevel = new Label();
            btnStart = new Button();
            btnMenu = new Button();
            lblMusic = new Label();
            radioBtnMusicOn = new RadioButton();
            radioBtnMusicOff = new RadioButton();
            SuspendLayout();
            // 
            // textBoxLvl
            // 
            textBoxLvl.BackColor = Color.Black;
            textBoxLvl.BorderStyle = BorderStyle.None;
            textBoxLvl.Font = new Font("Consolas", 36F);
            textBoxLvl.ForeColor = Color.White;
            textBoxLvl.Location = new Point(611, 82);
            textBoxLvl.Name = "textBoxLvl";
            textBoxLvl.Size = new Size(75, 57);
            textBoxLvl.TabIndex = 0;
            textBoxLvl.Text = "00";
            textBoxLvl.TextAlign = HorizontalAlignment.Center;
            // 
            // lblStartingLevel
            // 
            lblStartingLevel.AutoSize = true;
            lblStartingLevel.BackColor = Color.Black;
            lblStartingLevel.Font = new Font("Consolas", 36F);
            lblStartingLevel.ForeColor = Color.White;
            lblStartingLevel.Location = new Point(9, 85);
            lblStartingLevel.Name = "lblStartingLevel";
            lblStartingLevel.Size = new Size(596, 56);
            lblStartingLevel.TabIndex = 11;
            lblStartingLevel.Text = "STARTING LEVEL (0-29):";
            // 
            // btnStart
            // 
            btnStart.AutoSize = true;
            btnStart.BackColor = Color.Black;
            btnStart.FlatAppearance.BorderColor = Color.Black;
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.Font = new Font("Consolas", 48F);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(9, 564);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(330, 85);
            btnStart.TabIndex = 13;
            btnStart.Text = "START";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // btnMenu
            // 
            btnMenu.AutoSize = true;
            btnMenu.BackColor = Color.Black;
            btnMenu.FlatAppearance.BorderColor = Color.Black;
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.Font = new Font("Consolas", 48F);
            btnMenu.ForeColor = Color.White;
            btnMenu.Location = new Point(362, 564);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(330, 85);
            btnMenu.TabIndex = 14;
            btnMenu.Text = "MENU";
            btnMenu.UseVisualStyleBackColor = false;
            btnMenu.Click += btnMenu_Click;
            // 
            // lblMusic
            // 
            lblMusic.AutoSize = true;
            lblMusic.BackColor = Color.Black;
            lblMusic.Font = new Font("Consolas", 36F);
            lblMusic.ForeColor = Color.White;
            lblMusic.Location = new Point(10, 366);
            lblMusic.Name = "lblMusic";
            lblMusic.Size = new Size(180, 56);
            lblMusic.TabIndex = 15;
            lblMusic.Text = "MUSIC:";
            // 
            // radioBtnMusicOn
            // 
            radioBtnMusicOn.AutoSize = true;
            radioBtnMusicOn.Font = new Font("Consolas", 36F);
            radioBtnMusicOn.ForeColor = Color.White;
            radioBtnMusicOn.Location = new Point(199, 364);
            radioBtnMusicOn.Name = "radioBtnMusicOn";
            radioBtnMusicOn.Size = new Size(94, 60);
            radioBtnMusicOn.TabIndex = 16;
            radioBtnMusicOn.TabStop = true;
            radioBtnMusicOn.Text = "ON";
            radioBtnMusicOn.UseVisualStyleBackColor = true;
            // 
            // radioBtnMusicOff
            // 
            radioBtnMusicOff.AutoSize = true;
            radioBtnMusicOff.Font = new Font("Consolas", 36F);
            radioBtnMusicOff.ForeColor = Color.White;
            radioBtnMusicOff.Location = new Point(311, 366);
            radioBtnMusicOff.Name = "radioBtnMusicOff";
            radioBtnMusicOff.Size = new Size(120, 60);
            radioBtnMusicOff.TabIndex = 17;
            radioBtnMusicOff.TabStop = true;
            radioBtnMusicOff.Text = "OFF";
            radioBtnMusicOff.UseVisualStyleBackColor = true;
            // 
            // StartGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(704, 661);
            Controls.Add(radioBtnMusicOff);
            Controls.Add(radioBtnMusicOn);
            Controls.Add(lblMusic);
            Controls.Add(btnMenu);
            Controls.Add(btnStart);
            Controls.Add(lblStartingLevel);
            Controls.Add(textBoxLvl);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StartGameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tetris in WinForms";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxLvl;
        private Label lblStartingLevel;
        private Button btnStart;
        private Button btnMenu;
        private Label lblMusic;
        private RadioButton radioBtnMusicOn;
        private RadioButton radioBtnMusicOff;
    }
}