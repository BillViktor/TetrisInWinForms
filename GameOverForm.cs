using Assignment7.Classes;
using Assignment7.Models;

namespace Assignment7
{
    public partial class GameOverForm : Form
    {
        //Fields
        private const string cFileName = "TetrisScores.txt";

        private int mScore;
        private bool mAskUserForHighScore;

        //Flag to keep track if the close event should exit the application or just close the form
        private bool mExitApplication = true;

        public GameOverForm(int aScore, bool aAskUserForHighScore)
        {
            InitializeComponent();

            mScore = aScore;
            mAskUserForHighScore = aAskUserForHighScore;

            InitializeGUI();
        }

        /// <summary>
        /// Initializes the GUI
        /// </summary>
        private void InitializeGUI()
        {
            lblFinalScore.Text = $"FINAL SCORE: {mScore.ToString("000000")}";

            if (mAskUserForHighScore)
            {
                panelSaveHighScore.Show();
            }
        }

        /// <summary>
        /// Returns back to the menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu_Click(object sender, EventArgs e)
        {
            mExitApplication = false;
            Close();
        }


        /// <summary>
        /// Saves the high score and closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //Input validation
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Invalid Name Input!", "Error");
                return;
            }

            //Initialize the file manager and create a score list
            List<ScoreModel> sScores = new List<ScoreModel>();
            FileManager sFileManager = new FileManager();

            //Load the score list
            if (!sFileManager.ReadScoreListFromFile(sScores, cFileName))
            {
                MessageBox.Show("Could not load high score list!", "Error");
                Application.Exit();
            }

            //If the count is 5 or greater, remove the least scores
            if (sScores.Count >= 5)
            {
                sScores = sScores.OrderByDescending(x => x.Score).Take(4).ToList();
            }

            //Create the Score Model
            ScoreModel sScore = new ScoreModel(textBoxName.Text, mScore);

            //Add the score
            sScores.Add(sScore);

            //Save the score
            if (!sFileManager.SaveScoreListToFile(sScores, cFileName))
            {
                MessageBox.Show("Could not save high score list!", "Error");
                Application.Exit();
            }

            mExitApplication = false;

            //Close the form
            Close();
        }

        /// <summary>
        /// Override the FormClosing event to allow the user to exit the entire application on the Exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameOverForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if the form is being closed by the close button
            if (mExitApplication)
            {
                Application.Exit();
            }
        }
    }
}
