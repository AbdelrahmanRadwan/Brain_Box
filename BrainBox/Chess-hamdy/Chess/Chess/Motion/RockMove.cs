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
    class RockMove : iMoveBehavior
    {
        public bool IsLegalMove(int oldRow, int oldColumn, int newRow, int newColumn, bool kill)
        {
            int
                hDiff = Math.Abs(oldColumn - newColumn),//difference between rows
                vDiff = Math.Abs(oldRow - newRow);//difference between columns
            if (hDiff != 0 && vDiff == 0)
                return true;
            if (vDiff != 0 && hDiff == 0)
                return true;
            return false;
        }
    }
}
