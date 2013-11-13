using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
namespace SpaceImpact
{
    class Player : ShipHull//, Ship
    {
        public Player(Texture2D textureImage, Vector2 position, Vector2 speed)
            : base(textureImage, position, speed)
        {

        }

    }
}