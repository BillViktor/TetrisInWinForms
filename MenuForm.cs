using System.Media;

namespace Assignment7
{
    public partial class MenuForm : Form
    {
        //Private fields
        private SoundPlayer player;

        public MenuForm()
        {
            InitializeComponent();
            PlayMusic(Properties.Music.TetrisTitleScreen);
        }

        /// <summary>
        /// Start the menu music in a loop
        /// </summary>
        /// <param name="stream"></param>
        private void PlayMusic(Stream stream)
        {
            //Play the music in a loop
            player = new SoundPlayer(stream);
            player.PlayLooping();
        }

        /// <summary>
        /// Opens the StartGameForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlay_Click(object sender, EventArgs e)
        {
            Hide();
            StartGameForm startGameForm = new StartGameForm();
            _ = startGameForm.ShowDialog();
            Show();
        }

        /// <summary>
        /// Shows the high scores form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHighScores_Click(object sender, EventArgs e)
        {
            Hide();
            HighScoreForm highScoreForm = new HighScoreForm();
            highScoreForm.ShowDialog();
            Show();
        }

        /// <summary>
        /// Exits the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
