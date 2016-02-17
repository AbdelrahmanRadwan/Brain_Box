using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Portals
{
    abstract class Portal
    {
        protected PortalState CurrentState;
        protected Texture2D Horizontal;
        protected Texture2D Vertical;
        public Rectangle CurrentPosition;
        virtual public void Initialize() { }
        virtual public void Update(GameTime gametime) { }
        virtual public void LoadContent(ContentManager content) { }
        virtual public void Draw(SpriteBatch spritebatch) { }
    }
}
