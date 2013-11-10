using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SpaceImpact
{
    public class ShipHull : Ship
    {

        private Texture2D textureImage;
        protected Vector2 position;
        protected Vector2 speed;

        public ShipHull()
        {
            // TODO: Complete member initialization
        }

        public ShipHull(Texture2D textureImage, Vector2 position, Vector2 speed)
        {
            this.textureImage = textureImage;
            this.position = position;
            this.speed = speed;
        }

        // Get the width of the player ship
        public int Width
        {
            get { return textureImage.Width; }
        }

        // Get the height of the player ship
        public int Height
        {
            get { return textureImage.Height; }
        }

        public int Hitpoints
        {
            get { return 100; }
            set { Hitpoints = value; }
        }

        public int WeaponDamage
        {
            get { return 20; }
            set { WeaponDamage = value; }
        }

        public string Description
        {
            get { return "Hull"; }
            set { Description = value; }
        }

        public void Initialize()
        {

        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(textureImage, this.position, Color.White);
         
        }

        public void MoveUp()
        {
            this.position.Y -= 1;
        }

        public void MoveDown()
        {
            this.position.Y += 1;
        }

        public void MoveLeft()
        {
            this.position.X -= 1;
        }

        public void MoveRight()
        {
            this.position.X += 1;
        }
    }
}