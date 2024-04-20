using Assignment7.Properties;
using NAudio.Wave;
using System.Media;

namespace Assignment7
{
    public partial class GameForm : Form
    {
        //Fields
        //Constants
        private const int cDotSize = 32; //A block is 32 pixels big
        private const string cFileName = "TetrisScores.txt";

        //Game Box
        private const int cCanvasGameWidth = 10; //Game is 10 blocks wide
        private const int cCanvasGameHeight = 20; //Game is 20 block high
        private Bitmap mCanvasGameBitmap;
        private Graphics mCanvasGameGraphics;
        private SpriteModel[,] mCanvasGameArray;

        //Statistics Box
        private const int cCanvasStatisticsWidth = 5; //Statistics window is 10 blocks wide
        private const int cCanvasStatisticsHeight = 13; //Statistics window is 21 blocks high
        private Bitmap mCanvasStatisticsBitmap;
        private Graphics mCanvasStatisticsGraphics;

        //Next Shape Box
        private const int mCanvasNextShapeWidth = 6; //Next shape window is 6 blocks wide
        private const int mCanvasNextShapeHeight = 6; //Next shape window is 6 block high
        private Bitmap mCanvasNextShapeBitmap;
        private Graphics mCanvasNextShapeGraphics;

        //Statistics variables
        private int mShapeCountI = 0;
        private int mShapeCountO = 0;
        private int mShapeCountT = 0;
        private int mShapeCountL = 0;
        private int mShapeCountJ = 0;
        private int mShapeCountZ = 0;
        private int mShapeCountS = 0;
        private int mLineCount = 0;
        private int mLevel = 0;
        private int mTimerInterval;

        //Game fields
        private Bitmap mCurrentBitmap;
        private Graphics mCurrentGraphics;
        private ShapeModel mCurrentShape;
        private ShapeModel mNextShape;
        private bool mGameIsPaused = false;

        //Music variables
        private SoundPlayer mPlayer;
        private bool mPlayFastMusic = false;
        private bool mMusicOn = true;

        //Score variables
        private int mScore = 0;
        private List<ScoreModel> mScores;
        private FileManager mFileManager;

        public GameForm(bool aMusicOn, int aStartLvl)
        {
            InitializeComponent();

            //Set the music & startlvl field field
            mMusicOn = aMusicOn;
            mLevel = aStartLvl;

            //Initialize the FileManager class, Scores List and Timer
            mFileManager = new FileManager();
            mScores = new List<ScoreModel>();

            //Helper method to initialize the GUI
            InitializeGame();

            //Get the shapes
            mCurrentShape = GetRandomShape();
            mNextShape = GetNextShape();

            //Set the interval of the timer & start it
            timer.Interval = SetSpeedForLevel();
            timer.Start();
        }



