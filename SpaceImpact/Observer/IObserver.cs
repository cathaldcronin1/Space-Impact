using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceImpact
{
    public interface IObserver
    {
        void UpdateStats(int score, int health, int ammo);
    }
}
