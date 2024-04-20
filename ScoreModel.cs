namespace Assignment7
{
    public class ScoreModel
    {
        //Private fields
        private string mName;
        private int mScore;

        //Properties
        public string Name { get { return mName; } set { if (!string.IsNullOrEmpty(value)) mName = value; } }
        public int Score { get { return mScore; } set { mScore = value; } }

        //Constructor
        public ScoreModel(string aName, int aScore)
        {
            mName = aName;
            mScore = aScore;
        }

        //Override To string
        public override string ToString()
        {
            return string.Format("{0, -10} {1, -10}", mScore.ToString("000000"), mName);
        }
    }
}
