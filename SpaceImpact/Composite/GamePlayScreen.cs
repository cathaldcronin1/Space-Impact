﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceImpact
{
    class GamePlayScreen
    {
        private Game1 game;
        ShipHull player;
        Ship enemy;
        Projectile bullet;
        InputHandler inputHandler;
        ShipFactory factory;

        public GamePlayScreen(Game1 game)
        {
            this.game = game;
            factory = new ShipFactory(this.game.Content);
            player = new ShipHull(game.Content.Load<Texture2D>("player.png"), new Vector2(100, 100), Vector2.Zero, null);
            enemy = factory.CreateEnemy(0);
            bullet = new Projectile(game.Content.Load<Texture2D>("bullet.png"), new Vector2(100, 200), new Vector2(1, 0), 5);
            inputHandler = new InputHandler(player);
        }

        public void Update(GameTime gameTime)
        {
            bullet.Update(gameTime);
            inputHandler.Update(gameTime);
            enemy.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            bullet.Draw(spriteBatch);
            player.Draw(spriteBatch);
            enemy.Draw(spriteBatch);
        }
    }
}
