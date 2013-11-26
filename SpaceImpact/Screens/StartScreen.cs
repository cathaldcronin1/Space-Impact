﻿using System;
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
        private StartMenu startmenu;

        List<string> startMenuItems = new List<string>() { "Start Game", "Quit" };
        public StartScreen(Game1 game)
        {
            this.game = game;
            startmenu = new StartMenu(startMenuItems);
            texture = game.Content.Load<Texture2D>("game1.png");
            lastState = Keyboard.GetState();
        }

        public void Update()
        {
            startmenu.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            startmenu.Draw(this.startMenuItems, spriteBatch) ;
        }
    }
}
