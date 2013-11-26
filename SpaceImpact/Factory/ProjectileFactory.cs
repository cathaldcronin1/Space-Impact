using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceImpact
{
    public class ProjectileFactory
    {
        private ContentManager content;
        private Texture2D bulletTexture;
        private Vector2 left, right;
        private List<Projectile> projectiles;

        public List<Projectile> Protectiles
        {
            get { return projectiles; }
        }

        public ProjectileFactory(ContentManager content)
        {
            this.content = content;
            bulletTexture = content.Load<Texture2D>("bullet.png");
            left = new Vector2(-1,0);
            right = new Vector2(1,0);
            projectiles = new List<Projectile>();
        }

        public void ShootBulletPlayer(Vector2 pos, int damage)
        {
            projectiles.Add(new Projectile(bulletTexture, pos, right, 10, "player", damage));
        }

        public void ShootBulletEnemy(Vector2 pos, int damage)
        {
            projectiles.Add(new Projectile(bulletTexture, pos, left, 10, "enemy", damage));
        }

        public void Update(GameTime gameTime)
        {
            foreach (Projectile p in projectiles)
            {
                p.Update(gameTime);
                if (Game1.Instance.OutOfBounds(p.Position))
                {
                    projectiles.Remove(p);
                    break;
                }
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            foreach (Projectile p in projectiles)
                p.Draw(spritebatch);
        }
    }
}
