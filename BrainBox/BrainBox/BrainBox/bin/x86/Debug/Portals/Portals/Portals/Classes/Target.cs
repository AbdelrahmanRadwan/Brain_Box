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
    // Level Target Class
    class Target
    {
        Texture2D texture;
        Rectangle textureRect;
        Vector2 Position;
        public Target(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.Position = position;
            textureRect = new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
        }

        public bool Update(Hero player)
        {
            return (new Rectangle((int)player.Position.X, (int)player.Position.Y, player.Texture.Width, player.Texture.Height).Intersects(textureRect));
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, Position, Color.White);
        }
    }
}
