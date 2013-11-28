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
        private Texture2D toughEnemyTexture;
        Random rand;
        
        /// <summary>
        /// Creates an instance of a ShipFactory.
        /// </summary>
        /// <param name="content"></param>
        public ShipFactory(ContentManager content) 
        {
            this.content = content;
            weakEnemyTexture = content.Load<Texture2D>("enemy.png");
            toughEnemyTexture = content.Load<Texture2D>("enemy2.png");
            rand = new Random();
        }

        /// <summary>
        /// Creates a Ship. 
        /// </summary>
        /// <param name="rand">Int passed to determine which ship should be created.</param>
        /// <returns>Ship</returns>
        public IShip CreateEnemy(int rand)
        {
            if (rand > 75)
            {
                return CreateToughEnemy();
            }
            else
            {
                return CreateWeakEnemy();
            }
        }

        /// <summary>
        /// Creates a weak enemy ship using the decorator pattern.
        /// </summary>
        /// <returns></returns>
        private IShip CreateWeakEnemy()
        {
            return new BasicGun(new ShipHull(weakEnemyTexture, new Vector2(SpaceImpact.Instance.Window.ClientBounds.Right, 
                rand.Next(SpaceImpact.Instance.Window.ClientBounds.Top + 30, SpaceImpact.Instance.Window.ClientBounds.Bottom - 100)), Vector2.Zero, new PassiveState()));
        }

        /// <summary>
        /// Creates a strong enemy ship using the decorator pattern.
        /// </summary>
        /// <returns></returns>
        private IShip CreateToughEnemy()
        {
            return new HeavyShield(new HeavyGun(new ShipHull(toughEnemyTexture, new Vector2(SpaceImpact.Instance.Window.ClientBounds.Right,
                rand.Next(SpaceImpact.Instance.Window.ClientBounds.Top + 30, SpaceImpact.Instance.Window.ClientBounds.Bottom - 100)), Vector2.Zero, new AggressiveState())));
        }
    }
}
