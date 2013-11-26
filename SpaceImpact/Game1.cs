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

        StartScreen startScreen;
        GamePlayScreen gamePlayScreen;
        Screen currentScreen;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1(): base()
        {
            Instance = this;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            startScreen = new StartScreen(this);
            currentScreen = Screen.StartScreen;

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            switch (currentScreen)
            {
                case Screen.StartScreen:
                    if (startScreen != null)
                        startScreen.Update();
                    break;
                case Screen.GamePlayScreen:
                    if (gamePlayScreen != null)
                        gamePlayScreen.Update(gameTime);
                    break;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            switch (currentScreen)
            {
                case Screen.StartScreen:
                    if (startScreen != null)
                        startScreen.Draw(spriteBatch);
                    break;
                case Screen.GamePlayScreen:
                    if (gamePlayScreen != null)
                        gamePlayScreen.Draw(spriteBatch);
                    break;
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void StartGame()
        {
            gamePlayScreen = new GamePlayScreen(this);
            currentScreen = Screen.GamePlayScreen;

            startScreen = null;
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
