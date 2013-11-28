using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace SpaceImpact
{
    public class KeyboardInput : IInputDevice
    {
        // Keyboard states for checking input.
        KeyboardState keyState = Keyboard.GetState();
        KeyboardState oldKeyState;

        /// <summary>
        /// Checks if the up key on the keyboard has been pressed.
        /// </summary>
        /// <returns>bool</returns>
        public bool Up()
        {
            if (keyState.IsKeyDown(Keys.Up))
                return true; 
            else 
                return false;
        }

        /// <summary>
        /// Checks if the down key on the keyboard has been pressed.
        /// </summary>
        /// <returns>bool</returns>
        public bool Down()
        {
            if (keyState.IsKeyDown(Keys.Down))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks if the left key on the keyboard has been pressed.
        /// </summary>
        /// <returns>bool</returns>
        public bool Left()
        {
            if (keyState.IsKeyDown(Keys.Left))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks if the right key on the keyboard has been pressed.
        /// </summary>
        /// <returns>bool</returns>
        public bool Right()
        {
            if (keyState.IsKeyDown(Keys.Right))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks if the space key on the keyboard has been pressed.
        /// </summary>
        /// <returns>bool</returns>
        public bool Shoot()
        {
            if (keyState.IsKeyDown(Keys.Space) && !oldKeyState.IsKeyDown(Keys.Space))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Updates the keyboard states.
        /// </summary>
        public void Update()
        {
            oldKeyState = keyState;
            keyState = Keyboard.GetState();
        }
    }
}
