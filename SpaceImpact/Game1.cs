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
        GamePlayScreen,
        CreditScreen
    }

    public class Game1 : Game
    {
        public static Game1 Instance;

        StartScreen startScreen;
        GamePlayScreen gamePlayScreen;
        CreditsScreen creditsScreen;
        Screen currentScreen;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1(): base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Instance = this;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            startScreen = new StartScreen();
            gamePlayScreen = new GamePlayScreen(this);
            creditsScreen = new CreditsScreen();
            currentScreen = Screen.StartScreen;

        }

        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();


            //startScreen.Update();
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
                case Screen.CreditScreen:
                    if (creditsScreen != null)
                        break;
                        //creditsScreen.Update(gameTime);
                    break;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            //startMenu.Draw(spriteBatch);

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
                case Screen.CreditScreen:
                    if (creditsScreen != null)
                        creditsScreen.Draw(spriteBatch);
                    break;
                //creditsScreen.Update(gameTime);
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

        public void CreditsScreen()
        {
            creditsScreen = new CreditsScreen();
            currentScreen = Screen.CreditScreen;

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
