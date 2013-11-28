using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceImpact
{
    public class Menu : MenuComponent
    {
        List<MenuComponent> components = new List<MenuComponent>();
        string menuName;
        bool selected;

        public Menu(string menuName)
        {
            this.menuName = menuName;
            selected = false;
        }

        public void Add(MenuComponent c)
        {
            components.Add(c);
        }

        public string GetName()
        {
            return menuName;
        }

        public List<MenuComponent> GetList()
        {
            return components;
        }

        public void Select()
        {
            selected = true;
        }

        public void DeSelect()
        {
            selected = false;
        }

        public bool Selected()
        {
            return selected;
        }
    }
}
