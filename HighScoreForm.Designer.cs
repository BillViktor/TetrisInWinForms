namespace Assignment7
{
    partial class HighScoreForm
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
            btnMenu = new Button();
            btnReset = new Button();
            lblHighScores = new Label();
            lblScore = new Label();
            lblName = new Label();
            listBoxHighScores = new ListBox();
            SuspendLayout();
            // 
            // btnMenu
            // 
            btnMenu.AutoSize = true;
            btnMenu.BackColor = Color.Black;
            btnMenu.FlatAppearance.BorderColor = Color.Black;
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.Font = new Font("Consolas", 48F);
            btnMenu.ForeColor = Color.White;
            btnMenu.Location = new Point(365, 564);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(330, 85);
            btnMenu.TabIndex = 16;
            btnMenu.Text = "MENU";
            btnMenu.UseVisualStyleBackColor = false;
            btnMenu.Click += btnMenu_Click;
            // 
            // btnReset
            // 
            btnReset.AutoSize = true;
            btnReset.BackColor = Color.Black;
            btnReset.FlatAppearance.BorderColor = Color.Black;
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.Font = new Font("Consolas", 48F);
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(12, 564);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(330, 85);
            btnReset.TabIndex = 15;
            btnReset.Text = "RESET";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // lblHighScores
            // 
            lblHighScores.AutoSize = true;
            lblHighScores.BackColor = Color.Black;
            lblHighScores.Font = new Font("Consolas", 72F);
            lblHighScores.ForeColor = Color.White;
            lblHighScores.Location = new Point(44, 9);
            lblHighScores.Name = "lblHighScores";
            lblHighScores.Size = new Size(630, 112);
            lblHighScores.TabIndex = 18;
            lblHighScores.Text = "HIGH SCORES";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.BackColor = Color.Black;
            lblScore.Font = new Font("Consolas", 32F);
            lblScore.ForeColor = Color.White;
            lblScore.Location = new Point(104, 194);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(142, 51);
            lblScore.TabIndex = 17;
            lblScore.Text = "SCORE";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = Color.Black;
            lblName.Font = new Font("Consolas", 32F);
            lblName.ForeColor = Color.White;
            lblName.Location = new Point(365, 194);
            lblName.Name = "lblName";
            lblName.Size = new Size(118, 51);
            lblName.TabIndex = 17;
            lblName.Text = "NAME";
            // 
            // listBoxHighScores
            // 
            listBoxHighScores.BackColor = Color.Black;
            listBoxHighScores.Font = new Font("Consolas", 32F);
            listBoxHighScores.ForeColor = Color.White;
            listBoxHighScores.FormattingEnabled = true;
            listBoxHighScores.ItemHeight = 51;
            listBoxHighScores.Location = new Point(12, 248);
            listBoxHighScores.Name = "listBoxHighScores";
            listBoxHighScores.Size = new Size(680, 310);
            listBoxHighScores.TabIndex = 19;
            // 
            // HighScoreForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(704, 661);
            Controls.Add(listBoxHighScores);
            Controls.Add(lblHighScores);
            Controls.Add(lblName);
            Controls.Add(lblScore);
            Controls.Add(btnMenu);
            Controls.Add(btnReset);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "HighScoreForm";
            Text = "HighScoreForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnMenu;
        private Button btnReset;
        private Label lblHighScores;
        private Label lblScore;
        private Label lblName;
        private ListBox listBoxHighScores;
    }
}