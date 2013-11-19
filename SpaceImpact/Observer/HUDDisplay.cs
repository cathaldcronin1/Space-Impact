using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceImpact
{
    public class HUDDisplay : I_Observer
    {
        private SpriteFont font;
        private int score, health, ammo;
        private I_Subject subject;

        public HUDDisplay(I_Subject subject, SpriteFont font)
        {
            this.subject = subject;
            subject.Register(this);
            this.font = font;
        }

        public void UpdateStats(int score, int health, int ammo)
        {
            this.score = score;
            this.health = health;
            this.ammo = ammo;

        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.DrawString(font, String.Format("SCORE : {0}   HEALTH : {1}   AMMO : {2}",score,health,ammo) , Vector2.Zero, Color.White);
        }
    }
}
