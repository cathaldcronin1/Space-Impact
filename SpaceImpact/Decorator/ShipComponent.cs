using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceImpact
{
    public abstract class ShipComponent : Ship
    {
        protected Ship tempShip;

        public ShipComponent(Ship newShip)
        {
            tempShip = newShip;
        }

        public virtual int Hitpoints
        {
            get { return tempShip.Hitpoints; }
            set { tempShip.Hitpoints = value; }
        }

        public virtual int WeaponDamage
        {
            get { return tempShip.WeaponDamage; }
            set { tempShip.WeaponDamage = value; }
        }

        public virtual string Description
        {
            get { return tempShip.Description; }
            set { tempShip.Description = value; }
        }
    }
}
