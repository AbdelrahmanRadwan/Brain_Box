﻿using System;
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

namespace BrainBox
{
    // Custom Pointer Class
    class CustomPointer
    {
        // Attributes 
        Texture2D Pointer;
        Rectangle Position;

        // Methods 

        // Loading assets into memory
        public void LoadContent(ContentManager content)
        {
            Pointer = content.Load<Texture2D>("cursor");
        }

        // Updating the pointer's position 
        public void Update(GameTime gametime)
        {
            Position = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 50, 50);
        }

        // Drawing the pointer
        public void Draw(SpriteBatch sp)
        {
            sp.Draw(Pointer, Position, Color.White);
        }
    }
}