        #region Updates
        /// <summary>
        /// Updates the statistics window. Uses a switch for the currentshape to know which label to update.
        /// </summary>
        private void UpdateStatistics()
        {
            switch (mCurrentShape.Name)
            {
                case "I":
                    mShapeCountI++;
                    lblShapeICount.Text = mShapeCountI.ToString("000");
                    break;
                case "O":
                    mShapeCountO++;
                    lblShapeOCount.Text = mShapeCountO.ToString("000");
                    break;
                case "T":
                    mShapeCountT++;
                    lblShapeTCount.Text = mShapeCountT.ToString("000");
                    break;
                case "L":
                    mShapeCountL++;
                    lblShapeLCount.Text = mShapeCountL.ToString("000");
                    break;
                case "J":
                    mShapeCountJ++;
                    lblShapeJCount.Text = mShapeCountJ.ToString("000");
                    break;
                case "Z":
                    mShapeCountZ++;
                    lblShapeZCount.Text = mShapeCountZ.ToString("000");
                    break;
                case "S":
                    mShapeCountS++;
                    lblShapeSCount.Text = mShapeCountS.ToString("000");
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Updates the score
        /// </summary>
        /// <param name="aRowsCleared">How many rows that were cleared</param>
        private void UpdateScore(int aRowsCleared)
        {
            //Update Line Count
            mLineCount += aRowsCleared;
            lblLines.Text = mLineCount.ToString("000");

            //Update score
            int sScoreMultiplier = 0;
            if (aRowsCleared == 1) sScoreMultiplier = 40;
            else if (aRowsCleared == 2) sScoreMultiplier = 100;
            else if (aRowsCleared == 3) sScoreMultiplier = 300;
            else if (aRowsCleared == 4) sScoreMultiplier = 1200;

            mScore += sScoreMultiplier * (mLevel + 1);
            lblScore.Text = mScore.ToString("000000");

            //Level up if 10 lines is done
            if (mLineCount % 10 == 0)
            {
                LevelUp();
            }
        }

        /// <summary>
        /// Set the game array to one (fill the blocks) where the shape is
        /// </summary>
        private void UpdateGameArray()
        {
            //Iterate through the width of the shape
            for (int x = 0; x < mCurrentShape.Width; x++)
            {
                //Iterate through the height of the shape
                for (int y = 0; y < mCurrentShape.Height; y++)
                {
                    //If the shape has a block there (1 == block, 0 == empty)
                    if (mCurrentShape.Pixels[y, x] != null)
                    {
                        //Check if the game is over (the shape is above the game array)
                        CheckIfGameIsOver();

                        //If not, paint the array there
                        mCanvasGameArray[mCurrentShape.PositionX + x, mCurrentShape.PositionY + y] = new SpriteModel(mCurrentShape.Color);
                    }
                }
            }
        }
        #endregion



        #region Input
        /// <summary>
        /// Get player input and move the shape accordingly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            //Dont allow movement when paused
            if (mGameIsPaused && e.KeyCode != Keys.Enter) return;

            //Variables for moving the shape
            int xMove = 0;
            int yMove = 0;

            //Get the input
            switch (e.KeyCode)
            {
                case (Keys.Left):
                    xMove = -1;
                    break;
                case (Keys.Right):
                    xMove = 1;
                    break;
                case (Keys.Down):
                    yMove = 1;
                    break;
                case (Keys.Z):
                    mCurrentShape.RotateShapeCounterClockWise();
                    break;
                case (Keys.X):
                    mCurrentShape.RotateShapeClockWise();
                    break;
                case (Keys.Enter):
                    PauseGame();
                    break;
                default:
                    break;
            }

            bool successfulMove = MoveShape(yMove, xMove);

            //If the move was unsuccessful and the player tried to rotate the shape, revert it
            if (!successfulMove && (e.KeyCode == Keys.X || e.KeyCode == Keys.Z))
            {
                mCurrentShape.SetShapeToOldDots();
            }
            else if (successfulMove && (e.KeyCode == Keys.X || e.KeyCode == Keys.Z) && mCurrentShape.Name != "O")
            {
                //If the move was successful and it was a rotation: play sound effect
                PlaySoundEffect(SoundEffects.RotateShape);
            }
        }

        /// <summary>
        /// Pauses/unpauses the game
        /// </summary>
        private void PauseGame()
        {
            //If the game is currently paused, unpause it
            if (mGameIsPaused)
            {
                panelPaused.Visible = false;
                PlaySoundEffect(SoundEffects.RotateShape);
                if (mMusicOn)
                {
                    mPlayer.PlayLooping();
                }
                mGameIsPaused = false;
                timer.Start();
            }
            else
            {
                //If the game is not paused, pause it
                timer.Stop();
                mPlayer.Stop();
                PlaySoundEffect(SoundEffects.RotateShape);
                panelPaused.Visible = true;
                mGameIsPaused = true;
            }
        }
        #endregion



        #region Game Mechanics
        /// <summary>
        /// Function that executes for every tick of the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void TimerTick(object sender, EventArgs eventArgs)
        {
            //Check if the shape reached the bottom or touched any other shapes
            bool successfulMove = MoveShape(1, 0);

            if (!successfulMove)
            {
                //Update the graphics
                mCanvasGameBitmap = new Bitmap(mCurrentBitmap);

                UpdateGameArray();

                UpdateStatistics();

                mCurrentShape = mNextShape;
                mNextShape = GetNextShape();

                //Check if any rows were filled
                CheckRows();

                //Check the height (to adjust the music if needed)
                if (mMusicOn)
                {
                    CheckHeightForMusic();
                }
            }
        }

        /// <summary>
        /// Moves the shape
        /// </summary>
        /// <param name="moveDown">0 = don't move, 1 = down</param>
        /// <param name="moveSide">-1 = left, 0 = don't move, 1 = right</param>
        /// <returns>False if collision, true if not</returns>
        private bool MoveShape(int moveDown, int moveSide)
        {
            //Get the new position of the shape
            int newPosX = mCurrentShape.PositionX + moveSide;
            int newPosY = mCurrentShape.PositionY + moveDown;

            //Check if the shape will the bottom or side
            if (newPosX < 0 || newPosX + mCurrentShape.Width > cCanvasGameWidth || newPosY + mCurrentShape.Height > cCanvasGameHeight)
            {
                return false;
            }

            //Check if it touches any other blocks already positioned
            for (int x = 0; x < mCurrentShape.Width; x++)
            {
                for (int y = 0; y < mCurrentShape.Height; y++)
                {
                    if (newPosY + y > 0 && mCanvasGameArray[newPosX + x, newPosY + y] != null && mCurrentShape.Pixels[y, x] != null)
                    {
                        return false;
                    }
                }
            }

            //Set the new position of the shape
            mCurrentShape.PositionX = newPosX;
            mCurrentShape.PositionY = newPosY;

            //Play sound effect if we move sideways
            if (moveSide != 0)
            {
                PlaySoundEffect(SoundEffects.MoveShapeSound);
            }

            DrawShape();

            return true;
        }

        /// <summary>
        /// Gets the next shape and draws it in the canvas
        /// </summary>
        /// <returns>The next shape</returns>
        private ShapeModel GetNextShape()
        {
            //Get a random shape
            ShapeModel shape = GetRandomShape();

            //Clear the next shape canvas
            mCanvasNextShapeGraphics.FillRectangle(Brushes.Black, 0, 0, mCanvasNextShapeBitmap.Width, mCanvasNextShapeBitmap.Height);

            //Get the center of the Next Shape Canvas
            int posX = (mCanvasNextShapeWidth - shape.Width) / 2;
            int posY = (mCanvasNextShapeHeight + 2 - shape.Height) / 2;

            //Draw the shape in the canvas
            for (int x = 0; x < shape.Width; x++)
            {
                for (int y = 0; y < shape.Height; y++)
                {
                    if (shape.Pixels[y, x] != null)
                    {
                        Bitmap sprite = GetSprite(shape.Color);
                        mCanvasNextShapeGraphics.DrawImage(sprite, (posX + x) * cDotSize, (posY + y) * cDotSize, cDotSize, cDotSize);
                    }
                }
            }

            //Set the picture box to contain the canvas
            pictureBoxNext.Image = mCanvasNextShapeBitmap;

            return shape;
        }

        /// <summary>
        /// Gets a random shape
        /// </summary>
        /// <returns>A shape</returns>
        private ShapeModel GetRandomShape()
        {
            //Get a random shape with a random color
            ShapeModel shape = ShapeCreator.GetRandomShape();

            shape.PositionX = cCanvasGameWidth / 2; //Set the X position to the middle
            shape.PositionY = -shape.Height; //Set Y position to negative the shapes height (so it starts above the game window)

            return shape;
        }

        /// <summary>
        /// Starting from the top, check if any rows are filled. And if so, remove them, update the score
        /// </summary>
        private void CheckRows()
        {
            //Flag to keep track of if we have to update the graphics
            int rowsCleared = 0;

            //Look through all rows and see if any is filled
            for (int y = 0; y < cCanvasGameHeight; y++)
            {
                bool rowIsFilled = true;
                for (int x = 0; x < cCanvasGameWidth; x++)
                {
                    //If it's 0, break, the row is n
                    if (mCanvasGameArray[x, y] == null)
                    {
                        rowIsFilled = false;
                    }
                }

                if (rowIsFilled)
                {
                    rowsCleared++;
                    //Update the array
                    for (int x = 0; x < cCanvasGameWidth; x++)
                    {
                        //Start at the current height
                        for (int y2 = y; y2 > 0; y2--)
                        {
                            mCanvasGameArray[x, y2] = mCanvasGameArray[x, y2 - 1];
                        }
                        mCanvasGameArray[x, 0] = null;
                    }
                }
            }

            //If any row was cleared, we have to update the graphics
            if (rowsCleared > 0)
            {
                for (int x = 0; x < cCanvasGameWidth; x++)
                {
                    for (int y = 0; y < cCanvasGameHeight; y++)
                    {
                        mCanvasGameGraphics = Graphics.FromImage(mCanvasGameBitmap);
                        if (mCanvasGameArray[x, y] == null)
                        {
                            mCanvasGameGraphics.FillRectangle(Brushes.Black, x * cDotSize, y * cDotSize, cDotSize, cDotSize);
                        }
                        else
                        {
                            Bitmap bitmap = GetSprite(mCanvasGameArray[x, y].Color);
                            mCanvasGameGraphics.DrawImage(bitmap, x * cDotSize, y * cDotSize, cDotSize, cDotSize);
                        }
                    }
                }

                pictureBoxGame.Image = mCanvasGameBitmap;

                //Play the sound for either tetris or row cleared
                if (rowsCleared >= 4)
                {
                    PlaySoundEffect(SoundEffects.Tetris);
                }
                else
                {
                    PlaySoundEffect(SoundEffects.RowsCleared);
                }

                UpdateScore(rowsCleared);
            }
            else
            {
                //Play sound for landed shape
                PlaySoundEffect(SoundEffects.ShapeLanded);
            }
        }

        /// <summary>
        /// Play sound effect, increase the level label and the speed
        /// </summary>
        private void LevelUp()
        {
            //Play sound effect
            PlaySoundEffect(SoundEffects.LevelUpSound);

            //Increase the level
            mLevel++;
            lblLevel.Text = mLevel.ToString("00");

            //Set the speed
            SetSpeedForLevel();
        }

        /// <summary>
        /// Checks if the game is over, restarts the application
        /// </summary>
        private void CheckIfGameIsOver()
        {
            if (mCurrentShape.PositionY < 0)
            {
                StopMusic();
                PlaySoundEffect(SoundEffects.GameOverSound);
                timer.Stop();

                bool sAskUserForHighScore = false;

                //If the number of high scores is less than 5, or if the player scored higher than the lowest of the 5 saved (a non zero score), the user will be asked to enter their name
                if(mScores.Count < 5 && mScore > 0)
                {
                    sAskUserForHighScore = true;
                }
                else if(mScores.Min(x => x.Score) < mScore && mScore > 0)
                {
                    sAskUserForHighScore = true;
                }

                Hide();
                GameOverForm sGameOverForm = new GameOverForm(mScore, sAskUserForHighScore);
                sGameOverForm.Show();
                Close();
            }
        }
        #endregion



        #region Graphics
        /// <summary>
        /// Draws the shape on the graphics in the bitmap
        /// </summary>
        private void DrawShape()
        {
            mCurrentBitmap = new Bitmap(mCanvasGameBitmap);
            mCurrentGraphics = Graphics.FromImage(mCurrentBitmap);

            for (int x = 0; x < mCurrentShape.Width; x++)
            {
                for (int y = 0; y < mCurrentShape.Height; y++)
                {
                    if (mCurrentShape.Pixels[y, x] != null)
                    {
                        Bitmap bitmap = GetSprite(mCurrentShape.Color);
                        mCurrentGraphics.DrawImage(bitmap, (mCurrentShape.PositionX + x) * cDotSize, (mCurrentShape.PositionY + y) * cDotSize, cDotSize, cDotSize);
                    }
                }
            }

            pictureBoxGame.Image = mCurrentBitmap;
        }

        private void DrawShape(ShapeModel shape, int yPos, int xPos)
        {
            //Draw the shape in the canvas
            for (int x = 0; x < shape.Width; x++)
            {
                for (int y = 0; y < shape.Height; y++)
                {
                    if (shape.Pixels[y, x] != null)
                    {
                        Bitmap sprite = GetSprite(shape.Color);
                        mCanvasStatisticsGraphics.DrawImage(sprite, (xPos + x) * cDotSize / 2, (yPos + y) * cDotSize / 2, cDotSize / 2, cDotSize / 2);
                    }
                }
            }

            //Set the picture box to contain the canvas
            pictureBoxStatistics.Image = mCanvasStatisticsBitmap;
        }
        #endregion



        #region Helper Methods
        /// <summary>
        /// Returns the correct sprite
        /// </summary>
        /// <param name="color">The color of the shape</param>
        /// <returns>The sprite as a bitmap</returns>
        private Bitmap GetSprite(Color color)
        {
            if (color == Color.Blue)
            {
                return Sprites.BlueSprite;
            }
            else if (color == Color.Green)
            {
                return Sprites.GreenSprite;
            }
            else if (color == Color.Orange)
            {
                return Sprites.OrangeSprite;
            }
            else if (color == Color.Purple)
            {
                return Sprites.PurpleSprite;
            }
            else if (color == Color.Red)
            {
                return Sprites.RedSprite;
            }
            else if (color == Color.Yellow)
            {
                return Sprites.YellowSprite;
            }
            else
            {
                return Sprites.GreenSprite;
            }
        }

        /// <summary>
        /// Calculates the interval for the timer, depending on which level the game is on
        /// </summary>
        /// <returns>The interval for the timer</returns>
        private int SetSpeedForLevel()
        {
            //The starting framesPerMove is 48 in the original Tetris
            int framesPerMove = 48;

            if (mLevel >= 0 && mLevel <= 8)
            {
                framesPerMove -= mLevel * 5;
            }
            else if (mLevel == 9)
            {
                framesPerMove = 6;
            }
            else if (mLevel > 9 && mLevel <= 12)
            {
                framesPerMove = 5;
            }
            else if (mLevel > 12 && mLevel <= 15)
            {
                framesPerMove = 4;
            }
            else if (mLevel > 15 && mLevel <= 18)
            {
                framesPerMove = 3;
            }
            else if (mLevel > 18 && mLevel <= 28)
            {
                framesPerMove = 2;
            }
            else
            {
                framesPerMove = 1;
            }

            //We multiply by a thousand (since the timer uses ms), and divide by 60. Since the original Tetris was made for 60fps
            return framesPerMove * 1000 / 60;
        }
        #endregion



        #region Game Initialization
        /// <summary>
        /// Calls helper functions to initialize the Game
        /// </summary>
        private void InitializeGame()
        {
            InitializeGameBox();
            InitializeStatisticsBox();
            InitializeNextShapeBox();
            ReadHighScoreList();
            InitializeMusic();

            //Set level text 
            lblLevel.Text = mLevel.ToString("00");
        }

        /// <summary>
        /// Initializes the game PictureBox, Bitmap and array
        /// </summary>
        private void InitializeGameBox()
        {
            //Set all pictures boxes to the set width and height
            pictureBoxGame.Width = cCanvasGameWidth * cDotSize;
            pictureBoxGame.Height = cCanvasGameHeight * cDotSize;

            //Create Bitmap with picture box's size
            mCanvasGameBitmap = new Bitmap(pictureBoxGame.Width, pictureBoxGame.Height);
            mCanvasGameGraphics = Graphics.FromImage(mCanvasGameBitmap);
            mCanvasGameGraphics.FillRectangle(Brushes.Black, 0, 0, mCanvasGameBitmap.Width, mCanvasGameBitmap.Height);

            //Set the bitmap to the picturebox
            pictureBoxGame.Image = mCanvasGameBitmap;

            //Initialize canvas dot array
            mCanvasGameArray = new SpriteModel[cCanvasGameWidth, cCanvasGameHeight];
        }

        /// <summary>
        /// Initializes the "Next Shape" PictureBox & Bitmap
        /// </summary>
        private void InitializeNextShapeBox()
        {
            //Set all pictures boxes to the set width and height
            pictureBoxNext.Width = mCanvasNextShapeWidth * cDotSize;
            pictureBoxNext.Height = mCanvasNextShapeHeight * cDotSize;

            //Create Bitmap with picture box's size
            mCanvasNextShapeBitmap = new Bitmap(pictureBoxNext.Width, pictureBoxNext.Height);
            mCanvasNextShapeGraphics = Graphics.FromImage(mCanvasNextShapeBitmap);
            mCanvasNextShapeGraphics.FillRectangle(Brushes.Black, 0, 0, mCanvasNextShapeBitmap.Width, mCanvasNextShapeBitmap.Height);

            //Set the bitmap to the picturebox
            pictureBoxNext.Image = mCanvasNextShapeBitmap;
        }

        /// <summary>
        /// Initializes the Statistics Box PictureBox & Bitmap
        /// </summary>
        private void InitializeStatisticsBox()
        {
            //Set all pictures boxes to the set width and height
            pictureBoxStatistics.Width = cCanvasStatisticsWidth * cDotSize;
            pictureBoxStatistics.Height = cCanvasStatisticsHeight * cDotSize;

            //Create Bitmap with picture box's size
            mCanvasStatisticsBitmap = new Bitmap(pictureBoxStatistics.Width, pictureBoxStatistics.Height);
            mCanvasStatisticsGraphics = Graphics.FromImage(mCanvasStatisticsBitmap);
            mCanvasStatisticsGraphics.FillRectangle(Brushes.Black, 0, 0, mCanvasStatisticsBitmap.Width, mCanvasStatisticsBitmap.Height);

            //Set the bitmap to the picturebox
            pictureBoxStatistics.Image = mCanvasStatisticsBitmap;

            //Draw all shapes
            DrawShapesStatistics();
        }

        /// <summary>
        /// Initializes the music with a helper function
        /// </summary>
        private void InitializeMusic()
        {
            if (mMusicOn)
            {
                PlayMusic(Music.Tetris);
            }
            else
            {
                StopMusic();
            }
        }

        /// <summary>
        /// Draws every shape in the statistics box
        /// </summary>
        private void DrawShapesStatistics()
        {
            //Get all shapes to show in the statistics, in the following order
            ShapeModel[] shapes =
            {
                ShapeCreator.GetShapeByName("T"),
                ShapeCreator.GetShapeByName("J"),
                ShapeCreator.GetShapeByName("Z"),
                ShapeCreator.GetShapeByName("O"),
                ShapeCreator.GetShapeByName("S"),
                ShapeCreator.GetShapeByName("L"),
                ShapeCreator.GetShapeByName("I"),
            };

            //Draw each shape with the helper method
            for (int i = 0; i < shapes.Length; i++)
            {
                //Draw I with larger margin
                if (shapes[i].Name == "I")
                {
                    DrawShape(shapes[i], 5 + i * 3, 1);
                }
                else
                {
                    DrawShape(shapes[i], 4 + i * 3, 2);
                }
            }
        }

        /// <summary>
        /// Reads the high score list, and sets the high score to the highest score
        /// </summary>
        private void ReadHighScoreList()
        {
            //Try to read the high score file
            if (!mFileManager.ReadScoreListFromFile(mScores, cFileName))
            {
                MessageBox.Show("An error occured! Could not read the high scores file!", "Error");
                Application.Exit();
            }

            //Update the high score on the GUI
            if (mScores.Count > 0)
            {
                mScores = mScores.OrderByDescending(x => x.Score).ToList();
                lblHighScore.Text = mScores.First().Score.ToString("000000");
            }
        }
        #endregion



        #region Audio
        /// <summary>
        /// Plays the specified sound effect
        /// </summary>
        /// <param name="stream">The sound to play</param>
        private void PlaySoundEffect(Stream stream)
        {
            try
            {
                //Convert stream to byte array and set position to start
                MemoryStream sMemoryStream = new MemoryStream();
                stream.CopyTo(sMemoryStream);
                sMemoryStream.Position = 0;

                //Use NAudio to play the sound effect (as SoundPlayer doesn't allow multiple sounds at once)
                WaveOutEvent waveOutEvent = new WaveOutEvent();
                waveOutEvent.Init(new WaveFileReader(sMemoryStream));
                waveOutEvent.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error at PlaySoundEffect()");
                Application.Exit();
            }
        }

        /// <summary>
        /// Stops the music
        /// </summary>
        private void StopMusic()
        {
            SoundPlayer player = new SoundPlayer();
            player.Stop();
            player.Dispose();
        }

        /// <summary>
        /// Plays the specified music in a loop
        /// </summary>
        /// <param name="stream"></param>
        private void PlayMusic(Stream stream)
        {
            //Play the music in a loop
            mPlayer = new SoundPlayer(stream);
            mPlayer.PlayLooping();
        }

        /// <summary>
        /// Checks if the shapes have reached a specified height, and if so, plays the faster music
        /// </summary>
        private void CheckHeightForMusic()
        {
            for (int x = 0; x < cCanvasGameWidth; x++)
            {
                //Check if there is any block at level height 6
                if (mCanvasGameArray[x, 6] != null)
                {
                    //Only play the fast music if it's not already playing
                    if (!mPlayFastMusic)
                    {
                        mPlayFastMusic = true;
                        PlayMusic(Music.TetrisFast);
                        return;
                    }
                    //If it is playing, return
                    return;
                }
            }

            //If there is no block at height 6, play normal music
            if (mPlayFastMusic)
            {
                mPlayFastMusic = false;
                PlayMusic(Music.Tetris);
            }
        }
        #endregion
    }
}
