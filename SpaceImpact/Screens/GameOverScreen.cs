using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceImpact.Screens
{
    public class GameOverScreen : IScreen
    {
        SpriteFont font = SpaceImpact.Instance.Content.Load<SpriteFont>("MyFont");
        KeyboardState keyState = Keyboard.GetState();
        KeyboardState oldKeyState;

        public void Update(GameTime gametime)
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
