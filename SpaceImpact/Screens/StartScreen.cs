using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SpaceImpact.Screens;

namespace SpaceImpact
{
    class StartScreen
    {
        // Start Menu has 3 items
        // 2 leafs and 1 composite
        // Start Game, Quit Game, options
        MenuComponent startMenu = new MenuItem();

        // Options will be a composite of item(s)
        // Contains a leaf node - Credits
        MenuComponent options = new MenuItem();

        public StartScreen()
        {
            options.add(new Credits());

            startMenu.add(new StartGame());
            startMenu.add(options);
            startMenu.add(new QuitGame());
        }

        public void Update()
        {
            // move menu  handling to here
            // based on currently selected component 
            // call that leaf/menuitems execute method?

            startMenu.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            startMenu.Draw(spriteBatch);
        }
    }
}
