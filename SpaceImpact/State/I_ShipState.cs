using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceImpact
{
    public interface I_ShipState
    {
        void Update(GameTime gameTime, ShipHull ship);
        I_ShipState setState(I_ShipState newState);
    }
}
