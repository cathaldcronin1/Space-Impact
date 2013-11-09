using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceImpact
{
    public class MoveUpCommand : Command
    {
        ShipHull commandShip;

        public MoveUpCommand(ShipHull ship)
        {
            commandShip = ship;
        }
        public void Execute()
        {
            commandShip.MoveUp();
        }
    }
}
