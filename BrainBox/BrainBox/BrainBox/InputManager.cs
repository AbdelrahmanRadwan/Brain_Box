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

namespace BrainBox
{
    // Input Manager Class
    public static class InputManager
    {
        // Attributes
        private static MouseState CurrentState;
        
        private static KeyboardState ks;
        private static Point MousePosition;

        // Methods

        // Updates the mouse state
        public static void Update()
        {
            MousePosition = new Point(CurrentState.X, CurrentState.Y);
            CurrentState = Mouse.GetState();
            ks = Keyboard.GetState();
        }

        // returns true if the mouse hovers a rectangle
        public static bool IsMouseHovered(Rectangle ToBeHovered)
        {
            return ToBeHovered.Contains(MousePosition);
        }

        // returns true if the mouse clicked a rectangle
        public static bool IsRectangleClicked(Rectangle ToBeClicked)
        {
            if (IsMouseHovered(ToBeClicked))
            {
                if (IsLeftButtonPressed()) return true;
            }
            return false;
        }

        // returns true of the left button is clicked
        public static bool IsLeftButtonPressed()
        {
            return CurrentState.LeftButton == ButtonState.Pressed;
        }

        // returns true if the left button is released
        public static bool IsLeftButtonReleased()
        {
            return CurrentState.LeftButton == ButtonState.Released;
        }

        public static bool IsClickedOnce()
        {
            //return ms.LeftButton == 
            return false;
        }

        // returns true if the escape key is clicked 
        public static bool IsEscapePressed()
        {
            return (ks.IsKeyDown(Keys.Escape));
        }

        public static Point GetPosition()
        {
            return MousePosition;
        }

        
        public static MouseState ReturnCurrent()
        {
            return CurrentState;
        }
    }
}
