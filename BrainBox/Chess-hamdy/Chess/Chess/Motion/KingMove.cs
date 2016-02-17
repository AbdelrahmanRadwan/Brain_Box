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
    class KingMove : iMoveBehavior
    {
        public bool IsLegalMove(int oldRow, int oldColumn, int newRow, int newColumn, bool kill)
        {
            int
                hDiff = Math.Abs(oldRow - newRow),//difference between rows
                vDiff = Math.Abs(oldColumn - newColumn);//difference between columns
            if (hDiff == 1)
                if (vDiff == 1 || vDiff == 0)
                    return true;
            if (vDiff == 1)
                if (hDiff == 1 || hDiff == 0)
                    return true;
            return false;
        }
    }
}
