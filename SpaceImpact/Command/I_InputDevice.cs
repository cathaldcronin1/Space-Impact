using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace SpaceImpact
{
    interface I_InputDevice
    {
        bool Up();
        bool Down();
        bool Left();
        bool Right();
        bool Shoot();

        void Update();
    }
}
