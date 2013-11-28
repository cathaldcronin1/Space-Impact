using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceImpact
{
    public class ProjectileManager
    {
        private ContentManager content;
        private Texture2D bulletTexture;
        private Vector2 left, right;
        private List<Projectile> projectiles;

        // List of the projectiles on screen
        public List<Projectile> Protectiles
        {
            get { return projectiles; }
        }

        /// <summary>
        /// Creates and instance of the projectile manager.
        /// </summary>
        /// <param name="content"></param>
        public ProjectileManager(ContentManager content)
        {
            this.content = content;
            bulletTexture = content.Load<Texture2D>("bulletSmall.png");
            left = new Vector2(-1,0);
            right = new Vector2(1,0);
            projectiles = new List<Projectile>();
        }

        /// <summary>
        /// Shoots a bullet to the right from a given position.
        /// </summary>
        public void ShootBulletRight(Vector2 pos, int damage)
        {
            projectiles.Add(new Projectile(bulletTexture, pos, right, 10, "player", damage));
        }

        /// <summary>
        /// Shoots a bullet to the left from a given position.
        /// </summary>
        public void ShootBulletLeft(Vector2 pos, int damage)
        {
            projectiles.Add(new Projectile(bulletTexture, pos, left, 10, "enemy", damage));
        }

        /// <summary>
        /// Updates the projectiles on screen.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            foreach (Projectile p in projectiles)
            {
                p.Update(gameTime);
                if (SpaceImpact.Instance.OutOfBounds(p.Position))
                {
                    projectiles.Remove(p);
                    break;
                }
            }
        }

        /// <summary>
        /// Draws the projectiles on screen.
        /// </summary>
        /// <param name="spritebatch"></param>
        public void Draw(SpriteBatch spritebatch)
        {
            foreach (Projectile p in projectiles)
                p.Draw(spritebatch);
        }
    }
}
