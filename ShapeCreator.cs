namespace Assignment7
{
    public static class ShapeCreator
    {
        //Private fields
        private static ShapeModel[] mShapes;
        private static Color[] mColors;

        /// <summary>
        /// Static constructor, initializes the arrays and sets all the shapes and possible colors
        /// </summary>
        static ShapeCreator()
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
                        { new SpriteModel(), },
                        { new SpriteModel(), },
                        { new SpriteModel(), },
                        { new SpriteModel(), }
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
        public static ShapeModel GetRandomShape()
        {
            Random random = new Random();
            int randomShape = random.Next(mShapes.Length);
            int randomColor = random.Next(mColors.Length);
            ShapeModel shape = mShapes[randomShape];
            shape.Color = mColors[randomColor];
            return shape;
        }

        /// <summary>
        /// Gets the shape with the specified name
        /// </summary>
        /// <param name="name">The name of the shape</param>
        /// <returns>The shape</returns>
        public static ShapeModel GetShapeByName(string aName)
        {
            ShapeModel shape = null;

            //If it's an I, rotate it so it's horizontal
            if(aName == "I")
            {
                shape = mShapes.First(x => x.Name == aName);
                shape.RotateShapeClockWise();
            }
            if (mShapes.Any(x => x.Name == aName))
            {
                shape = mShapes.First(x => x.Name == aName);
            }

            //Set a random color
            if(shape != null)
            {
                Random random = new Random();
                int randomColor = random.Next(mColors.Length);
                shape.Color = mColors[randomColor];
            }

            return shape;
        }
    }
}
