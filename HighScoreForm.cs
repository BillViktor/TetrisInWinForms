namespace Assignment7
{
    public partial class HighScoreForm : Form
    {
        //Const string for filename
        private const string cFileName = "TetrisScores.txt";

        //Fields
        private FileManager mFileManager;
        private List<ScoreModel> mScores;

        //Flag to keep track if the close event should exit the application or just close the form
        private bool mExitApplication = true;

        public HighScoreForm()
        {
            InitializeComponent();

            mScores = new List<ScoreModel>();
            mFileManager = new FileManager();

            ReadHighScoreFile();
        }

        /// <summary>
        /// Reads the high score list to the List<ScoreModel>
        /// </summary>
        private void ReadHighScoreFile()
        {
            if (!mFileManager.ReadScoreListFromFile(mScores, cFileName))
            {
                MessageBox.Show("An error occured! Could not read the high scores file!", "Error");
                return;
            }

            //Show the scores
            PrintHighScores();
        }

        /// <summary>
        /// Adds the scores in the list to the listbox
        /// </summary>
        private void PrintHighScores()
        {
            //Clear the listbox
            listBoxHighScores.Items.Clear();

            //Order the list by the highest score
            mScores = mScores.OrderByDescending(x => x.Score).ToList();

            //Add each score to the list
            for (int i = 0; i < mScores.Count; i++)
            {
                //We only show the 5 best scores
                if (i == 5) break;

                listBoxHighScores.Items.Add(string.Format("{0, -3} {1, 0}", i + 1, mScores[i].ToString()));
            }
        }

        /// <summary>
        /// Closes the high score form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu_Click(object sender, EventArgs e)
        {
            mExitApplication = false;
            Close();
        }

        /// <summary>
        /// Resets the high score list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            mScores = new List<ScoreModel>();

            if (!mFileManager.SaveScoreListToFile(mScores, cFileName))
            {
                MessageBox.Show("An error occured! Could not reset the high scores list!", "Error");
                Application.Exit();
            }
            else
            {
                PrintHighScores();
            }
        }

        /// <summary>
        /// Override the FormClosing event to allow the user to exit the entire application on the Exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HighScoreForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if the form is being closed by the close button
            if (mExitApplication)
            {
                Application.Exit();
            }
        }
    }
}
