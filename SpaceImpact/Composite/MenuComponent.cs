using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceImpact
{
    public interface MenuComponent
    {
        void Add(MenuComponent c);
        void Select();
        void DeSelect();
        bool Selected();
        string GetName();
    }
}