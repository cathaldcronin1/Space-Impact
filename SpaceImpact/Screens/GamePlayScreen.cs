using System;
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
        Player player;
        Ship enemy;
        Projectile bullet;
        InputHandler inputHandler;
        ShipFactory factory;
        HUDDisplay hud;

        public GamePlayScreen(Game1 game)
        {
            this.game = game;
            factory = new ShipFactory(this.game.Content);
            player = new Player(game.Content.Load<Texture2D>("player.png"), new Vector2(100, 100), Vector2.Zero);
            enemy = factory.CreateEnemy(0);
            bullet = new Projectile(game.Content.Load<Texture2D>("bullet.png"), new Vector2(100, 200), new Vector2(1, 0), 5);
            inputHandler = new InputHandler(player);
            hud = new HUDDisplay(player, this.game.Content.Load<SpriteFont>("MyFont"));
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
            hud.Draw(spriteBatch);
        }
    }
}
