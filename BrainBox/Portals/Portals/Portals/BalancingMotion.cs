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
    class BalancingMotion : Motion
    {
        public override Hero Move(Hero tobemoved)
        {
            if (tobemoved.GetVelocity().X > 0.05 || tobemoved.GetVelocity().X < -0.05)
                tobemoved.SetVelocity(new Vector2 (tobemoved.GetVelocity().X *0.8f, tobemoved.GetVelocity().Y));
            else
                tobemoved.SetVelocity(new Vector2(0 , tobemoved.GetVelocity().Y));
            return tobemoved;
        }
    }
}
