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
    abstract class InteractiveObject
    {


        protected static InteractiveObject instance;
        public Texture2D Texture;
        public Vector2 Velocity;
        public Vector2 Position;
        protected Motion HeroMotion;
        protected Rectangle screenBound;

        public float ground;
        protected float Speed;
        public bool isJumping; //are we jumping or not
        public bool goingUp; //if going up or not
        public float u; //initial velocity
        public float jumpU; // Jumping speed
        protected float g; //gravity
        public float t; //time

        static public InteractiveObject Instance() { return instance; }
        virtual public void Update(GameTime gametime) { }
        virtual public void Draw(SpriteBatch spritebatch) { }
    }
}
