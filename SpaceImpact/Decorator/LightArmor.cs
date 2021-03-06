﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceImpact
{
    public class LightArmor : ShipComponent
    {
        public LightArmor(IShip newShip) : base(newShip) { }
        
        public override int Hitpoints
        {
            get { return 50 + base.Hitpoints; }
            set { tempShip.Hitpoints = value; }
        }

        public override int WeaponDamage
        {
            get { return base.WeaponDamage; }
            set { tempShip.WeaponDamage = value; }
        }

        public override string Description
        {
            get { return "Light Armor, " + base.Description; }
            set { tempShip.Description = value; }
        }
    }
}
