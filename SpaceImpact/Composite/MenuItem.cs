using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace SpaceImpact
{
    class MenuItem : MenuComponent
    {
        ArrayList menuItems = new ArrayList();
        KeyboardState keystate;

        string menuItemName;

        public MenuItem(string newItemName)
        {
            this.menuItemName = newItemName;
        }

        public string getItemName() 
        { 
            return menuItemName;
        }

        public override void add(MenuComponent newMenuComponent)
        {
            menuItems.Add(newMenuComponent);
        }

        public override void remove(MenuComponent newMenuComponent)
        {
            menuItems.Remove(newMenuComponent);
        }

        public MenuComponent getComponent(int componentIndex)
        {
            return (MenuComponent)menuItems[componentIndex];
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            foreach(MenuItem component in menuItems)
            {
                spritebatch.DrawString(Game1.Instance.Content.Load<SpriteFont>("MyFont"), component.getItemName(), Vector2.Zero, Color.White);
            }
        }

        public void Update()
        {
            keystate = Keyboard.GetState();
            foreach (MenuItem component in menuItems)
            {
                if (keystate.IsKeyDown(Keys.Enter)) 
                    Game1.Instance.StartGame();
            }
        }
    }
}
