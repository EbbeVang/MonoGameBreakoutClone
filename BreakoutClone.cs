using Windows.UI.Xaml.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameBreakoutClone.GameFramework;

namespace MonoGameBreakoutClone
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class BreakoutClone : GameHost
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        private SpriteFont _segoe;
        private Texture2D playerTexture2D;
        private Texture2D ballTexture2D;
        private Texture2D blockTexture2Dblue;
        private Texture2D blockTexture2Dgreen;
        private Texture2D blockTexture2Dgrey;
        private Texture2D blockTexture2Dpurple;
        private Score score; 
        public BreakoutClone()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _segoe = Content.Load<SpriteFont>("SegoeUI_48");
            // TODO: use this.Content to load your game content here

            playerTexture2D = Content.Load<Texture2D>("PaddleRed");
            ballTexture2D = Content.Load<Texture2D>("ballBlue");
            blockTexture2Dblue = Content.Load<Texture2D>("element_blue_rectangle_glossy");
            blockTexture2Dgreen = Content.Load<Texture2D>("element_green_rectangle_glossy");
            blockTexture2Dgrey = Content.Load<Texture2D>("element_grey_rectangle_glossy");
            blockTexture2Dpurple = Content.Load<Texture2D>("element_purple_rectangle_glossy");
            SetGame();
        }

        public void SetGame()
        {
            

            //create player
            Player player = new Player(this, new Vector2(800,800), playerTexture2D);
            GameObjects.Add(player);

            // create ball
            
            for (int i = 0; i < 25; i++)
            {
                Block b = new Block(this, new Vector2(100+i*60, 100), blockTexture2Dblue );
                GameObjects.Add(b);

                Block b2 = new Block(this, new Vector2(100+i*60, 130), blockTexture2Dgrey );
                GameObjects.Add(b2);

                Block b3 = new Block(this, new Vector2(100+i*60, 160), blockTexture2Dgreen );
                GameObjects.Add(b3);

                Block b4 = new Block(this, new Vector2(100+i*60, 190), blockTexture2Dpurple );
                GameObjects.Add(b4);

                Block b5 = new Block(this, new Vector2(100 + i * 60, 210), blockTexture2Dblue);
                GameObjects.Add(b5);

                Block b6 = new Block(this, new Vector2(100 + i * 60, 240), blockTexture2Dgrey);
                GameObjects.Add(b6);

                Block b7 = new Block(this, new Vector2(100 + i * 60, 270), blockTexture2Dgreen);
                GameObjects.Add(b7);

                Block b8 = new Block(this, new Vector2(100 + i * 60, 320), blockTexture2Dpurple);
                GameObjects.Add(b8);
            }
            score = new Score(this, _segoe, new Vector2(900, 50));
            score.Text = "Score: 0";
            GameObjects.Add(score);

            Ball ball = new Ball(this, new Vector2(100, 400), ballTexture2D, score);
            GameObjects.Add(ball);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            
            UpdateAll(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            foreach (SpriteObject spriteObject in GameObjects)
            {
                spriteObject.Draw(gameTime, _spriteBatch);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }

       
    }
}
