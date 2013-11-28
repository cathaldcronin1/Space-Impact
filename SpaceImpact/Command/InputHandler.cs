using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SpaceImpact
{
    public class InputHandler
    {
        private Player playerShip;
        private ICommand moveRight;
        private ICommand moveLeft;
        private ICommand moveUp;
        private ICommand moveDown;
        private ICommand shoot;

        GamePadState gamePadState;
        IInputDevice input;

        /// <summary>
        /// Create instance of an input handler and initialize commands.
        /// </summary>
        /// <param name="player"></param>
        public InputHandler(Player player)
        {
            playerShip = player;
            moveRight = new MoveRightCommand(playerShip);
            moveLeft = new MoveLeftCommand(playerShip);
            moveUp = new MoveUpCommand(playerShip);
            moveDown = new MoveDownCommand(playerShip);
            shoot = new ShootCommand(playerShip);

            gamePadState = GamePad.GetState(PlayerIndex.One);

            // If a gamepad is connected, changes input strategy to the gamepad.
            if (gamePadState.IsConnected)
                input = new ControllerInput();
            else
                input = new KeyboardInput();
        }

        /// <summary>
        /// Checks input device for keypresses.
        /// </summary>
        public void HandleInput()
        {
            if (input.Left())
            {
                Console.WriteLine("Left key pressed");
                moveLeft.Execute();
            }
            if (input.Right())
            {
                Console.WriteLine("Right key pressed");
                moveRight.Execute();
            }
            if (input.Up())
            {
                Console.WriteLine("Up key pressed");
                moveUp.Execute();
            }
            if (input.Down())
            {
                Console.WriteLine("Down key pressed");
                moveDown.Execute();
            }
            if (input.Shoot())
            {
                Console.WriteLine("Shoot key pressed");
                shoot.Execute();
            }
        }
        
        /// <summary>
        /// Updates the input device and checks for input.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            HandleInput();
            input.Update();
        }
    }
}
