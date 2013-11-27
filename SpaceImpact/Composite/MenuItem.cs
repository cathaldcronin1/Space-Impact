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
        //ArrayList menuItems = new ArrayList();
        List<MenuComponent> menuItems = new List<MenuComponent>();
        KeyboardState keystate;
        KeyboardState oldkeystate;
        Vector2 position;
        SpriteFont spriteFont = Game1.Instance.Content.Load<SpriteFont>("MyFont");

        Color tint;
        Color hilite = Color.Yellow;
        Color normal = Color.Gray;

        int selectedIndex = 0;
        string menuItemName;

        public MenuItem(string newItemName="")
        {
            this.menuItemName = newItemName;
        }

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; }
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
            return menuItems[componentIndex];
        }

        public override void Draw(SpriteBatch spritebatch)
        {
   
            for (int i = 0; i < menuItems.Count; i++ )
            {
                if (i == selectedIndex)
                {
                    tint = hilite;
                }
                else
                {
                    tint = normal;
                }

                spritebatch.DrawString(Game1.Instance.Content.Load<SpriteFont>("MyFont"), ((MenuItem)menuItems[i]).getItemName() , position, tint);
                position.Y += spriteFont.LineSpacing + 5;
            }

            foreach (MenuItem item in menuItems)
            {
                MeasureMenu(item);
            }
        }

        public override void Update()
        {
            keystate = Keyboard.GetState();

            //If an up/down key is pressed we want to update index of the selectedItem
            if(keyPressed(Keys.Up))
            {
                SelectedIndex--;
                if (selectedIndex < 0)
                    selectedIndex = menuItems.Count - 1;
            }
            if(keyPressed(Keys.Down))
            {
                SelectedIndex++;
                if (selectedIndex == menuItems.Count)
                    selectedIndex = 0;
            }

            foreach (MenuItem item in menuItems)
            {
                // Enter key pressed
                if(keyPressed(Keys.Enter))
                {
                    if (selectedIndex == 0)
                    {
                        // public delegate void Exectute(concreteMenu)
                        // menuItem.Execute(StartGame)
                        Game1.Instance.StartGame();
                    }
                    else if (selectedIndex == 1)
                    {
                        Game1.Instance.CreditsScreen();
                    }
                    else if (selectedIndex == 2)
                    {
                        System.Environment.Exit(0);
                    }
                }
            }
            oldkeystate = keystate;
        }

        private void MeasureMenu(MenuItem item)
        {
            float height = 0;
            float width = 0;

            Vector2 size = spriteFont.MeasureString(item.getItemName());
            if (size.X > width)
                width = size.X;
            height += spriteFont.LineSpacing + 5;
            position = new Vector2((Game1.Instance.Window.ClientBounds.Width - width) / 2, (Game1.Instance.Window.ClientBounds.Height) / 2);

        }

        private bool keyPressed(Keys key)
        {
            return keystate.IsKeyDown(key) && oldkeystate.IsKeyUp(key);
        }
    }
}
