using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceImpact
{
    class basicAI : ShipHull, IMoveBehaviour
    {

        public override void Update()
        {
            Move();
        }

        public void Move()
        {
            Console.WriteLine("Callinng move for basic AI");
        }
    }
}
