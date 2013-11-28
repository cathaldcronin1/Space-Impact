using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceImpact
{
    public interface IShip
    {
        // Properties for Ships.
        int Hitpoints { get; set; }
        int WeaponDamage { get; set; }
        string Description { get; set; }
        Vector2 Position { get; }
        int Width { get; }
        int Height { get; }

        // Methods for updating and drawing the ships.
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spritebatch);
    }
}
