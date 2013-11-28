using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceImpact
{
    public class HeavyGun : ShipComponent
    {
        public HeavyGun(IShip newShip) : base(newShip) { }
        
        public override int Hitpoints
        {
            get { return base.Hitpoints; }
            set { tempShip.Hitpoints = value; }
        }

        public override int WeaponDamage
        {
            get { return 30 + base.WeaponDamage; }
            set { tempShip.WeaponDamage = value; }
        }

        public override string Description
        {
            get { return "Heavy Gun, " + base.Description; }
            set { tempShip.Description = value; }
        }
    }
}
