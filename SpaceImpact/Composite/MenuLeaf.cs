using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceImpact
{
    public class MenuLeaf : MenuComponent
    {
        string menuLeafName;
        bool selected;
        StartScreen.ExecuteMethod execute;

        public MenuLeaf(string menuLeafName, StartScreen.ExecuteMethod execute)
        {
            this.menuLeafName = menuLeafName;
            selected = false;
            this.execute = execute;
        }

        public void Add(MenuComponent c)
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            return menuLeafName;
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

        public void Execute()
        {
            execute();
        }
    }
}
