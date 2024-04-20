namespace Assignment7
{
    public class FileManager
    {
        //Token to identify the file to this application, as well as a file version nr
        private const string cFileVersionToken = "TetrisViBi_24";
        private const double cFileVersionNr = 1.0;

        /// <summary>
        /// Saves a list of scores to a .txt file
        /// </summary>
        /// <param name="aScoreList">The list of scores to save</param>
        /// <param name="aFileName">The name of the file to save</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool SaveScoreListToFile(List<ScoreModel> aScoreList, string aFileName)
        {
            bool ok = true;
            StreamWriter streamWriter = null;

            try
            {
                streamWriter = new StreamWriter(aFileName);

                //Write the token & file version & task count
                streamWriter.WriteLine(cFileVersionToken);
                streamWriter.WriteLine(cFileVersionNr);
                streamWriter.WriteLine(aScoreList.Count);

                //Write all the scores, one score per line, seperate each values by a tab
                for (int i = 0; i < aScoreList.Count; i++)
                {
                    streamWriter.WriteLine($"{aScoreList[i].Name}\t{aScoreList[i].Score}");
                }
            }
            catch 
            {
                ok = false;
            }
            finally
            {
                //Close the Streamwriter
                if (streamWriter != null)
                {
                    streamWriter.Close();
                }
            }
            return ok;
        }

        /// <summary>
        /// Reads a .txt file of scores and adds them to a list
        /// </summary>
        /// <param name="aScoreList">The list to fill with scores</param>
        /// <param name="aFileName">The name of the file to read</param>
        /// <returns>True if succesful, false otherwise</returns>
        public bool ReadScoreListFromFile(List<ScoreModel> aScoreList, string aFileName)
        {
            bool ok = true;
            StreamReader streamReader = null;
            try
            {
                //Clear the list
                aScoreList.Clear();

                streamReader = new StreamReader(aFileName);

                //Check version and token
                string fileToken = streamReader.ReadLine();
                double fileNr = double.Parse(streamReader.ReadLine());

                //Check the file version token and number before proceeding
                if (fileToken == cFileVersionToken && fileNr == cFileVersionNr)
                {
                    //Read the number of scores
                    int scoreCount = int.Parse(streamReader.ReadLine());

                    //Loop through each score
                    for (int i = 0; i < scoreCount; i++)
                    {
                        //Read the next line, save into string array by splitting with tabs (since we wrote with tabs)
                        string scoreString = streamReader.ReadLine();
                        string[] scoreParts = scoreString.Split("\t");

                        //Create the score, add it to the list
                        ScoreModel score = new ScoreModel(scoreParts[0], int.Parse(scoreParts[1]));
                        aScoreList.Add(score);
                    }
                }
                else
                {
                    ok = false;
                }
            }
            catch
            {
                ok = false;
            }
            finally
            {
                //Close the reader
                if (streamReader != null)
                {
                    streamReader.Close();
                }
            }
            return ok;
        }
    }
}
