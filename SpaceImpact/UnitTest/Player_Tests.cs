using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using NUnit.Framework;
using SpaceImpact;

namespace SpaceImpact
{
    [TestFixture]
    class Player_Tests
    {
        float oldPlayerPosition;
        float newPlayerPosition;
        Player p = new Player(null, Vector2.Zero, Vector2.Zero);

        [Test]
        public void Player_Move_Up()
        {
            oldPlayerPosition = p.Position.Y;
            p.MoveUp();
            newPlayerPosition = p.Position.Y;

            Assert.AreNotEqual(newPlayerPosition, oldPlayerPosition);
        }

        [Test]
        public void Player_Move_Down()
        {

            oldPlayerPosition = p.Position.Y;
            p.MoveDown();
            newPlayerPosition = p.Position.Y;

            if(newPlayerPosition >= oldPlayerPosition)
                Assert.AreNotEqual(newPlayerPosition, oldPlayerPosition);
        }

        [Test]
        public void Player_Move_Left()
        {
            oldPlayerPosition = p.Position.X;
            p.MoveLeft();
            newPlayerPosition = p.Position.X;

            if(newPlayerPosition < oldPlayerPosition)
                Assert.AreNotEqual(newPlayerPosition, oldPlayerPosition);
        }

        [Test]
        public void Player_Move_Right()
        {
            oldPlayerPosition = p.Position.X;
            p.MoveRight();
            newPlayerPosition = p.Position.X;

            if (newPlayerPosition > oldPlayerPosition)
                Assert.AreNotEqual(newPlayerPosition, oldPlayerPosition);
        }
    }
}
