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

namespace Chess.Motion
{
    class PawnMove : iMoveBehavior
    {
        private bool
            _firstStep,
            _upDirection;
        public void Moved()
        {
            _firstStep = false;
        }
        public PawnMove(bool upDirection)
        {
            _upDirection = upDirection;
            _firstStep = true;
        }
        public bool IsLegalMove(int oldRow, int oldColumn, int newRow, int newColumn, bool kill)
        {
            int hDiff = oldRow - newRow;//            positive                       negative
                                       //Accepted :   it walk up (white)          it walk down (black)                         
                                      //  Refused :   it walk down (black)         it walk up (white)
            int vDiff = oldColumn - newColumn;
            if (!kill) // only want to move forward 
            {
                if (vDiff != 0) return false;
                if (_firstStep)
                {
                    if (Math.Abs(hDiff) == 1 || Math.Abs(hDiff) == 2)
                    {
                        if (_upDirection && hDiff > 0)
                            return true;
                        if (!_upDirection && hDiff < 0)
                            return true;
                    }
                    else
                        return false;
                }
                else if(!_firstStep)
                {
                    if (_upDirection && hDiff == 1)
                        return true;
                    else if (!_upDirection && hDiff == -1)
                        return true;
                    else
                        return false;
                }
            }
            else if(kill)// you want to kill , so want to move one step dimentionally 
            {
                if (Math.Abs(vDiff) == 1&& Math.Abs(hDiff) == 1)
                {
                    if (_upDirection && hDiff == 1)
                        return true;
                    else if (!_upDirection && hDiff == -1)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
