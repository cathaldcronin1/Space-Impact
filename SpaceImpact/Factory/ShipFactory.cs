using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceImpact
{
    public class ShipFactory
    {
        public Ship CreateEnemy(int rand)
        {
            if (rand > 90)
            {
                return null;//Create tough enemy
            }
            else if (rand > 70)
            {
                return null;//create Strong enemy
            }
            else if (rand > 30)
            {
                return null;//create medium enemy
            }
            else
            {
                return CreateWeakEnemy();
            }
        }

        private Ship CreateWeakEnemy()
        {
            return new BasicGun(new ShipHull());
        }
    }
}
