namespace Assignment7
{
    partial class MenuForm
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
            lblTetris = new Label();
            btnPlay = new Button();
            lblMadeBy = new Label();
            btnHighScores = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // lblTetris
            // 
            lblTetris.AutoSize = true;
            lblTetris.BackColor = Color.Black;
            lblTetris.Font = new Font("Consolas", 96F);
            lblTetris.ForeColor = Color.White;
            lblTetris.Location = new Point(107, 63);
            lblTetris.Name = "lblTetris";
            lblTetris.Size = new Size(483, 150);
            lblTetris.TabIndex = 10;
            lblTetris.Text = "TETRIS";
            // 
            // btnPlay
            // 
            btnPlay.AutoSize = true;
            btnPlay.BackColor = Color.Black;
            btnPlay.FlatAppearance.BorderColor = Color.Black;
            btnPlay.FlatAppearance.BorderSize = 0;
            btnPlay.Font = new Font("Consolas", 48F);
            btnPlay.ForeColor = Color.White;
            btnPlay.Location = new Point(251, 291);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(182, 85);
            btnPlay.TabIndex = 11;
            btnPlay.Text = "PLAY";
            btnPlay.UseVisualStyleBackColor = false;
            btnPlay.Click += btnPlay_Click;
            // 
            // lblMadeBy
            // 
            lblMadeBy.AutoSize = true;
            lblMadeBy.BackColor = Color.Black;
            lblMadeBy.Font = new Font("Consolas", 24F);
            lblMadeBy.ForeColor = Color.White;
            lblMadeBy.Location = new Point(168, 199);
            lblMadeBy.Name = "lblMadeBy";
            lblMadeBy.Size = new Size(359, 37);
            lblMadeBy.TabIndex = 10;
            lblMadeBy.Text = "Made By Viktor Bill";
            // 
            // btnHighScores
            // 
            btnHighScores.AutoSize = true;
            btnHighScores.BackColor = Color.Black;
            btnHighScores.FlatAppearance.BorderColor = Color.Black;
            btnHighScores.FlatAppearance.BorderSize = 0;
            btnHighScores.Font = new Font("Consolas", 48F);
            btnHighScores.ForeColor = Color.White;
            btnHighScores.Location = new Point(141, 410);
            btnHighScores.Name = "btnHighScores";
            btnHighScores.Size = new Size(427, 85);
            btnHighScores.TabIndex = 11;
            btnHighScores.Text = "HIGH SCORES";
            btnHighScores.UseVisualStyleBackColor = false;
            btnHighScores.Click += btnHighScores_Click;
            // 
            // btnExit
            // 
            btnExit.AutoSize = true;
            btnExit.BackColor = Color.Black;
            btnExit.FlatAppearance.BorderColor = Color.Black;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.Font = new Font("Consolas", 48F);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(251, 528);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(182, 85);
            btnExit.TabIndex = 11;
            btnExit.Text = "EXIT";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(704, 661);
            Controls.Add(btnHighScores);
            Controls.Add(btnExit);
            Controls.Add(btnPlay);
            Controls.Add(lblMadeBy);
            Controls.Add(lblTetris);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tetris in WinForms";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTetris;
        private Button btnPlay;
        private Label lblMadeBy;
        private Button btnHighScores;
        private Button btnExit;
    }
}