using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceImpact
{
    public class Projectile
    {
        private Texture2D texture;
        private Vector2 direction;
        private int speed;
        
        public Vector2 Position { get; private set;}
        public string Tag { get; private set; }
        public int Damage { get; private set; }

        /// <summary>
        /// Creates a projectile.
        /// </summary>
        public Projectile(Texture2D tex, Vector2 pos, Vector2 dir, int spd, string tag, int damage)
        {
            texture = tex;
            Position = pos;
            direction = dir;
            speed = spd;
            Tag = tag;
            Damage = damage;
        }

        // Get the width of the projectile
        public int Width
        {
            get { return texture.Width; }
        }

        // Get the height of the projectile
        public int Height
        {
            get { return texture.Height; }
        }

        /// <summary>
        /// Updates projectile. Moves projectile based on direction and speed.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            direction.Normalize();
            Position += direction * speed;
        }

        /// <summary>
        /// Draws projectile at position.
        /// </summary>
        /// <param name="spritebatch"></param>
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, Position, Color.White);
        }
    }
}
