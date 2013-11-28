using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Threading;

namespace SpaceImpact
{
    public class ShipHull : IShip
    {

        private Texture2D textureImage;
        protected Vector2 position;
        protected Vector2 velocity;

        protected IShipState currentState;

        private int hitpoints;
        private int weaponDamage;

        /// <summary>
        /// Create instance of a shiphull. This is a concrete implemenation of a ship.
        /// </summary>
        public ShipHull(Texture2D textureImage, Vector2 position, Vector2 speed, IShipState currentState)
        {
            this.textureImage = textureImage;
            this.position = position;
            this.velocity = speed;
            this.currentState = currentState;
            hitpoints = 100;
            weaponDamage = 20;
            
        }

        public Vector2 Position
        {
            get { return position; }
        }
        
        // Get the width of the ship
        public int Width
        {
            get { return textureImage.Width; }
        }

        // Get the height of the ship
        public int Height
        {
            get { return textureImage.Height; }
        }

        public int Hitpoints
        {
            get { return hitpoints; }
            set { hitpoints = value; }
        }

        public int WeaponDamage
        {
            get { return weaponDamage; }
            set { weaponDamage = value; }
        }

        public string Description
        {
            get { return "Hull"; }
            set { Description = value; }
        }

        /// <summary>
        /// Update the AI for the enemy ships.
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {
            if (currentState != null)
            {
                currentState.Update(gameTime, this);
            }
        }

        /// <summary>
        /// Draw the space ship.
        /// </summary>
        /// <param name="spritebatch"></param>
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(textureImage, this.position, Color.White);
        }

        public void MoveUp()
        {
            this.position.Y -= 4f;
        }

        public void MoveDown()
        {
            this.position.Y += 4f;
        }

        public void MoveLeft()
        {
            this.position.X -= 2f;
        }

        public void MoveRight()
        {
            this.position.X += 2f;
        }

        /// <summary>
        /// Uses the bullet factory to shoot a projectile.
        /// </summary>
        public virtual void Shoot()
        {
            GamePlayScreen.bulletFactory.ShootBulletLeft(new Vector2(this.Position.X + Width / 2, this.Position.Y + Width / 2), WeaponDamage);
        }
    }
}