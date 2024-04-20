using Assignment7.Properties;
using System.Media;

namespace Assignment7
{
    public partial class StartGameForm : Form
    {
        //Private fields
        private SoundPlayer player;

        //Flag to keep track if the close event should exit the application or just close the form
        private bool mExitApplication = true;

        public StartGameForm()
        {
            InitializeComponent();
            InitializeGUI();
        }

        /// <summary>
        /// Initializes the GUI
        /// </summary>
        private void InitializeGUI()
        {
            radioBtnMusicOn.Checked = true;
        }

        /// <summary>
        /// Return to the menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu_Click(object sender, EventArgs e)
        {
            mExitApplication = false;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Starts the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            //Make sure the level input is valid
            if (!ValidateInputs())
            {
                return;
            }

            //Use of the ternary opterator to check if music is on or off
            bool musicOn = radioBtnMusicOn.Checked ? true : false;

            Hide();
            GameForm gameForm = new GameForm(musicOn, int.Parse(textBoxLvl.Text));
            _ = gameForm.ShowDialog();
            player = new SoundPlayer(Music.TetrisTitleScreen);
            player.Play();
            Show();
        }

        /// <summary>
        /// Validates the level input
        /// </summary>
        /// <returns>True if valid, false otherwise</returns>
        private bool ValidateInputs()
        {
            int level;

            if (!int.TryParse(textBoxLvl.Text, out level))
            {
                MessageBox.Show("Invalid Level!");
                return false;
            }

            if (level < 0 || level > 29)
            {
                MessageBox.Show("Invalid Level!");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Override the FormClosing event to allow the user to exit the entire application on the Exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if the form is being closed by the close button
            if (mExitApplication)
            {
                Application.Exit();
            }
        }
    }
}
