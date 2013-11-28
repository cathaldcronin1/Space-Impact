using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceImpact
{
    class CreditsScreen : IScreen
    {
        SpriteFont font = Game1.Instance.Content.Load<SpriteFont>("MyFont");
        KeyboardState keyState = Keyboard.GetState();
        private KeyboardState oldKeyState;

        public void Update(GameTime gametime)
        {
            keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Back) && !oldKeyState.IsKeyDown(Keys.Back) || GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                Game1.Instance.mainMenu();
            }
            oldKeyState = keyState;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "Dualtagh Murray\n\nCathal Cronin", new Vector2(100, 100), Color.White);
        }
    }
}
