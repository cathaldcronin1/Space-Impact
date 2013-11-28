using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceImpact
{
    public class PassiveState : IShipState
    {
        private const int MinShootTime = 2000;
        private const int MaxShootTime = 4000;
        private int nextShootTime = 500;
        private Random rand = new Random();

        // Basic ship AI so it only needs to move left and shoot occasionally.
        public void Update(GameTime gameTime, ShipHull ship)
        {
            // Period of when to shoot next projectile.
            nextShootTime -= gameTime.ElapsedGameTime.Milliseconds;
            if (nextShootTime <= 0)
            {
                ship.Shoot();
                nextShootTime = rand.Next(MinShootTime, MaxShootTime);
            }

            ship.MoveLeft();
        }

        // Allows you to Dynamically change a ships state.
        public IShipState SetState(IShipState newState)
        {
            return newState;
        }

        public override string ToString()
        {
            return "passive state";
        }
    }
}
