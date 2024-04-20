namespace Assignment7
{
    public class SpriteModel
    {
        //Private field
        private Color mColor;

        //Property
        public Color Color { get { return mColor; } set { mColor = value; } }

        //Constructor
        public SpriteModel(Color aColor)
        {
            mColor = aColor;
        }
    }
}
