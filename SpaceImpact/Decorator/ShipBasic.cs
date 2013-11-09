using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceImpact
{
    public class ShipBasic : Ship
    {
        
        public int Hitpoints
        {
            get { return 100; }
            set { Hitpoints = value; }
        }

        public int WeaponDamage
        {
            get { return 20; }
            set { WeaponDamage = value; }
        }

        public string Description
        {
            get { return "Hull"; }
            set { Description = value; }
        }
    }
}
