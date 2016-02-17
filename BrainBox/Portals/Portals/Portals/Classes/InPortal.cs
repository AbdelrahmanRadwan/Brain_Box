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
    class InPortal : Portal
    {
        // Setters 
        public void SetState(PortalState state)
        {
            CurrentState = state;
        }

        public void SetPortal(int x, int y)
        {
            CurrentPosition = new Rectangle(x, y, 50, 50);
        }

        // Getters
        public PortalState GetState()
        {
            return CurrentState;
        }
        public Rectangle GetRect()
        {
            return CurrentPosition;
        }

        /// XNA Functions
        public override void Update(GameTime gametime)
        {

        }
        public override void LoadContent(ContentManager content)
        {
            Vertical = content.Load<Texture2D>("InnerGame/Portals/Portal1");
        }
        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Vertical, CurrentPosition, Color.White);
        }
    } // End of InPortal
}