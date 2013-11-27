using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SpaceImpact
{
    class StartScreen
    {
        MenuComponent startMenu = new MenuItem("");
        MenuComponent options = new MenuItem("options");
        public StartScreen(Game1 game)
        {
            Console.WriteLine("1111111111111");

            options.add(new MenuItem("Credits"));

            startMenu.add(new MenuItem("Start Game"));
            startMenu.add(options);
            startMenu.add(new MenuItem("Quit"));
            
            Console.WriteLine("222222222222");
        }

        public void Update()
        {
            //startmenu.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            startMenu.Draw(spriteBatch) ;
        }
    }
}
