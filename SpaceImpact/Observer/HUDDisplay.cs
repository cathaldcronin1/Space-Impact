using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceImpact
{
    public class HUDDisplay : IObserver
    {
        private SpriteFont font;
        private int score, health, ammo;
        private ISubject subject;

        /// <summary>
        /// Creates an instance of a HUDDisplay.
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="font"></param>
        public HUDDisplay(ISubject subject, SpriteFont font)
        {
            this.subject = subject;
            subject.Register(this);
            this.font = font;
        }

        /// <summary>
        /// Updates the HUD's stats.
        /// </summary>
        public void UpdateStats(int score, int health, int ammo)
        {
            this.score = score;
            this.health = health;
            this.ammo = ammo;

        }

        /// <summary>
        /// Draws the HUD to the screen.
        /// </summary>
        /// <param name="spritebatch"></param>
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.DrawString(font, String.Format("SCORE : {0}   HEALTH : {1}   AMMO : {2}",score,health,ammo) , Vector2.Zero, Color.White);
        }
    }
}
