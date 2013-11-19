using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace SpaceImpact
{
    public class KeyboardInput : I_InputDevice
    {
        KeyboardState keyState = Keyboard.GetState();
        KeyboardState oldKeyState;

        public bool Up()
        {
            if (keyState.IsKeyDown(Keys.Up))
                return true; 
            else 
                return false;
        }

        public bool Down()
        {
            if (keyState.IsKeyDown(Keys.Down))
                return true;
            else
                return false;
        }

        public bool Left()
        {
            if (keyState.IsKeyDown(Keys.Left))
                return true;
            else
                return false;
        }

        public bool Right()
        {
            if (keyState.IsKeyDown(Keys.Right))
                return true;
            else
                return false;
        }

        public bool Shoot()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            oldKeyState = keyState;
            keyState = Keyboard.GetState();
        }
    }
}
