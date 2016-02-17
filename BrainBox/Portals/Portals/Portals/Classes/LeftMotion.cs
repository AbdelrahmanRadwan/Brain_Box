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
    class LeftMotion : Motion
    {
        public override Hero Move(Hero tobemoved)
        {
            if (tobemoved.Velocity.X > -1.0f)
            {
                tobemoved.Velocity.X -= (1.0f / 10);
            }
            else
            {
                tobemoved.Velocity.X = -1.0f;
            }
            return base.Move(tobemoved);
        }
    }
}
