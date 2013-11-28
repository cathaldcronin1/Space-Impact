using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceImpact
{
    public class ShootCommand : ICommand
    {
        ShipHull commandShip;

        public ShootCommand(ShipHull ship)
        {
            commandShip = ship;
        }
        public void Execute()
        {
            commandShip.Shoot();
        }
    }
}
