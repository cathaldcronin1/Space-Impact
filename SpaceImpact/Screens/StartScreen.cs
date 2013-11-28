using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SpaceImpact
{
    public class StartScreen : IScreen
    {
        Menu mainMenu;
        Menu options;
        Menu currentMenu;
        Menu previousMenu;

        Vector2 menuPosition;
        SpriteFont font;
        int selectedIndex = 0;

        Color tint;

        KeyboardState keyState = Keyboard.GetState();
        KeyboardState oldKeyState;

        public delegate void ExecuteMethod();
        private ExecuteMethod startGame;
        private ExecuteMethod mute;
        private ExecuteMethod credits;
        private ExecuteMethod quit;
        private ExecuteMethod back;

        /// <summary>
        /// Create an instance of type StartScreen.
        /// Initializes all the menu components.
        /// </summary>
        public StartScreen()
        {
            // Sets delegates to be passed into MenuLeaf items.
            startGame = Game1.Instance.startGame;
            quit = Game1.Instance.Exit;
            mute = Game1.Instance.Exit;
            credits = Game1.Instance.showCredits;
            back = Back; //Locally Implemented Function.

            // Initializing options menu to be added to the main menu.
            options = new Menu("Options");
            options.Add(new MenuLeaf("Credits", credits));
            options.Add(new MenuLeaf("Mute", mute));
            options.Add(new MenuLeaf("Back", back));

            // Initializing main menu and adding the MenuLeaf objects and options menu.
            mainMenu = new Menu("Main Menu");
            mainMenu.Add(new MenuLeaf("Start", startGame));
            mainMenu.Add(options);
            mainMenu.Add(new MenuLeaf("Quit", quit));
            // Set current menu to the main menu.
            currentMenu = mainMenu;
            currentMenu.GetList().ElementAt(0).Select();
            
            menuPosition = new Vector2(100, 100);
            // Loading font for drawing the menu items.
            font = Game1.Instance.Content.Load<SpriteFont>("MyFont");

            
        }

        /// <summary>
        /// Update the StartScreens input handling and currently selected item.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            oldKeyState = keyState;
            keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.Down) && !oldKeyState.IsKeyDown(Keys.Down))
            {
                // DeSelect the current item in the menu so that it is no longer highlighted.
                currentMenu.GetList().ElementAt(selectedIndex).DeSelect();
                // Wrap around index when you get to bottom of menu.
                if (selectedIndex == (currentMenu.GetList().Count - 1))
                    selectedIndex = 0;
                else
                    selectedIndex++;
                // Select the new Item.
                currentMenu.GetList().ElementAt(selectedIndex).Select();
            }

            if (keyState.IsKeyDown(Keys.Up) && !oldKeyState.IsKeyDown(Keys.Up))
            {
                // DeSelect the current item in the menu so that it is no longer highlighted.
                currentMenu.GetList().ElementAt(selectedIndex).DeSelect();
                // Wrap around index when you get to bottom of menu.
                if (selectedIndex == 0)
                    selectedIndex = (currentMenu.GetList().Count - 1);
                else
                    selectedIndex--;
                // Select the new Item.
                currentMenu.GetList().ElementAt(selectedIndex).Select();
            }

            if (keyState.IsKeyDown(Keys.Enter) && !oldKeyState.IsKeyDown(Keys.Enter))
            {
                // Checks if currently selected element is a MenuLeaf.
                if (currentMenu.GetList().ElementAt(selectedIndex) is MenuLeaf)
                {
                    //Calls the Leaf's Execute method.
                    ((MenuLeaf)currentMenu.GetList().ElementAt(selectedIndex)).Execute();
                }
                // Checks if currently selected element is a Menu.
                else if (currentMenu.GetList().ElementAt(selectedIndex) is Menu)
                {
                    // Set's the current menu to the next menu in the tree.
                    currentMenu.GetList().ElementAt(selectedIndex).DeSelect();
                    previousMenu = currentMenu;                  
                    currentMenu = ((Menu)currentMenu.GetList().ElementAt(selectedIndex));
                    selectedIndex = 0;
                    currentMenu.GetList().ElementAt(0).Select();
                }

            }
        }

        /// <summary>
        /// Draws the currently selected menu.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < currentMenu.GetList().Count; i++ )
            {
                // Highlights the currently selected item in the menu.
                if (currentMenu.GetList().ElementAt(i).Selected())
                    tint = Color.Yellow;
                else
                    tint = Color.White;
                // Draws the item in the menu.
                spriteBatch.DrawString(font, currentMenu.GetList().ElementAt(i).GetName() , new Vector2(menuPosition.X, menuPosition.Y + (i * 50)), tint);
            }
        }

        /// <summary>
        /// Function for returning to the previous menu in the tree.
        /// </summary>
        public void Back()
        {
            currentMenu.GetList().ElementAt(selectedIndex).DeSelect();
            currentMenu = previousMenu;
            selectedIndex = 0;
            currentMenu.GetList().ElementAt(0).Select();
        }
    }
}
