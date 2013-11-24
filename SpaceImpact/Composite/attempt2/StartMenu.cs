using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace SpaceImpact
{
    class StartMenu : MenuComponent
    {
        protected String[] menuitems = { "Start Game", "Quit game" };

        public StartMenu()
        {

        }

        public void Update()
        {
            base.Update(this.menuitems);
            //if start game pressed
            // switch screen state to gamescreen
            // if quit game pressed
            // quit game
            //Console
            if ((CheckKey(Keys.Down)) && (selectedIndex == 0))
            {
                Game1.Instance.StartGame();
            }
            if ((CheckKey(Keys.Down)) && (selectedIndex == 1))
            {
                Game1.Instance.Exit();
            }
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            Color tint; 
            for (int i = 0; i < menuitems.Length; i++)
            {
                if (i == selectedIndex)
                {
                    tint = hilite;
                }
                else
                {
                    tint = normal;
                }

                spritebatch.DrawString(spriteFont, menuitems[i], position, tint);
                position.Y += spriteFont.LineSpacing + 5;
            }

        }

         private bool CheckKey(Keys theKey)
        {
            return keyboardState.IsKeyUp(theKey) &&
                oldKeyboardState.IsKeyDown(theKey);
        }
    }
}
