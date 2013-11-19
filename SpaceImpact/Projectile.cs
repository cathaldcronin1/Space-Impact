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

        public Projectile(Texture2D tex, Vector2 pos, Vector2 dir, int spd)
        {
            texture = tex;
            Position = pos;
            direction = dir;
            speed = spd;
        }

        public void Update(GameTime gameTime)
        {
            direction.Normalize();
            Position += direction * speed;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, Position, Color.White);
        }
    }
}
