namespace Assignment7.Models
{
    public class SpriteModel
    {
        //Private field
        private Color mColor;

        //Property
        public Color Color { get { return mColor; } set { mColor = value; } }

        //Constructor with Color as argument
        public SpriteModel(Color aColor)
        {
            mColor = aColor;
        }

        //Empty constructor
        public SpriteModel() { }
    }
}
