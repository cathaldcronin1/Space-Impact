using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SpaceImpact
{
    class Credits : MenuComponent
    {
        public Credits()
        {

        }

        //public void execute()
        //{

        //}

        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(null, Vector2.Zero, Color.Black);
            spritebatch.DrawString(Game1.Instance.Content.Load<SpriteFont>("MyFont"), "Cathal Cronin\n Dualtagh Murray", Vector2.Zero, Color.White);
        }
    }
}
