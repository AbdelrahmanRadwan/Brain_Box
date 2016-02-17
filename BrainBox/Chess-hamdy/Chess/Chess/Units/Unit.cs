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
    abstract class Unit
    {
        private string type;
        private Texture2D UnitImage;
        private iMoveBehavior MoveBehavior;
        private Rectangle UnitRectangle;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public Texture2D ImageOfUnit
        {
            set { UnitImage = value; }
            get { return UnitImage; }
        }
        public Rectangle RectangleOfUnit
        {
            set { UnitRectangle=value;}
            get { return UnitRectangle;}
        }
        protected Unit(string _type, iMoveBehavior _moveBehavior)
        {
            this.MoveBehavior = _moveBehavior;
            this.type = _type;
        }
        public bool Move(int oldRow, int oldColumn, int newRow, int newColumn, bool kill)
        {
            bool legalMove = MoveBehavior.IsLegalMove(oldRow, oldColumn, newRow, newColumn, kill);

            if (legalMove)
            {
                if (type == "White Pawn" || type == "Black Pawn")
                {
                    ((PawnMove)MoveBehavior).Moved(); // :( 
                }
                return true;
            }
            return false;
        }
       virtual public void LoadContent(ContentManager Content)
        {}
       //public  void operator=(Unit left,Unit right)
       //{

       //}
     /*  public void Swap(Unit NEW,Unit NEW)
       {

       }*/
        }
}
