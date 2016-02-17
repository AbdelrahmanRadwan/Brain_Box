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
    abstract class Menu
    {
        // Attributes 
        protected Texture2D MenuBG;
        protected Vector2 MenuBGPosistion;
        protected GameState CurrentSate;
        // Methods 
        virtual public void Initialize() { }
        virtual public void Update(GameTime gametime) { }
        virtual public void Draw(SpriteBatch Spritebatch) { }
        virtual public void LoadContent(ContentManager content) { }
        virtual public GameState GetState() { return CurrentSate; }
    }
}
