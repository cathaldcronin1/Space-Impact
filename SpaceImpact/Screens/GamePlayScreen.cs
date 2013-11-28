using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceImpact
{
    /// <summary>
    /// Main Game screen.
    /// All ingame logic is derived here.
    /// </summary>
    public class GamePlayScreen : IScreen
    {
        private SpaceImpact game;
        Player player;

        // Static instance so the player can access it.
        public static ProjectileManager bulletFactory;

        InputHandler inputHandler;
        ShipFactory factory;
        HUDDisplay hud;

        List<IShip> enemies;

        // Collision rectanlge bounds for objects on screen.
        Rectangle playerBounds;
        Rectangle enemyBounds;
        Rectangle projectileBounds;

        Random rand;
        int elapsedTime;
        int spawnTimeMin = 2000;
        int spawnTimeMax = 4000;
        int nextSpawnTime = 1;
        int enemyScore = 50;

        SpriteFont font;

        /// <summary>
        /// An instance of our game.
        /// When this screen is created, all in game objects are created.
        /// </summary>
        public GamePlayScreen(SpaceImpact game)
        {
            this.game = game;
            factory = new ShipFactory(this.game.Content);
            player = new Player(game.Content.Load<Texture2D>("player1.png"), new Vector2(100, 100), Vector2.Zero);

            bulletFactory = new ProjectileManager(this.game.Content);
            inputHandler = new InputHandler(player);
            font = game.Content.Load<SpriteFont>("MyFont");
            hud = new HUDDisplay(player, font);

            enemies = new List<IShip>();
            player.NotifyObserver();
            rand = new Random();
        }

        /// <summary>
        /// Updates all components in the game.
        /// </summary>
        public void Update(GameTime gameTime)
        {
            // Call update for components in the game.
            bulletFactory.Update(gameTime);
            inputHandler.Update(gameTime);
            player.Update(gameTime);

            // Spwan an enemy object if a certain amount of time has passed.
            elapsedTime = gameTime.TotalGameTime.Seconds;
            
            nextSpawnTime -= gameTime.ElapsedGameTime.Milliseconds;
            if (nextSpawnTime <= 0)
            {
                enemies.Add(factory.CreateEnemy(rand.Next(1,100)));
                nextSpawnTime = rand.Next(spawnTimeMin, spawnTimeMax);
            }

            foreach (IShip enemy in enemies)
            {
                enemy.Update(gameTime);
            }

            // Checks collision for:
            // Player & enemy.
            // Player bullets & enemies.
            // Enemy bullets & player.
            CheckCollisions();
        }

        /// <summary>
        /// Draws all the components in the game.
        /// Draws the player, enemies bullers and hud.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            bulletFactory.Draw(spriteBatch);
            player.Draw(spriteBatch);
            hud.Draw(spriteBatch);
            spriteBatch.DrawString(font, "Time Played: "+elapsedTime , new Vector2(game.Window.ClientBounds.Right - 140, game.Window.ClientBounds.Top),Color.White);
            foreach (IShip enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }

        public void CheckCollisions()
        {
            playerBounds = new Rectangle((int)(player.Position.X), (int)(player.Position.Y), player.Width, player.Height);

            // Check enemy ship collision with player.
            foreach (IShip enemy in enemies)
            {
                if (enemy.Hitpoints <= 0)
                {
                    enemies.Remove(enemy);
                    player.AddScore(enemyScore);
                    break;
                }
                enemyBounds = new Rectangle((int)(enemy.Position.X), (int)(enemy.Position.Y), enemy.Width, enemy.Height);
                if (playerBounds.Intersects(enemyBounds))
                {
                    player.AddHealth(-20);
                    enemies.Remove(enemy);
                    break;
                }
            }

            // Check projectile collisions.
            foreach (Projectile p in bulletFactory.Protectiles)
            {
                projectileBounds = new Rectangle((int)(p.Position.X), (int)(p.Position.Y), p.Width, p.Height);
                if (playerBounds.Intersects(projectileBounds) && p.Tag == "enemy")
                {
                    player.AddHealth(-p.Damage);
                    bulletFactory.Protectiles.Remove(p);

                    return;
                }

                foreach (IShip enemy in enemies)
                {
                    enemyBounds = new Rectangle((int)(enemy.Position.X), (int)(enemy.Position.Y), enemy.Width, enemy.Height);
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
