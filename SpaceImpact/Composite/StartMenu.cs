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
        private String[] menuitems = { "Start Game", "Quit game" };
        private KeyboardState keyState, oldKeyboardState;
        private Color tint;

        public StartMenu()
        {

        }

        public void Update()
        {
            MeasureMenu();
            keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.Enter) && (selectedIndex == 0))
                Game1.Instance.StartGame();
            if (keyState.IsKeyDown(Keys.Enter) && (selectedIndex == 1))
                Game1.Instance.Exit();

            oldKeyboardState = keyState;

            base.Update(this.menuitems);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
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

        public void MeasureMenu()
        {
            height = 0;
            width = 0;
            foreach (string item in menuitems)
            {
                Vector2 size = spriteFont.MeasureString(item);
                if (size.X > width)
                    width = size.X;
                height += spriteFont.LineSpacing + 5;
            }
            position = new Vector2((Game1.Instance.Window.ClientBounds.Width - width) / 2, (Game1.Instance.Window.ClientBounds.Height) / 2);
        }
    }
}
