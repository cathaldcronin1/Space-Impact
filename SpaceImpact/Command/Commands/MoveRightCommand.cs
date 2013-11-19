using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceImpact
{
    public class MoveRightCommand : Command
    {
        ShipHull commandShip;

        public MoveRightCommand(ShipHull ship)
        {
            commandShip = ship;
        }
        public void Execute()
        {
            commandShip.MoveRight();
        }
    }
}
