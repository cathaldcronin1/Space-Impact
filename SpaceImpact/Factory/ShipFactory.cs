using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceImpact
{
    public class ShipFactory
    {
        private ContentManager content;
        private Texture2D weakEnemyTexture;
        Random rand;
        
        public ShipFactory(ContentManager content) 
        {
            this.content = content;
            weakEnemyTexture = content.Load<Texture2D>("enemy.png");
            rand = new Random();
        }

        public Ship CreateEnemy(int rand)
        {
            if (rand > 90)
            {
                return null;//Create tough enemy
            }
            else
            {
                return CreateWeakEnemy();
            }
        }

        private Ship CreateWeakEnemy()
        {
            return new BasicGun(new ShipHull(weakEnemyTexture, new Vector2(Game1.Instance.Window.ClientBounds.Right, 
                rand.Next(Game1.Instance.Window.ClientBounds.Top + 50, Game1.Instance.Window.ClientBounds.Bottom - 100)), Vector2.Zero, new PassiveState()));
        }
    }
}
