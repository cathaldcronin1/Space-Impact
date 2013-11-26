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

        public ShipFactory(ContentManager content) 
        {
            this.content = content;
            weakEnemyTexture = content.Load<Texture2D>("enemy.png");
        }

        public Ship CreateEnemy(int rand)
        {
            if (rand > 90)
            {
                return null;//Create tough enemy
            }
            else if (rand > 70)
            {
                return null;//create Strong enemy
            }
            else if (rand > 30)
            {
                return null;//create medium enemy
            }
            else
            {
                return CreateWeakEnemy();
            }
        }

        private Ship CreateWeakEnemy()
        {
            return new BasicGun(new ShipHull(content.Load<Texture2D>("enemy.png"), new Vector2(700,200),Vector2.Zero, new PassiveState()));
        }
    }
}
