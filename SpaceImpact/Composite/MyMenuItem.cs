using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceImpact
{
    //class MyMenuItem : MenuComponent
    //{
    //    private List<MenuComponent> menuItems = new List<MenuComponent>();
    //    SpriteFont spriteFont = Game1.Instance.Content.Load<SpriteFont>("MyFont");
    //    Vector2 position = new Vector2(200,300);
    //    int selectedIndex;

    //    KeyboardState keyboardState;
    //    KeyboardState oldKeyboardState;

    //    public MyMenuItem(String name) : base(name) 
    //    {
    //    }

    //    public MyMenuItem()
    //    {
           
    //    }
    
    //    public override void addMenu(MenuComponent menu)
    //    {
    //        menuItems.Add(menu);
    //    }

    //    public override List<MenuComponent> iterator() 
    //    {
    //        return menuItems;
    //    }

    //    public override void Update(GameTime gameTime)
    //    {
    //        keyboardState = Keyboard.GetState();

    //        if (CheckKey(Keys.Down))
    //        {
    //            selectedIndex++;
    //            if (selectedIndex == menuItems.Count)
    //                selectedIndex = 0;
    //        }
    //        if (CheckKey(Keys.Up))
    //        {
    //            selectedIndex--;
    //            if (selectedIndex < 0)
    //                selectedIndex = menuItems.Count - 1;
    //        }
    //        base.Update(gameTime);

    //        oldKeyboardState = keyboardState;
    //    }

    //    public override void Draw(SpriteBatch spriteBatch)
    //    {
    //        Console.WriteLine("2222222222222");
    //        Console.WriteLine("menuItems: " + menuItems.Count);
    //        for (int i = 0; i < menuItems.Count(); i++)
    //        {
    //            Console.WriteLine("name of menuitem is " + menuItems[i].getName() + "\nposittion is " + position);
    //            spriteBatch.DrawString(spriteFont, menuItems[i].getName(), position, Color.White);
    //            //position.Y += spriteFont.LineSpacing + 5;
    //        }
    //    }

    //    private bool CheckKey(Keys theKey)
    //    {
    //        return keyboardState.IsKeyUp(theKey) &&
    //            oldKeyboardState.IsKeyDown(theKey);
    //    }
    //}
}
