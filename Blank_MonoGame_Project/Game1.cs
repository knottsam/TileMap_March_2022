using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace TileMap_March_2022
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        //We need two arrays:
        //First array will hold the tiles we have created
        private Tile[,] tileArray;
        //The second array will hold the values of the tiles we read in from the .txt file
        private char[,] tileValuesArray;
        //Declare all necessary textures:
        private Texture2D coalTexture, dirtTexture, glassTexture, goldTexture, grassTexture, leavesTexture, redstoneTexture, sandTexture, stoneTexture, tntTexture, waterTexture, woodTexture;
        //Create a constant tile size to save time later
        private const int TILE_SIZE = 80;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            //Set the window width and height to 800px
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 800;
            //Set the map size to 10 so that we can have a 10x10 grid of tiles
            MapReader.MapSize = 10;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //Initialise the tileArray
            tileArray = new Tile[MapReader.MapSize, MapReader.MapSize];
            tileValuesArray = MapReader.ReadFile(Directory.GetCurrentDirectory() + @"\Content\MineCraft_Map");//Read the file and store into the array of values
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //Load all textures
            coalTexture = Content.Load<Texture2D>("Coal");
            dirtTexture = Content.Load<Texture2D>("Dirt");
            glassTexture = Content.Load<Texture2D>("Glass");
            goldTexture = Content.Load<Texture2D>("Gold");
            grassTexture = Content.Load<Texture2D>("Grass");
            leavesTexture = Content.Load<Texture2D>("Leaves");
            redstoneTexture = Content.Load<Texture2D>("Redstone");
            sandTexture = Content.Load<Texture2D>("Sand");
            stoneTexture = Content.Load<Texture2D>("Stone");
            tntTexture = Content.Load<Texture2D>("Tnt");
            waterTexture = Content.Load<Texture2D>("Water");
            woodTexture = Content.Load<Texture2D>("wood");

            //Create the map by calling the method we created:
            CreateMap();
        }

        /// <summary>
        /// Checks through the tilevalues array and assigns each value a texture which is drawn using a foreach loop
        /// Uses the Tile object to create a new tile based upon this texture - the tempPosition is a generic position
        /// to allow the re-use of the variable meaning that I don't have to create one for every texture every iteration
        /// </summary>
        public void CreateMap()
        {
            Vector2 tempPosition;

            for (int i = 0; i <= tileValuesArray.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= tileValuesArray.GetUpperBound(1); j++)
                {
                    tempPosition = new Vector2(TILE_SIZE * i, TILE_SIZE * j);

                    if (tileValuesArray[i, j] == '0')
                    {
                        tileArray[i, j] = new Tile(coalTexture, tempPosition, new Vector2(TILE_SIZE, TILE_SIZE), Color.White);
                    }
                    else if (tileValuesArray[i, j] == '1')
                    {
                        tileArray[i, j] = new Tile(dirtTexture, tempPosition, new Vector2(TILE_SIZE, TILE_SIZE), Color.White);
                    }
                    else if (tileValuesArray[i, j] == '2')
                    {
                        tileArray[i, j] = new Tile(glassTexture, tempPosition, new Vector2(TILE_SIZE, TILE_SIZE), Color.White);
                    }
                    else if (tileValuesArray[i, j] == '3')
                    {
                        tileArray[i, j] = new Tile(redstoneTexture, tempPosition, new Vector2(TILE_SIZE, TILE_SIZE), Color.White);
                    }
                    else if (tileValuesArray[i, j] == '4')
                    {
                        tileArray[i, j] = new Tile(sandTexture, tempPosition, new Vector2(TILE_SIZE, TILE_SIZE), Color.White);
                    }
                    else if (tileValuesArray[i, j] == '5')
                    {
                        tileArray[i, j] = new Tile(stoneTexture, tempPosition, new Vector2(TILE_SIZE, TILE_SIZE), Color.White);
                    }
                    else if (tileValuesArray[i, j] == '6')
                    {
                        tileArray[i, j] = new Tile(goldTexture, tempPosition, new Vector2(TILE_SIZE, TILE_SIZE), Color.White);
                    }
                    else if (tileValuesArray[i, j] == '7')
                    {
                        tileArray[i, j] = new Tile(grassTexture, tempPosition, new Vector2(TILE_SIZE, TILE_SIZE), Color.White);
                    }
                    else if (tileValuesArray[i, j] == '8')
                    {
                        tileArray[i, j] = new Tile(leavesTexture, tempPosition, new Vector2(TILE_SIZE, TILE_SIZE), Color.White);
                    }
                    else if (tileValuesArray[i, j] == '9')
                    {
                        tileArray[i, j] = new Tile(tntTexture, tempPosition, new Vector2(TILE_SIZE, TILE_SIZE), Color.White);
                    }
                    else if (tileValuesArray[i, j] == 'A')
                    {
                        tileArray[i, j] = new Tile(waterTexture, tempPosition, new Vector2(TILE_SIZE, TILE_SIZE), Color.White);
                    }
                    else if (tileValuesArray[i, j] == 'B')
                    {
                        tileArray[i, j] = new Tile(woodTexture, tempPosition, new Vector2(TILE_SIZE, TILE_SIZE), Color.White);
                    }
                }
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            foreach (Tile t in tileArray)
            {
                t.Draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
