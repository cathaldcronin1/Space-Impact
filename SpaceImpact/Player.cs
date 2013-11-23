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

        public void addScore(int score)
        {
            this.score += score;
            NotifyObserver();
        }

        public void addHealth(int health)
        {
            this.health += health;
            NotifyObserver();
        }

        public void addAmmo(int ammo)
        {
            this.ammo += ammo;
            NotifyObserver();
        }
    }
}