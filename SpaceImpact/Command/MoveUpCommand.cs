using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceImpact
{
    public class MoveUpCommand : ICommand
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
