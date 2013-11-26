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
        //{ "Start Game", "Quit game" };

        public StartMenu(List<string> menuItem) : base(menuItem)
        {
            
        }

        public void Update()
        {
            if (base.keyboardState.IsKeyDown(Keys.Enter) && (selectedIndex == 0))
                Game1.Instance.StartGame();
            if (base.keyboardState.IsKeyDown(Keys.Enter) && (selectedIndex == 1))
                Game1.Instance.Exit();

            base.Update(base.menuItems);
        }

        public override void Draw(List<string> menuitems, SpriteBatch spritebatch)
        {
            base.Draw(base.menuItems, spritebatch);
        }
    }
}
