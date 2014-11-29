using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceImpact
{
    public class HeavyShield : ShipComponent
    {
        public HeavyShield(IShip newShip) : base(newShip) { }

        public override int Hitpoints
        {
            get { return 30 + base.Hitpoints; }
            set { tempShip.Hitpoints = value; }
        }

        public override int WeaponDamage
        {
            get { return base.WeaponDamage; }
            set { tempShip.WeaponDamage = value; }
        }

        public override string Description
        {
            get { return "Heavy Shield, " + base.Description; }
            set { tempShip.Description = value; }
        }
    }
}
