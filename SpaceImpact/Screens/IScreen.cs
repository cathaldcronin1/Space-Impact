using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceImpact
{
    /// <summary>
    /// Interface for all screens to implement.
    /// All screens need to be drawn and updated.
    /// </summary>
    interface IScreen
    {
        void Update(GameTime gametime);
        void Draw(SpriteBatch spriteBatch);
    }
}
