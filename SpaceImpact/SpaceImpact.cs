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
    public class SpaceImpact : Game
    {
        // Need this to be static to have access to 
        // properties and functions within the Game.
        public static SpaceImpact Instance;

        // An reference to a screen object,
        // can easily update & draw the currently selected screen.
        IScreen currentScreen;

        // Concrete screens.
        StartScreen startScreen;
        GamePlayScreen gamePlayScreen;
        CreditsScreen creditsScreen;

        // Acess to the graphics card
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public SpaceImpact(): base()
        {
            graphics = new GraphicsDeviceManager(this);
            
            // Access to content of game.
            Content.RootDirectory = "Content";
            
            // Initialising the static instance of the game.
            Instance = this;
        }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            startScreen = new StartScreen();
            gamePlayScreen = new GamePlayScreen(this);
            creditsScreen = new CreditsScreen();
            currentScreen = startScreen;
        }

        protected override void Update(GameTime gameTime)
        {
            // Update currently selected screen
            currentScreen.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Draw the background.
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            
            // Draw currently selected screen.
            currentScreen.Draw(spriteBatch);
            spriteBatch.End();
        }

        // Switch the current screen to the gamePlayScreen
        public void startGame()
        {
            currentScreen = gamePlayScreen;
        }

        // Switch the current screen to the creditsScreen
        public void showCredits()
        {
            currentScreen = creditsScreen;
        }

        // Switch the current screen to the startScreen
        public void mainMenu()
        {
            currentScreen = startScreen;
        }

        // Keep player within bounds of the screen
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
