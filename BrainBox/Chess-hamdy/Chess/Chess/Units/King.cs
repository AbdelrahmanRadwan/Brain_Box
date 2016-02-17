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
namespace Chess
{
    internal class King : Unit
    {
        public King(string type)
            : base(type, new KingMove())
        { }
      override  public void LoadContent(ContentManager Content)
        {
            if (this.Type[0] == 'W')
                ImageOfUnit = Content.Load<Texture2D>("Resources/pictures/pieces/WhiteKing");
            else if (this.Type[0] == 'B')
                ImageOfUnit = Content.Load<Texture2D>("Resources/pictures/pieces/BlackKing");
        }
    }
}
