using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceImpact
{
    public class PassiveState : I_ShipState
    {
        private int minShootTime = 2000;
        private int maxShootTime = 4000;
        private int nextShootTime = 500;
        private Random rand = new Random();

        public void Update(GameTime gameTime, ShipHull ship)
        {
            nextShootTime -= gameTime.ElapsedGameTime.Milliseconds;
            if (nextShootTime <= 0)
            {
                ship.Shoot();
                nextShootTime = rand.Next(minShootTime, maxShootTime);
            }
            // AI logic goes here
            ship.MoveLeft();
        }

        public I_ShipState setState(I_ShipState newState)
        {
            return newState;
        }

        public override string ToString()
        {
            return "passive state";
        }
    }
}
