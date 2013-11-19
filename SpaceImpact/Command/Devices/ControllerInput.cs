using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SpaceImpact
{
    public class ControllerInput : I_InputDevice
    {
        GamePadState gamepadState = GamePad.GetState(PlayerIndex.One);
        GamePadState oldGamepadState;

        public bool Up()
        {
            if (gamepadState.DPad.Up == ButtonState.Pressed)
                return true;
            else
                return false;
        }

        public bool Down()
        {
            if (gamepadState.DPad.Down == ButtonState.Pressed)
                return true;
            else
                return false;
        }

        public bool Left()
        {
            if (gamepadState.DPad.Left == ButtonState.Pressed)
                return true;
            else
                return false;
        }

        public bool Right()
        {
            if (gamepadState.DPad.Right == ButtonState.Pressed)
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
            oldGamepadState = gamepadState;
            gamepadState = GamePad.GetState(PlayerIndex.One);
        }
    }
}
