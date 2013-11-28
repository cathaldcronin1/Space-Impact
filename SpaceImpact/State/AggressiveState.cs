using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceImpact
{
    public class AggressiveState : I_ShipState
    {
        private bool goingDown;
        private int minShootTime = 1000;
        private int maxShootTime = 2000;
        private int nextShootTime = 500;
        private Random rand = new Random();

        public void Update(GameTime gameTime, ShipHull ship)
        {
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

            nextShootTime -= gameTime.ElapsedGameTime.Milliseconds;
            if (nextShootTime <= 0)
            {
                ship.Shoot();
                nextShootTime = rand.Next(minShootTime, maxShootTime);
            }
            if (ship.Position.Y < Game1.Instance.Window.ClientBounds.Top + 50)
                goingDown = true;
            else if (ship.Position.Y > Game1.Instance.Window.ClientBounds.Bottom - ship.Height)
                goingDown = false;
        }

        public I_ShipState setState(I_ShipState newState)
        {
            return newState;
        }

        public override string ToString()
        {
            return "aggressive state";
        }
    }
}
