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
        private ShipHull playerShip;
        private Command moveRight;
        private Command moveLeft;
        private Command moveUp;
        private Command moveDown;
        private Command noCommand;
        private Command currentCommand;

        GamePadState gamePadState;
        I_InputDevice input;

        public InputHandler(ShipHull player)
        {
            playerShip = player;
            moveRight = (Command)(new MoveRightCommand(playerShip));
            moveLeft = (Command)(new MoveLeftCommand(playerShip));
            moveUp = (Command)(new MoveUpCommand(playerShip));
            moveDown = (Command)(new MoveDownCommand(playerShip));
            noCommand = (Command)(new NoCommand());

            gamePadState = GamePad.GetState(PlayerIndex.One);

            if (gamePadState.IsConnected)
                input = new ControllerInput();
            else
                input = new KeyboardInput();
        }

        public Command HandleInput()
        {
            if (input.Left())
            {
                Console.WriteLine("Left key pressed");
                return moveLeft;
            }
            else if (input.Right())
            {
                Console.WriteLine("Right key pressed");
                return moveRight;
            }
            else if (input.Up())
            {
                Console.WriteLine("Up key pressed");
                return moveUp;
            }
            else if (input.Down())
            {
                Console.WriteLine("Down key pressed");
                return moveDown;
            }
            return noCommand;
        }
    

        public void Update()
        {

            currentCommand = HandleInput();
            currentCommand.Execute();
            input.Update();
        }
    }
}
