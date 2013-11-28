using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceImpact
{
    public class MenuLeaf : IMenuComponent
    {
        string menuLeafName;
        bool selected;
        // Delegate method
        StartScreen.ExecuteMethod execute;

        /// <summary>
        /// Creates an instance of a MenuLeaf.
        /// </summary>
        /// <param name="menuLeafName">Name of the menu leaf</param>
        /// <param name="execute">Delegate method for execution</param>
        public MenuLeaf(string menuLeafName, StartScreen.ExecuteMethod execute)
        {
            this.menuLeafName = menuLeafName;
            selected = false;
            this.execute = execute;
        }

        /// <summary>
        /// Not implemented as MenuLeaf will not be a composite.
        /// </summary>
        /// <param name="c"></param>
        public void Add(IMenuComponent c)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the name of the menu leaf.
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return menuLeafName;
        }

        /// <summary>
        /// Sets the menu leaf to selected.
        /// </summary>
        public void Select()
        {
            selected = true;
        }

        /// <summary>
        /// Sets the menu leaf to not selected.
        /// </summary>
        public void DeSelect()
        {
            selected = false;
        }

        /// <summary>
        /// Returns a bool of whether or not the menu leaf is selected.
        /// </summary>
        /// <returns></returns>
        public bool Selected()
        {
            return selected;
        }

        /// <summary>
        /// Executes the functionality provided by the delegate.
        /// </summary>
        public void Execute()
        {
            // This is a delegate.
            execute();
        }
    }
}
