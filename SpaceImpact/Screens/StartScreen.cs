using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SpaceImpact
{
    class StartScreen
    {
        private Texture2D texture;
        private Game1 game;
        private KeyboardState lastState;

        StartMenu startmenu;
        private Vector2 position;
        private int height;
        private int width;

        public int SelectedIndex
        {
            get { return startmenu.SelectedIndex; }
            set { startmenu.SelectedIndex = value; }
        }

        public StartScreen(Game1 game)
        {
            this.game = game;
            startmenu = new StartMenu();
            texture = game.Content.Load<Texture2D>("game1.png");
            lastState = Keyboard.GetState();
        }

        public void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            //if (keyboardState.IsKeyDown(Keys.Enter) && lastState.IsKeyUp(Keys.Enter))
            //{
            //   game.StartGame();
            //}

            lastState = keyboardState;

            startmenu.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //if (texture != null)
            //    spriteBatch.Draw(texture, new Vector2(0f, 0f), Color.White);
            Console.WriteLine("11111111111111");
            startmenu.Draw(spriteBatch);
        }

        private void MeasureMenu()
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
            position = new Vector2((Game1.Instance.Window.ClientBounds.Width - width) / 2, (Game.Window.ClientBounds.Height) / 2);
        }
    }
}
