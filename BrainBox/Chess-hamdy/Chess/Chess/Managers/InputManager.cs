#region namespaces
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
#endregion
using Chess.Motion;
namespace Chess.Managers
{
    static class InputManager
    {
        static private MouseState _CurrentMouseState, _PreviousMouseState;//Is it clicked or not 
        static private float currentMouseState_X, currentMouseState_Y;// the real position on window
        static private int _OldMousePosition_X,_OldMousePosition_Y,_NewMousePosition_X, _NewMousePosition_Y;// position in array (the cell)
        #region Mouse state properities
        static public MouseState CurrentMouseState
        {
            get { return _CurrentMouseState; }
            set { _CurrentMouseState = value; }
        }
        static public MouseState PreviousMouseState
        {
            get { return _PreviousMouseState; }
            set { _PreviousMouseState = value; }
        }
        #endregion
        #region Mouse Position
        static public float MouseState_X
        {
            get { return currentMouseState_X; }
            set { currentMouseState_X = value; }
        }
        static public float MouseState_Y
        {
            get { return currentMouseState_Y; }
            set { currentMouseState_Y = value; }
        }
        static public int OldMousePosition_X
        {
            set { _OldMousePosition_X = value; }
            get { return _OldMousePosition_X; }
        }
        static public int OldMousePosition_Y
        {
            set { _OldMousePosition_Y = value; }
            get { return _OldMousePosition_Y; }
        }
        static public int NewMousePosition_X
        {
            set { _NewMousePosition_X = value; }
            get { return _NewMousePosition_X; }
        }
        static public int NewMousePosition_Y
        {
            set { _NewMousePosition_Y = value; }
            get { return _NewMousePosition_Y; }
        }
        #endregion
        static public void MouseInput()
        {
            PreviousMouseState = Mouse.GetState();
            CurrentMouseState = Mouse.GetState();
            MouseState_X = (Int32)CurrentMouseState.X;
            MouseState_Y = (Int32)CurrentMouseState.Y;
            // IF the user presses the left button, find out in which i and j the mouse cursor is in.
            if (CurrentMouseState.LeftButton == ButtonState.Pressed && PreviousMouseState.LeftButton == ButtonState.Released)
                for (int i = 0; i < 8; i++)
                    for (int j = 0; j < 8; j++)
                    {
                        if ((MouseState_X > (84 + i * 63)) && (MouseState_X < (84 + (i + 1) * 63)))
                            _NewMousePosition_X = i;
                        if ((MouseState_Y > (76 + 63 * j)) && (MouseState_Y < (76 + 63 * j)))
                            _NewMousePosition_Y = j;
                    }
        }
    }
}