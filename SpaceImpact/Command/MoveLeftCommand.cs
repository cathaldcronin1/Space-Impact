using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceImpact
{
    public class MoveLeftCommand : Command
    {
        ShipHull commandShip;

        public MoveLeftCommand(ShipHull ship)
        {
            commandShip = ship;
        }
        public void Execute()
        {
            commandShip.MoveLeft();
        }
    }
}
