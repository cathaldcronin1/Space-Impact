using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceImpact
{
    /// <summary>
    /// A concrete screen to show the credits of the game.
    /// </summary>
    class CreditsScreen : IScreen
    {

        SpriteFont font = SpaceImpact.Instance.Content.Load<SpriteFont>("MyFont");
        KeyboardState keyState = Keyboard.GetState();
        KeyboardState oldKeyState;

        public CreditsScreen()
        {
            
        }

        public void Update(GameTime gametime)
        {
            keyState = Keyboard.GetState();

            // If the backspace key is pressed we want to return to the mainMenu of the game.
            if (keyState.IsKeyDown(Keys.Back) && !oldKeyState.IsKeyDown(Keys.Back) || GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                SpaceImpact.Instance.mainMenu();
            }
            oldKeyState = keyState;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "Dualtagh Murray\n\nCathal Cronin", new Vector2(100, 100), Color.White);
        }
    }
}
