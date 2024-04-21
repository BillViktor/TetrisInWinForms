using Assignment7.Models;

namespace Assignment7.Classes
{
    public class ShapeCreator
    {
        //Private fields
        private ShapeModel[] mShapes;
        private Color[] mColors;

        /// <summary>
        /// Static constructor, initializes the arrays and sets all the shapes and possible colors
        /// </summary>
        public ShapeCreator()
        {
            mShapes =
            [
                new ShapeModel
                {
                    Name = "I",
                    Width = 1,
                    Height = 4,
                    Pixels = new SpriteModel[,]
                    {
                        { new SpriteModel() },
                        { new SpriteModel() },
                        { new SpriteModel() },
                        { new SpriteModel() }
                    }
                },
                new ShapeModel
                {
                    Name = "O",
                    Width = 2,
                    Height = 2,
                    Pixels = new SpriteModel[,]
                    {
                        { new SpriteModel(), new SpriteModel() },
                        { new SpriteModel(), new SpriteModel() }
                    }
                },
                new ShapeModel
                {
                    Name = "T",
                    Width = 3,
                    Height = 2,
                    Pixels = new SpriteModel[,]
                    {
                        { null, new SpriteModel(), null },
                        { new SpriteModel(), new SpriteModel(), new SpriteModel() }
                    }
                },
                new ShapeModel
                {
                    Name = "L",
                    Width = 3,
                    Height = 2,
                    Pixels = new SpriteModel[,]
                    {
                        { null, null, new SpriteModel() },
                        { new SpriteModel(), new SpriteModel(), new SpriteModel() }
                    }
                },
                new ShapeModel
                {
                    Name = "J",
                    Width = 3,
                    Height = 2,
                    Pixels = new SpriteModel[,]
                    {
                        { new SpriteModel(), null, null },
                        { new SpriteModel(), new SpriteModel(), new SpriteModel() }
                    }
                },
                new ShapeModel
                {
                    Name = "Z",
                    Width = 3,
                    Height = 2,
                    Pixels = new SpriteModel[,]
                    {
                        { new SpriteModel(), new SpriteModel(), null },
                        { null, new SpriteModel(), new SpriteModel() }
                    }
                },
                new ShapeModel
                {
                    Name = "S",
                    Width = 3,
                    Height = 2,
                    Pixels = new SpriteModel[,]
                    {
                        { null, new SpriteModel(), new SpriteModel() },
                        { new SpriteModel(), new SpriteModel(), null }
                    }
                }
            ];

            mColors =
            [
                Color.Blue,
                Color.Green,
                Color.Orange,
                Color.Purple,
                Color.Red,
                Color.Yellow
            ];
        }

        /// <summary>
        /// Generates a random number for shape and color and returns the shape
        /// </summary>
        /// <returns>A random shape</returns>
        public ShapeModel GetRandomShape()
        {
            //Get a random shape and color
            Random sRandom = new Random();
            int sRandomShape = sRandom.Next(mShapes.Length);
            int sRandomColor = sRandom.Next(mColors.Length);
            ShapeModel sShape = mShapes[sRandomShape];
            sShape.Color = mColors[sRandomColor];

            return sShape;
        }

        /// <summary>
        /// Gets the shape with the specified name
        /// </summary>
        /// <param name="name">The name of the shape</param>
        /// <returns>The shape</returns>
        public ShapeModel GetShapeByName(string aName)
        {
            ShapeModel sShape = null;

            //If it's an I, rotate it so it's horizontal
            sShape = mShapes.FirstOrDefault(x => x.Name == aName);

            //If not found, get a random one
            if (sShape == null)
            {
                sShape = GetRandomShape();
            }

            //Set a random color
            Random sRandom = new Random();
            int sRandomColor = sRandom.Next(mColors.Length);
            sShape.Color = mColors[sRandomColor];

            return sShape;
        }
    }
}
