using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SpaceImpact
{
    public class Player : ShipHull, I_Subject
    {
        List<I_Observer> observers;
        private int score, health, ammo;

        public Player(Texture2D textureImage, Vector2 position, Vector2 speed)
            : base(textureImage, position, speed,null)
        {
            observers = new List<I_Observer>();
            Hitpoints = 100;
            WeaponDamage = 50;
            AddAmmo(100);
            AddHealth(100);
        }

        public override void Update(GameTime gameTime)
        {
            CheckBounds();
        }

        public void Register(I_Observer o)
        {
            observers.Add(o);
        }

        public void Unregister(I_Observer o)
        {
            observers.Remove(o);
        }

        public void NotifyObserver()
        {
            foreach (I_Observer o in observers)
            {
                o.UpdateStats(score, health, ammo);
            }
        }

        public void AddScore(int score)
        {
            this.score += score;
            NotifyObserver();
        }

        public void AddHealth(int health)
        {
            this.health += health;
            NotifyObserver();
        }

        public void AddAmmo(int ammo)
        {
            this.ammo += ammo;
            NotifyObserver();
        }

        public override void Shoot()
        {
            if (ammo > 0)
            {
                GamePlayScreen.bulletFactory.ShootBulletPlayer(new Vector2(this.Position.X + Width / 2, this.Position.Y + Width / 2), WeaponDamage);
                AddAmmo(-1);
            }
        }

        private void CheckBounds()
        {
            if (Position.X <= Game1.Instance.Window.ClientBounds.Left)
                position.X = 0;
            if (Position.X >= Game1.Instance.Window.ClientBounds.Right - Width)
                position.X = Game1.Instance.Window.ClientBounds.Right - Width;
            if (Position.Y <= Game1.Instance.Window.ClientBounds.Top + 25)
                position.Y = 25;
            if (Position.Y >= Game1.Instance.Window.ClientBounds.Bottom - Height)
                position.Y = Game1.Instance.Window.ClientBounds.Bottom - Height;
        }
    }
}