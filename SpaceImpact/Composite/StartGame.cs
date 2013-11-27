using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceImpact.Screens
{
    class StartGame : MenuComponent
    {
        public StartGame()
        {

        }

        // Placeholder method names
        public void execute()
        {
            Game1.Instance.StartGame();
        }
    }

   
}
