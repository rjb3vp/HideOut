#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

//test change by lenny
namespace Hide_Out
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D player;
        Rectangle playerLoc;
        Searcher testSearcher;
        BasicEffect basicEffect;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
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
            IsMouseVisible = false;
            this.Window.Title = "";

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            player = Content.Load<Texture2D>("green");
            playerLoc = new Rectangle(0, 0, player.Width, player.Height);
            testSearcher = new Searcher(Content.Load<Texture2D>("black"),
                new Rectangle(300, 150, 25, 25),
                200,
                .60,
                Vector2.UnitX
                );

            basicEffect = new BasicEffect(GraphicsDevice);
            basicEffect.VertexColorEnabled = true;
            basicEffect.LightingEnabled = false;
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                testSearcher.Move(0, -1);
            }
            if(Keyboard.GetState().IsKeyDown(Keys.A)) 
            {
                testSearcher.Move(-1, 0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                testSearcher.Move(0, 1);
            }
            if(Keyboard.GetState().IsKeyDown(Keys.D)) 
            {
                testSearcher.Move(1, 0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                testSearcher.Rotate(.1);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                testSearcher.Rotate(-.1);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                playerLoc.Y--;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                playerLoc.X--;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                playerLoc.Y++;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                playerLoc.X++;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                testSearcher.setViewDistance(testSearcher.getViewDistance() + 1);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F))
            {
                testSearcher.setViewDistance(testSearcher.getViewDistance() - 1);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.X))
            {
                testSearcher.setViewAngle(testSearcher.getViewAngle() + .01);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                testSearcher.setViewAngle(testSearcher.getViewAngle() - .01);
            }

            if(testSearcher.CanSee(playerLoc)) this.Window.Title = "Caught!";
            else this.Window.Title = "Hidden";

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            GraphicsDevice.BlendState = BlendState.Opaque;
            GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;

            Matrix projection = Matrix.CreateOrthographicOffCenter(0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, 0, 0, 1);
            Matrix halfPixelOffset = Matrix.CreateTranslation(-0.5f, -0.5f, 0);

            basicEffect.World = Matrix.Identity;
            basicEffect.View = Matrix.Identity;
            basicEffect.Projection = halfPixelOffset * projection;

            basicEffect.VertexColorEnabled = true;
            GraphicsDevice.RasterizerState = RasterizerState.CullNone;

            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, testSearcher.getFieldOfViewTriangle(), 0, 1);
            }

            spriteBatch.Begin();
            spriteBatch.Draw(player, playerLoc, Color.White);
            spriteBatch.Draw(testSearcher.getTexture(), testSearcher.getLocation(), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
