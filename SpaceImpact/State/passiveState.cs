using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceImpact
{
    public class PassiveState : I_ShipState
    {
        public void Update(GameTime gameTime, ShipHull ship)
        {
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
