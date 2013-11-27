using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace SpaceImpact
{

    class StartMenu 
    {

        MenuComponent menuList;

        public StartMenu(MenuComponent newMenuComponent)
        {
            menuList = newMenuComponent;
        }

        public void draw(SpriteBatch spritebatch)
        {
            menuList.Draw(spritebatch);
        }

    }
}
