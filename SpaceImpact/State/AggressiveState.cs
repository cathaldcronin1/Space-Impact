using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceImpact
{
    public class AggressiveState : IShipState
    {
        private bool goingDown;
        private const int MinShootTime = 1000;
        private const int MaxShootTime = 2000;
        private int nextShootTime = 500;
        private Random rand = new Random();

        // Aggressive styled AI, Moves and shoots faster.
        public void Update(GameTime gameTime, ShipHull ship)
        {
            // Period of when to shoot next projectile.
            nextShootTime -= gameTime.ElapsedGameTime.Milliseconds;
            if (nextShootTime <= 0)
            {
                ship.Shoot();
                nextShootTime = rand.Next(MinShootTime, MaxShootTime);
            }
            if (ship.Position.Y < SpaceImpact.Instance.Window.ClientBounds.Top + 50)
                goingDown = true;
            else if (ship.Position.Y > SpaceImpact.Instance.Window.ClientBounds.Bottom - ship.Height)
                goingDown = false;


            // Movement behaviour of a ship
            if (goingDown)
            {
                ship.MoveLeft();
                ship.MoveDown();
            }
            else
            {
                ship.MoveLeft();
                ship.MoveUp();
            }

        }

        // Allows you to Dynamically change a ships state.
        public IShipState SetState(IShipState newState)
        {
            return newState;
        }

        public override string ToString()
        {
            return "aggressive state";
        }
    }
}
