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
        // Gamepad states for checking input. 
        GamePadState gamepadState = GamePad.GetState(PlayerIndex.One);
        GamePadState oldGamepadState;

        /// <summary>
        /// Checks if the Dpad up button has been pressed.
        /// </summary>
        /// <returns>bool</returns>
        public bool Up()
        {
            if (gamepadState.DPad.Up == ButtonState.Pressed)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks if the Dpad down button has been pressed.
        /// </summary>
        /// <returns>bool</returns>
        public bool Down()
        {
            if (gamepadState.DPad.Down == ButtonState.Pressed)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks if the Dpad left button has been pressed.
        /// </summary>
        /// <returns>bool</returns>
        public bool Left()
        {
            if (gamepadState.DPad.Left == ButtonState.Pressed)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks if the Dpad right button has been pressed.
        /// </summary>
        /// <returns>bool</returns>
        public bool Right()
        {
            if (gamepadState.DPad.Right == ButtonState.Pressed)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks if the A button has been pressed.
        /// </summary>
        /// <returns>bool</returns>
        public bool Shoot()
        {
            if (gamepadState.Buttons.A == ButtonState.Pressed && oldGamepadState.Buttons.A != ButtonState.Pressed)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Updates the gamepad states. 
        /// </summary>
        public void Update()
        {
            oldGamepadState = gamepadState;
            gamepadState = GamePad.GetState(PlayerIndex.One);
        }
    }
}
