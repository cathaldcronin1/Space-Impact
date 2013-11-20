using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceImpact
{
    public interface I_Subject
    {
        void Register(I_Observer o);
        void Unregister(I_Observer o);
        void NotifyObserver();
    }
}
