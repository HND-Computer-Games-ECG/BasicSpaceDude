using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace BasicSpaceDude
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static readonly Random RNG = new Random();

        // Constants
        const int NUMBEROFDUDES = 1000;

        // Class Variables
        Background bg;
        Vector2 screenCenter;

        // Create a variable called "dudes" that is an array (collection) of
        // variables of type FloatyDude
        FloatyDude[] dudes;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Specify that dudes has space for 100 dudes
            dudes = new FloatyDude[NUMBEROFDUDES];
            screenCenter = GraphicsDevice.Viewport.Bounds.Center.ToVector2();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            bg = new Background(Content.Load<Texture2D>("starfield"));

            for (int i = 0; i < dudes.Length; i++)
            {
                Vector2 startPos = screenCenter + new Vector2(RNG.Next(-100, 100),RNG.Next(-100, 100));
                Vector2 startVel = new Vector2((float)(RNG.NextDouble() * 2) - 1,
                                                        (float)(RNG.NextDouble() * 2) - 1);
                dudes[i] = new FloatyDude(Content.Load<Texture2D>("dude" + (i%6)), startPos, startVel);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            for (int i = 0; i < dudes.Length; i++)
                dudes[i].UpdateMe(GraphicsDevice.Viewport.Bounds);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            bg.DrawMe(_spriteBatch);

            for (int i = 0; i < dudes.Length; i++)
                dudes[i].DrawMe(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}