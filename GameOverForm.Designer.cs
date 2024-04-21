namespace Assignment7
{
    partial class GameOverForm
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
            lblGameOver = new Label();
            btnMenu = new Button();
            btnSave = new Button();
            lblFinalScore = new Label();
            panelSaveHighScore = new Panel();
            textBoxName = new TextBox();
            label1 = new Label();
            panelSaveHighScore.SuspendLayout();
            SuspendLayout();
            // 
            // lblGameOver
            // 
            lblGameOver.AutoSize = true;
            lblGameOver.BackColor = Color.Black;
            lblGameOver.Font = new Font("Consolas", 72F);
            lblGameOver.ForeColor = Color.White;
            lblGameOver.Location = new Point(103, 9);
            lblGameOver.Name = "lblGameOver";
            lblGameOver.Size = new Size(524, 112);
            lblGameOver.TabIndex = 19;
            lblGameOver.Text = "GAME OVER";
            // 
            // btnMenu
            // 
            btnMenu.AutoSize = true;
            btnMenu.BackColor = Color.Black;
            btnMenu.FlatAppearance.BorderColor = Color.Black;
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.Font = new Font("Consolas", 48F);
            btnMenu.ForeColor = Color.White;
            btnMenu.Location = new Point(12, 564);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(680, 85);
            btnMenu.TabIndex = 21;
            btnMenu.Text = "MENU";
            btnMenu.UseVisualStyleBackColor = false;
            btnMenu.Click += btnMenu_Click;
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.BackColor = Color.Black;
            btnSave.FlatAppearance.BorderColor = Color.Black;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font = new Font("Consolas", 48F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(12, 255);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(680, 85);
            btnSave.TabIndex = 20;
            btnSave.Text = "SAVE HIGHSCORE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // lblFinalScore
            // 
            lblFinalScore.AutoSize = true;
            lblFinalScore.BackColor = Color.Black;
            lblFinalScore.Font = new Font("Consolas", 48F);
            lblFinalScore.ForeColor = Color.White;
            lblFinalScore.Location = new Point(9, 121);
            lblFinalScore.Name = "lblFinalScore";
            lblFinalScore.Size = new Size(697, 75);
            lblFinalScore.TabIndex = 19;
            lblFinalScore.Text = "FINAL SCORE: 000000";
            // 
            // panelSaveHighScore
            // 
            panelSaveHighScore.Controls.Add(textBoxName);
            panelSaveHighScore.Controls.Add(label1);
            panelSaveHighScore.Controls.Add(btnSave);
            panelSaveHighScore.Location = new Point(0, 199);
            panelSaveHighScore.Name = "panelSaveHighScore";
            panelSaveHighScore.Size = new Size(706, 343);
            panelSaveHighScore.TabIndex = 22;
            panelSaveHighScore.Visible = false;
            // 
            // textBoxName
            // 
            textBoxName.BackColor = Color.Black;
            textBoxName.BorderStyle = BorderStyle.None;
            textBoxName.Font = new Font("Consolas", 36F);
            textBoxName.ForeColor = Color.White;
            textBoxName.Location = new Point(225, 112);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(431, 57);
            textBoxName.TabIndex = 24;
            textBoxName.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Black;
            label1.Font = new Font("Consolas", 48F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 97);
            label1.Name = "label1";
            label1.Size = new Size(207, 75);
            label1.TabIndex = 23;
            label1.Text = "NAME:";
            // 
            // GameOverForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(704, 661);
            Controls.Add(panelSaveHighScore);
            Controls.Add(btnMenu);
            Controls.Add(lblFinalScore);
            Controls.Add(lblGameOver);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GameOverForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tetris in WinForms";
            FormClosing += GameOverForm_FormClosing;
            panelSaveHighScore.ResumeLayout(false);
            panelSaveHighScore.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblGameOver;
        private Button btnMenu;
        private Button btnSave;
        private Label lblFinalScore;
        private Panel panelSaveHighScore;
        private Label label1;
        private TextBox textBoxName;
    }
}