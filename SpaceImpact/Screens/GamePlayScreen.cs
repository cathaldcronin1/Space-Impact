using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceImpact
{
    public class GamePlayScreen
    {
        private Game1 game;
        Player player;
        public static ProjectileFactory bulletFactory;
        InputHandler inputHandler;
        ShipFactory factory;
        HUDDisplay hud;

        List<Ship> enemies;
        Rectangle playerBounds;
        Rectangle enemyBounds;
        Rectangle projectileBounds;

        public GamePlayScreen(Game1 game)
        {
            this.game = game;
            factory = new ShipFactory(this.game.Content);
            player = new Player(game.Content.Load<Texture2D>("player.png"), new Vector2(100, 100), Vector2.Zero);
            bulletFactory = new ProjectileFactory(this.game.Content);
            inputHandler = new InputHandler(player);
            hud = new HUDDisplay(player, this.game.Content.Load<SpriteFont>("MyFont"));

            enemies = new List<Ship>();
            enemies.Add((Ship)factory.CreateEnemy(0));
        }

        public void Update(GameTime gameTime)
        {
            bulletFactory.Update(gameTime);
            inputHandler.Update(gameTime);


            foreach (Ship enemy in enemies)
            {
                enemy.Update(gameTime);
            }

            CheckCollisions();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            bulletFactory.Draw(spriteBatch);
            player.Draw(spriteBatch);
            hud.Draw(spriteBatch);

            foreach (Ship enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }

        public void CheckCollisions()
        {
            playerBounds = new Rectangle((int)(player.Position.X - player.Width / 2), (int)(player.Position.Y - player.Height / 2), player.Width, player.Height);

            foreach (Ship enemy in enemies)
            {
                if (enemy.Hitpoints <= 0)
                {
                    enemies.Remove(enemy);
                    break;
                }
                enemyBounds = new Rectangle((int)(enemy.Position.X - enemy.Width / 2), (int)(enemy.Position.Y - enemy.Height / 2), enemy.Width, enemy.Height);
                if (playerBounds.Intersects(enemyBounds))
                {
                    player.addHealth(-20);
                    enemies.Remove(enemy);
                    break;
                }
            }

            //check projectile collisions
            foreach (Projectile p in bulletFactory.Protectiles)
            {
                projectileBounds = new Rectangle((int)(p.Position.X - p.Width / 2), (int)(p.Position.Y - p.Height / 2), p.Width, p.Height);
                if (playerBounds.Intersects(projectileBounds) && p.Tag == "enemy")
                {
                    player.addHealth(-p.Damage);
                }

                foreach (Ship enemy in enemies)
                {
                    enemyBounds = new Rectangle((int)(enemy.Position.X - enemy.Width / 2), (int)(enemy.Position.Y - enemy.Height / 2), enemy.Width, enemy.Height);
                    if (enemyBounds.Intersects(projectileBounds) && p.Tag == "player")
                    {
                        enemy.Hitpoints = enemy.Hitpoints - p.Damage;
                        bulletFactory.Protectiles.Remove(p);
                        return;
                    }
                }
            }
        }
    }
}
