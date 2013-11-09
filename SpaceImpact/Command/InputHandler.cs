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

        private KeyboardState oldKeyState;
        private KeyboardState currentkeyState;

        public InputHandler(ShipHull player)
        {
            playerShip = player;
            moveRight = (Command)(new MoveRightCommand(playerShip));
            moveLeft = (Command)(new MoveLeftCommand(playerShip));
            moveUp = (Command)(new MoveUpCommand(playerShip));
            moveDown = (Command)(new MoveDownCommand(playerShip));
            noCommand = (Command)(new NoCommand());

            currentkeyState = Keyboard.GetState();
        }

        public Command HandleInput()
        {
            if (currentkeyState.IsKeyDown(Keys.Left))
            {
                return moveLeft;
            }
            else if (currentkeyState.IsKeyDown(Keys.Right))
            {
                return moveRight;
            }
            else if (currentkeyState.IsKeyDown(Keys.Up))
            {
                return moveUp;
            }
            else if (currentkeyState.IsKeyDown(Keys.Down))
            {
                return moveDown;
            }
            return noCommand;
        }
    

        public void Update()
        {
            currentkeyState = Keyboard.GetState();

            currentCommand = HandleInput();
            currentCommand.Execute();

            oldKeyState = currentkeyState;
        }
    }
}
