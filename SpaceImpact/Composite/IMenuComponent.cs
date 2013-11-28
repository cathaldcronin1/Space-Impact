using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceImpact
{
    public interface IMenuComponent
    {
        // Methods to be implemented for menu tree.
        void Add(IMenuComponent c);
        void Select();
        void DeSelect();
        bool Selected();
        string GetName();
    }
}