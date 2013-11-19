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

            if (ship.Position.Y < 50)
                goingDown = true;
            else if (ship.Position.Y > 350)
                goingDown = false;
        }
    }
}
