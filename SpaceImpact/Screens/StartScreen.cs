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
            startmenu.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            startmenu.Draw(spriteBatch);
        }
    }
}
