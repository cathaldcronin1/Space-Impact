using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace SpaceImpact
{
    public abstract class MenuComponent
    {
        public virtual void add(MenuComponent newMenuComponent)
        {
            
            throw new NotImplementedException();
        }

        public virtual void remove(MenuComponent newMenuComponent)
        {
            throw new NotImplementedException();
        }

        public virtual MenuComponent getMenuComponent(int componentIndex)
        {
            throw new NotImplementedException();
        }

        public virtual void Draw(SpriteBatch spritebatch)
        {
            throw new NotImplementedException();
        }

        public virtual void Update()
        {
            throw new NotImplementedException();
        }
    }
}