using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SpaceImpact
{
    public class Player : ShipHull, ISubject
    {
        List<IObserver> observers;
        private int score, health, ammo;

        /// <summary>
        /// Creates an intance of a player.
        /// </summary>
        public Player(Texture2D textureImage, Vector2 position, Vector2 speed)
            : base(textureImage, position, speed,null)
        {
            observers = new List<IObserver>();
            Hitpoints = 100;
            WeaponDamage = 50;
            AddAmmo(100);
            AddHealth(100);
        }

        public override void Update(GameTime gameTime)
        {
            CheckBounds();
        }

        public void Register(IObserver o)
        {
            observers.Add(o);
        }

        public void Unregister(IObserver o)
        {
            observers.Remove(o);
        }

        /// <summary>
        /// Notifies observers of stat changes.
        /// </summary>
        public void NotifyObserver()
        {
            foreach (IObserver o in observers)
            {
                o.UpdateStats(score, health, ammo);
            }
        }

        /// <summary>
        /// Alters the players score and notifies observers.
        /// </summary>
        /// <param name="score"></param>
        public void AddScore(int score)
        {
            this.score += score;
            NotifyObserver();
        }

        /// <summary>
        /// Alters the players health and notifies observers.
        /// </summary>
        /// <param name="score"></param>
        public void AddHealth(int health)
        {
            this.health += health;
            NotifyObserver();
        }

        /// <summary>
        /// Alters the players ammo and notifies observers.
        /// </summary>
        /// <param name="score"></param>
        public void AddAmmo(int ammo)
        {
            this.ammo += ammo;
            NotifyObserver();
        }

        /// <summary>
        /// Uses projectile manager to create a bullet and decrements ammo.
        /// </summary>
        public override void Shoot()
        {
            if (ammo > 0)
            {
                GamePlayScreen.bulletFactory.ShootBulletRight(new Vector2(this.Position.X + Width / 2, this.Position.Y + Width / 2), WeaponDamage);
                AddAmmo(-1);
            }
        }

        /// <summary>
        /// Makes sure player cannot leave the screen.
        /// </summary>
        private void CheckBounds()
        {
            if (Position.X <= SpaceImpact.Instance.Window.ClientBounds.Left)
                position.X = 0;
            if (Position.X >= SpaceImpact.Instance.Window.ClientBounds.Right - Width)
                position.X = SpaceImpact.Instance.Window.ClientBounds.Right - Width;
            if (Position.Y <= SpaceImpact.Instance.Window.ClientBounds.Top + 25)
                position.Y = 25;
            if (Position.Y >= SpaceImpact.Instance.Window.ClientBounds.Bottom - Height)
                position.Y = SpaceImpact.Instance.Window.ClientBounds.Bottom - Height;
        }
    }
}