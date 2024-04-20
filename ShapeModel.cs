namespace Assignment7
{
    public class ShapeModel
    {
        //Private fields
        private string mName;
        private int mWidth;
        private int mHeight;
        private SpriteModel[,] mPixels;
        private Color mColor;
        private int mPositionX;
        private int mPositionY;
        private SpriteModel[,] mOldPixels;

        //Properties
        public string Name { get { return mName; } set { if (!string.IsNullOrEmpty(value)) mName = value; } }
        public int Width { get { return mWidth; } set { if(value > 0) mWidth = value;} }
        public int Height { get { return mHeight; } set { if (value > 0) mHeight = value; } }
        public SpriteModel[,] Pixels { get { return mPixels; } set { if (value != null) mPixels = value; } }
        public Color Color { get { return mColor; } set { mColor = value; } }
        public int PositionX { get { return mPositionX; } set { mPositionX = value; } }
        public int PositionY { get {  return mPositionY; } set { mPositionY = value; } }

        /// <summary>
        /// Rotates the shape clockwise
        /// </summary>
        public void RotateShapeClockWise()
        {
            //Save the current shape of the shape (in case we have to revert it)
            mOldPixels = mPixels;

            mPixels = new SpriteModel[mWidth, mHeight];

            for (int x = 0; x < mWidth; x++)
            {
                for (int y = 0; y < mHeight; y++)
                {
                    mPixels[x, y] = mOldPixels[mHeight - 1 - y, x];
                }
            }

            //Save the current width in a temporary variable
            int sTempWidth = mWidth;

            //Set the height to the width
            mWidth = mHeight;

            //And the height to the temp width (old width)
            mHeight = sTempWidth;
        }

        /// <summary>
        /// Rotates the shape counter clockwise
        /// </summary>
        public void RotateShapeCounterClockWise()
        {
            //Save the current shape of the shape (in case we have to revert it)
            mOldPixels = Pixels;

            mPixels = new SpriteModel[mWidth, mHeight];

            for (int x = 0; x < mWidth; x++)
            {
                for (int y = 0; y < mHeight; y++)
                {
                    mPixels[x, y] = mOldPixels[y, mWidth - 1 - x];
                }
            }

            //Save the current width in a temporary variable
            int tempWidth = mWidth;

            //Set the height to the width
            mWidth = mHeight;

            //And the height to the temp width (old width)
            mHeight = tempWidth;
        }

        /// <summary>
        /// Sets the shape to its old shape (in case of collision)
        /// </summary>
        public void SetShapeToOldDots()
        {
            //Set the dots to the old shape
            mPixels = mOldPixels;

            //Save the current width in a temporary variable
            int sTempWidth = Width;

            //Set the height to the width
            mWidth = mHeight;

            //And the height to the temp width (old width)
            mHeight = sTempWidth;
        }
    }
}
