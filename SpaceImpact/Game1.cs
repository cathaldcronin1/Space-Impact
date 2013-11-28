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

namespace SpaceImpact
{
    enum Screen
    {
        StartScreen,
        GamePlayScreen
    }

    public class Game1 : Game
    {
        public static Game1 Instance;

        IScreen currentScreen;
        StartScreen startScreen;
        GamePlayScreen gamePlayScreen;
        CreditsScreen creditsScreen;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1(): base()
        {
            graphics = new GraphicsDeviceManager(this);
            //graphics.IsFullScreen = true;
            //graphics.PreferredBackBufferHeight = 720;
            //graphics.PreferredBackBufferWidth = 1280;
            Content.RootDirectory = "Content";
            Instance = this;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            startScreen = new StartScreen();
            gamePlayScreen = new GamePlayScreen(this);
            creditsScreen = new CreditsScreen();
            ;
            currentScreen = startScreen;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            currentScreen.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            currentScreen.Draw(spriteBatch);
            spriteBatch.End();
        }

        public void startGame()
        {
            currentScreen = gamePlayScreen;
        }

        public void showCredits()
        {
            currentScreen = creditsScreen;
        }

        public void mainMenu()
        {
            currentScreen = startScreen;
        }

        public bool OutOfBounds(Vector2 pos)
        {
            if ((pos.X + 100) < Window.ClientBounds.Left
                || (pos.X - 100) > Window.ClientBounds.Right
                || (pos.Y + 100) < Window.ClientBounds.Top
                || (pos.Y - 100) > Window.ClientBounds.Bottom)
            {
                return true;
            }
            return false;
        }
    }
}
