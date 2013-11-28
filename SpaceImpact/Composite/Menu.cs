using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceImpact
{
    public class Menu : IMenuComponent
    {
        // List of menu componets.
        List<IMenuComponent> components = new List<IMenuComponent>();
        string menuName;
        bool selected;

        /// <summary>
        /// Creates an instance of a Menu.
        /// </summary>
        /// <param name="menuName">Name of the menu</param>
        public Menu(string menuName)
        {
            this.menuName = menuName;
            selected = false;
        }

        /// <summary>
        /// Adds a menu component to the menu.
        /// </summary>
        /// <param name="c">MenuComponent object to be added to list</param>
        public void Add(IMenuComponent c)
        {
            components.Add(c);
        }

        /// <summary>
        /// Returns the name of the menu.
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return menuName;
        }

        /// <summary>
        /// Returns the list of components in the menu.
        /// </summary>
        /// <returns></returns>
        public List<IMenuComponent> GetList()
        {
            return components;
        }

        /// <summary>
        /// Sets the Menu to selected so it can be highlighted.
        /// </summary>
        public void Select()
        {
            selected = true;
        }

        /// <summary>
        /// Sets the Menu to not be selected.
        /// </summary>
        public void DeSelect()
        {
            selected = false;
        }

        /// <summary>
        /// Returns a bool of whether the Menu is selected or not.
        /// </summary>
        /// <returns></returns>
        public bool Selected()
        {
            return selected;
        }
    }
}
