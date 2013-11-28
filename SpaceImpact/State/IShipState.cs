using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceImpact
{
    // A Ship State Interface.
    public interface IShipState
    {
        // Logic for a ships behaviour.
        void Update(GameTime gameTime, ShipHull ship);

        // Allows us to change behaviour dynamically.
        IShipState SetState(IShipState newState);
    }
}
