﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceImpact
{
    public class MoveDownCommand : ICommand
    {
        ShipHull commandShip;

        public MoveDownCommand(ShipHull ship)
        {
            commandShip = ship;
        }
        public void Execute()
        {
            commandShip.MoveDown();
        }
    }
}
