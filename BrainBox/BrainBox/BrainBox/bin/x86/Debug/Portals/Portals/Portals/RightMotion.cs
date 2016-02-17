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
    class RightMotion : Motion
    {
        public override Hero Move(Hero tobemoved)
        {
            if (tobemoved.GetVelocity().X < 1.0f)
            {
                float temp = tobemoved.GetVelocity().X;
                tobemoved.SetVelocity(new Vector2 (temp += (1.0f / 10), tobemoved.GetVelocity().Y));
            }

            else
            {
                tobemoved.SetVelocity(new Vector2(1.0f , tobemoved.GetVelocity().Y));
            }
            return tobemoved;
        }
    }
}
