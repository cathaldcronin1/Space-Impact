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
        protected string[] menuItems;
        protected int selectedIndex;

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

        public MenuComponent()
        {
           
        }
     
        public MenuComponent(string[] menuItems)
        {
            this.menuItems = menuItems;
        }

        public virtual void Update(String[] menuitems)
        {
            keyboardState = Keyboard.GetState();

            if (CheckKey(Keys.Down))
            {
                selectedIndex++;
                if (selectedIndex == menuitems.Length)
                    selectedIndex = 0;
            }
            if (CheckKey(Keys.Up))
            {
                selectedIndex--;
                if (selectedIndex < 0)
                    selectedIndex = menuitems.Length - 1;
            }

            oldKeyboardState = keyboardState;
        }

        public virtual void Draw(SpriteBatch spritebatch)
        {
            Vector2 location = position;
            Color tint;
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == selectedIndex)
                {
                    tint = hilite;
                }
                else
                {
                    tint = normal;
                }

                spritebatch.DrawString(spriteFont, menuItems[i], location, tint);
                location.Y += spriteFont.LineSpacing + 5;
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
                if (selectedIndex >= menuItems.Length)
                    selectedIndex = menuItems.Length - 1;
            }
        }

        private bool CheckKey(Keys theKey)
        {
            return keyboardState.IsKeyUp(theKey) &&
                oldKeyboardState.IsKeyDown(theKey);
        }

    }
}