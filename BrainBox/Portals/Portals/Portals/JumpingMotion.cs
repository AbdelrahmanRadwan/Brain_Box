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
    class JumpingMotion : Motion
    {
        public override Hero Move(Hero tobemoved)
        {
            tobemoved.isJumping = true;
            tobemoved.u = tobemoved.jumpU;
            return tobemoved;
        }
    }
}
