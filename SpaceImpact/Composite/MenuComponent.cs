using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace SpaceImpact
{
    public abstract class MenuComponent
    {
        protected List<string> menuItems;
        protected int selectedIndex;
        protected string name;

        protected Color hilite = Color.Yellow;
        protected Color normal = Color.Gray;

        protected KeyboardState keyboardState;
        protected KeyboardState oldKeyboardState;

        protected SpriteBatch spriteBatch;
        protected SpriteFont spriteFont = Game1.Instance.Content.Load<SpriteFont>("MyFont");

        protected Vector2 position;
        protected float width = 0f;
        protected float height = 0f;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public float Width
        {
            get { return width; }
        }
        public float Height
        {
            get { return height; }
        }

        public MenuComponent(List<string> componentName)
        {
            foreach (string item in menuItems)
                this.menuItems.Add(item);
        }

        public void addComponent(string menuItem)
        {
            this.menuItems.Add(menuItem);
        }

        public virtual void Update(List<string> menuitems)
        {
            keyboardState = Keyboard.GetState();

            if (CheckKey(Keys.Down))
            {
                selectedIndex++;
                if (selectedIndex == menuitems.Count)
                    selectedIndex = 0;
            }
            if (CheckKey(Keys.Up))
            {
                selectedIndex--;
                if (selectedIndex < 0)
                    selectedIndex = menuitems.Count - 1;
            }
            MeasureMenu();

            oldKeyboardState = keyboardState;
        }

        public virtual void Draw(List<string> menuitems, SpriteBatch spritebatch)
        {
            Color tint;
            for (int i = 0; i < menuItems.Count; i++)
            {
                if (i == selectedIndex)
                {
                    tint = hilite;
                }
                else
                {
                    tint = normal;
                }

                spritebatch.DrawString(spriteFont, menuItems[i], position, tint);
                position.Y += spriteFont.LineSpacing + 5;
            }
        }

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                if (selectedIndex < 0)
                    selectedIndex = 0;
                if (selectedIndex >= menuItems.Count())
                    selectedIndex = menuItems.Count() - 1;
            }
        }

        private bool CheckKey(Keys theKey)
        {
            return keyboardState.IsKeyUp(theKey) &&
                oldKeyboardState.IsKeyDown(theKey);
        }

        public void MeasureMenu()
        {
            height = 0;
            width = 0;
            foreach (string item in menuItems)
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