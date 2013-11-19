using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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

        public void Update(GameTime gametime)
        {
            tempShip.Update(gametime);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            tempShip.Draw(spritebatch);
        }
    }
}
