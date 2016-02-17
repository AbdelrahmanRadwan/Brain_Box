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
namespace Chess.Board
{
     class board
    {
        #region Checkmate / mate
         int KingColumn, KingRow;
         bool KingCheck,DangerFromUp, DangerFromDown, DangerFromRight, DangerFromLeft, DangerFromDownLeft, DangerFromDownRight, DangerFromUpLeft, DangerFromUpRight,Mate, DangerForMate;
        #endregion
         private Unit[,] Board;
        private Texture2D BoardImage;
        private Vector2 BoardPosition;
        public void Reset_Board()
        {
            Board = new Unit[8, 8];
            #region White Units
            Board[0, 0] = new Rock("White Rock");
            Board[0, 1] = new Knight("White Knight");
            Board[0, 2] = new Bishop("White Bishop");
            Board[0, 3] = new Queen("White Queen");
            Board[0, 4] = new King("White King");
            Board[0, 5] = new Bishop("White Bishop");
            Board[0, 6] = new Knight("White Knight");
            Board[0, 7] = new Rock("White Rock");
            Board[1, 0] = new Pawn("White Pawn");
            Board[1, 1] = new Pawn("White Pawn");
            Board[1, 2] = new Pawn("White Pawn");
            Board[1, 3] = new Pawn("White Pawn");
            Board[1, 4] = new Pawn("White Pawn");
            Board[1, 5] = new Pawn("White Pawn");
            Board[1, 6] = new Pawn("White Pawn");
            Board[1, 7] = new Pawn("White Pawn");
            #endregion
            #region Black Units
            Board[7, 0] = new Rock("Black Rock");
            Board[7, 1] = new Knight("Black Knight");
            Board[7, 2] = new Bishop("Black Bishop");
            Board[7, 3] = new Queen("Black Queen");
            Board[7, 4] = new King("Black King");
            Board[7, 5] = new Bishop("Black Bishop");
            Board[7, 6] = new Knight("Black Knight");
            Board[7, 7] = new Rock("Black Rock");
            Board[6, 0] = new Pawn("Black Pawn");
            Board[6, 1] = new Pawn("Black Pawn");
            Board[6, 2] = new Pawn("Black Pawn");
            Board[6, 3] = new Pawn("Black Pawn");
            Board[6, 4] = new Pawn("Black Pawn");
            Board[6, 5] = new Pawn("Black Pawn");
            Board[6, 6] = new Pawn("Black Pawn");
            Board[6, 7] = new Pawn("Black Pawn");
            #endregion
        }
        public void Initialize()
        {
            BoardPosition = new Vector2(0, 0);
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (Board[i, j] != null)
                        Board[i, j].RectangleOfUnit = new Rectangle(85 + j * 62, 76 + i * 62, 62, 62);
                }
        }
        public board()
        {
            Reset_Board();
        }
        public string[,] GetBoard()
        {
            string[,] types = new string[8, 8];

            for (int r = 0; r < 8; r++)
                for (int c = 0; c < 8; c++)
                    if (Board[r, c] == null)
                        types[r, c] = "Empty Cell";
                    else
                        types[r, c] = Board[r, c].Type;
            return types;
        }
        public bool IsEmptyCell(int row, int column)
        {
            return Board[row, column] == null;
        }
        public bool ExistWhiteUnit(int row, int column)
        {
            if (Board[row, column] == null)
                return false;
            return (Board[row, column].Type[0]=='W');
        }
        public bool ExistBlackUnit(int row, int column)
        {
            if (Board[row, column] == null)
                return false;
            return (Board[row, column].Type[0]=='B');
        }

        public bool CanMove(int oldRow, int oldColumn, int newRow, int newColumn)
        {
            //Check if the "Start" and the "Destination" represent a legal movement.
            bool kill=( Board[newRow, newColumn] != null);/*if (Board[newRow, newColumn] == null)kill = false; else kill = true;*/
            bool legalMove = Board[oldRow, oldColumn].Move(oldRow, oldColumn, newRow, newColumn, kill);
            if (!legalMove) return false;
            //Checking that there is no other units on the pass between the "Start" and the "Destination".
            //Note: Knights has the ability to jump over the other Chess Units, so I don't check on it
            if (Board[oldRow, oldColumn] != null && Board[oldRow, oldColumn].Type != "White Knight" && Board[oldRow, oldColumn].Type != "Black Knight")
            {
                bool cleanPass;
                int
                    startRow = oldRow,
                    startColumn = oldColumn,
                    endRow = newRow,
                    endColumn = newColumn,
                    numberOfUnits = 0;
                while (startColumn != endColumn || startRow != endRow)
                {
                    if (Board[startRow, startColumn] != null)
                        numberOfUnits++;
                    if (startRow > endRow)
                        startRow--;
                    if (startRow < endRow)
                        startRow++;
                    if (startColumn > endColumn)
                        startColumn--;
                    if (startColumn < endColumn)
                        startColumn++;
                }
                if (numberOfUnits == 1)
                    cleanPass = true;
                else
                    cleanPass = false;
                if (!cleanPass)
                    return false;
            }
            //Move the Unit after checking that every thing is OK.
            Board[newRow, newColumn] = Board[oldRow, oldColumn];
            Board[oldRow, oldColumn] = null;
            return true;
        }
         public void Move(int OldRow,int OldColumn,int NewRow,int NewColumn)
        {
             if(!CanMove(OldRow,OldColumn,NewRow,NewColumn))
             {
                 Board[NewRow, NewColumn] = Board[OldRow, OldColumn];
                 Board[OldRow,OldColumn]=null;
             }
        }
         public void SetCell(int OldRow,int OldColumn,int NewRow,int NewColumn)
         {
             //Board[NewRow, NewColumn] = new Rock("White Rock");
              Board[NewRow, NewColumn] = Board[OldRow, OldColumn];
           //  Board[NewRow, NewColumn].Type = Board[OldRow, OldColumn].Type;
           //  Board[NewRow, NewColumn].RectangleOfUnit = Board[OldRow, OldColumn].RectangleOfUnit;
            // Board[NewRow, NewColumn].ImageOfUnit = Board[OldRow, OldColumn].ImageOfUnit;
          //   Board[OldRow, OldColumn] = null;
            // Board[OldRow, OldColumn]=null;
            /* for (int i = 0; i < 8; i++)
                 for (int j = 0; j < 8; j++)
                 {
                     if (Board[i, j] != null)
                     {
                         if (i == NewRow && j == NewColumn)
                             Board[i, j] = Board[OldRow, OldColumn];
                         Board[i, j] = Board[i, j];
                     }
                 }*/
         }
         public Unit GetCell(int Row, int Column)
         {
             return Board[Row, Column];
         }
        public bool IsGameEnd()
        {
            throw new NotImplementedException();
            //you win , you dead
        }
        public void Update()
        {
           
        }
        public Rectangle GetRectangle(int Row, int Column)
         {
            if(Board[Row,Column]!=null)
             return Board[Row, Column].RectangleOfUnit;
            return new Rectangle(0, 0, 0, 0);
         }
         public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BoardImage, BoardPosition, Color.White);
            for(int i=0;i<8;i++)
                for(int j=0;j<8;j++)
                {
                    if (Board[i, j] != null)
                    spriteBatch.Draw(Board[i,j].ImageOfUnit,new Vector2(85+j*62,76+i*62),Color.White);
                }
        }
        public void LoadContent(ContentManager Content)
        {
            BoardImage = Content.Load<Texture2D>("Resources/pictures/board/Checkmate");
            for(int i=0;i<8;i++)
                  for(int j=0;j<8;j++)
                  {
                      if (Board[i, j] != null)// || Board[i, j].Type == "Empty Cell")
                          Board[i, j].LoadContent(Content);
                       //   Board[i, j].ImageOfUnit = Content.Load<Texture2D>("Resources/pictures/board/Checkmate");
                     // else
                          
                  }
        }         
         public bool CheckForBlackCheck()
        {
            for (int i = 0; i <= 7; i++)
                for (int j = 0; j <= 7; j++)
                    if (Board[(i), (j)].Type=="Black King")
                    {
                        KingColumn = (i + 1);
                        KingRow = (j + 1);
                    }
            KingCheck = false;
            DangerFromRight = false;
            for (int i = 1; i <= 7; i++)
                if ((KingColumn + i) <= 8 && !DangerFromRight)
                    if ( Board[(KingColumn + i - 1), (KingRow - 1)].Type=="White Rook" || Board[(KingColumn + i - 1), (KingRow - 1)].Type=="White Queen")
                    {
                        KingCheck = true;
                        DangerFromRight=true;
                    }
            DangerFromLeft = false;
            for (int i = 1; i <= 7; i++)
                if ( KingColumn - i >= 1 && !DangerFromLeft)
                    if (Board[(KingColumn - i - 1), (KingRow - 1)].Type == "White Rook" || Board[(KingColumn - i - 1), (KingRow - 1)].Type == "White Queen")
                    {
                        KingCheck = true;
                        DangerFromLeft = true;
                    }
             DangerFromUp = false;
            for (int i = 1; i <= 7; i++)
                if ( KingRow + i <= 8 && !DangerFromUp)
                    if (Board[(KingColumn - 1), (KingRow + i - 1)].Type=="White Rook" ||Board[(KingColumn - 1), (KingRow + i - 1)].Type=="White Queen")
                    {
                        KingCheck = true;
                        DangerFromUp = true;
                    }
            DangerFromDown = false;
            for (int i = 1; i <= 7; i++)
                if ( KingRow - i >= 1  && !DangerFromDown)
                    if (Board[(KingColumn - 1), (KingRow - i - 1)].Type=="White Rook"|| Board[(KingColumn - 1), (KingRow - i - 1)].Type=="White Queen")
                    {
                 KingCheck = true;
                 DangerFromDown=true;
                    }  
            DangerFromUpRight = false;
            for (int i = 1; i <= 7; i++)
                if (KingColumn + i <= 8 && KingRow + i <= 8 && !DangerFromUpRight)
                    if (Board[(KingColumn + i - 1), (KingRow + i - 1)].Type=="White Bishop" || Board[(KingColumn + i - 1), (KingRow + i - 1)].Type=="White Queen")
                    {
                        KingCheck = true;
                        DangerFromUpRight=true;
                    }    
            DangerFromDownLeft = false;
            for (int i = 1; i <= 7; i++)
                if (((KingColumn - i) >= 1) && ((KingRow - i) >= 1) && !DangerFromDownLeft)
                    if (Board[(KingColumn - i - 1), (KingRow - i - 1)].Type=="White Bishop" || Board[(KingColumn - i - 1), (KingRow - i - 1)].Type=="White Queen")
                    {
                        KingCheck = true;
                    DangerFromDownLeft=true;
                    }
            DangerFromDownRight = false;
            for (int i = 1; i <= 7; i++)
                if ( KingColumn + i <= 8 &&  KingRow - i >= 1 && !DangerFromDownRight)
                    if (Board[(KingColumn + i - 1), (KingRow - i - 1)].Type=="White Bishop"||Board[(KingColumn + i - 1), (KingRow - i - 1)].Type=="White Queen")
                    {
                        KingCheck = true;
                        DangerFromDownRight=true;
                    }
            DangerFromUpLeft = false;
            for (int i = 1; i <= 7; i++)
                if (((KingColumn - i) >= 1) && ((KingRow + i) <= 8) && (DangerFromUpLeft == true))
                    if (Board[(KingColumn - i - 1), (KingRow + i - 1)].Type=="White Bishop"||Board[(KingColumn - i - 1), (KingRow + i - 1)].Type=="White Queen")
                    {
                        KingCheck = true;
                        DangerFromUpLeft=true;
                    }
            if ( KingColumn + 1 <= 8 &&  KingRow - 1  >= 1 )
                if (Board[(KingColumn + 1 - 1), (KingRow - 1 - 1)].Type=="White Pawn")
                    KingCheck = true;
            if ( KingColumn - 1 >= 1 && KingRow - 1 >= 1 )
                if (Board[(KingColumn - 1 - 1), (KingRow - 1 - 1)].Type=="White Pawn")
                    KingCheck = true;
            if ( KingColumn + 1 <= 8 &&  KingRow + 2 <= 8)
                if (Board[(KingColumn + 1 - 1), (KingRow + 2 - 1)].Type=="White Knight")
                    KingCheck = true;
            if (KingColumn + 2  <= 8 && KingRow - 1 >= 1)
                if (Board[(KingColumn + 2 - 1), (KingRow - 1 - 1)].Type=="White Knight")
                    KingCheck = true;
            if (((KingColumn + 1) <= 8) && ((KingRow - 2) >= 1))
                if (Board[(KingColumn + 1 - 1), (KingRow - 2 - 1)].Type=="White Knight")
                    KingCheck = true;
            if (((KingColumn - 1) >= 1) && ((KingRow - 2) >= 1))
                if (Board[(KingColumn - 1 - 1), (KingRow - 2 - 1)].Type=="White Knight")
                    KingCheck = true;
            if (((KingColumn - 2) >= 1) && ((KingRow - 1) >= 1))
                if (Board[(KingColumn - 2 - 1), (KingRow - 1 - 1)].Type=="White Knight")
                    KingCheck = true;
            if (((KingColumn - 2) >= 1) && ((KingRow + 1) <= 8))
                if (Board[(KingColumn - 2 - 1), (KingRow + 1 - 1)].Type=="White Knight")
                    KingCheck = true;
            if (((KingColumn - 1) >= 1) && ((KingRow + 2) <= 8))
                if (Board[(KingColumn - 1 - 1), (KingRow + 2 - 1)].Type=="White Knight")
                    KingCheck = true;
            if (((KingColumn + 2) <= 8) && ((KingRow + 1) <= 8))
                if (Board[(KingColumn + 2 - 1), (KingRow + 1 - 1)].Type=="White Knight")
                    KingCheck = true;
            return KingCheck;
        } 
           public bool CheckForWhiteCheck()
        {
            for (int i = 0; i <= 7; i++)
                for (int j = 0; j <= 7; j++)
                    if (Board[(i), (j)].Type=="White King")
                    {
                        KingColumn = (i + 1);
                        KingRow = (j + 1);
                    }
            KingCheck = false;
            DangerFromRight = false;
            for (int i = 1; i <= 7; i++)
                if ((KingColumn + i) <= 8 && !DangerFromRight)
                    if ( Board[(KingColumn + i - 1), (KingRow - 1)].Type=="Black Rook" || Board[(KingColumn + i - 1), (KingRow - 1)].Type=="Black Queen")
                    {
                        KingCheck = true;
                        DangerFromRight=true;
                    }
            DangerFromLeft = false;
            for (int i = 1; i <= 7; i++)
                if ( KingColumn - i >= 1 && !DangerFromLeft)
                    if (Board[(KingColumn - i - 1), (KingRow - 1)].Type == "Black Rook" || Board[(KingColumn - i - 1), (KingRow - 1)].Type == "Black Queen")
                    {
                        KingCheck = true;
                        DangerFromLeft = true;
                    }
             DangerFromUp = false;
            for (int i = 1; i <= 7; i++)
                if ( KingRow + i <= 8 && !DangerFromUp)
                    if (Board[(KingColumn - 1), (KingRow + i - 1)].Type=="Black Rook" ||Board[(KingColumn - 1), (KingRow + i - 1)].Type=="Black Queen")
                    {
                        KingCheck = true;
                        DangerFromUp = true;
                    }
            DangerFromDown = false;
            for (int i = 1; i <= 7; i++)
                if ( KingRow - i >= 1  && !DangerFromDown)
                    if (Board[(KingColumn - 1), (KingRow - i - 1)].Type=="Black Rook"|| Board[(KingColumn - 1), (KingRow - i - 1)].Type=="Black Queen")
                    {
                 KingCheck = true;
                 DangerFromDown=true;
                    }  
            DangerFromUpRight = false;
            for (int i = 1; i <= 7; i++)
                if (KingColumn + i <= 8 && KingRow + i <= 8 && !DangerFromUpRight)
                    if (Board[(KingColumn + i - 1), (KingRow + i - 1)].Type=="Black Bishop" || Board[(KingColumn + i - 1), (KingRow + i - 1)].Type=="Black Queen")
                    {
                        KingCheck = true;
                        DangerFromUpRight=true;
                    }    
            DangerFromDownLeft = false;
            for (int i = 1; i <= 7; i++)
                if (((KingColumn - i) >= 1) && ((KingRow - i) >= 1) && !DangerFromDownLeft)
                    if (Board[(KingColumn - i - 1), (KingRow - i - 1)].Type=="Black Bishop" || Board[(KingColumn - i - 1), (KingRow - i - 1)].Type=="Black Queen")
                    {
                        KingCheck = true;
                    DangerFromDownLeft=true;
                    }
            DangerFromDownRight = false;
            for (int i = 1; i <= 7; i++)
                if ( KingColumn + i <= 8 &&  KingRow - i >= 1 && !DangerFromDownRight)
                    if (Board[(KingColumn + i - 1), (KingRow - i - 1)].Type=="Black Bishop"||Board[(KingColumn + i - 1), (KingRow - i - 1)].Type=="Black Queen")
                    {
                        KingCheck = true;
                        DangerFromDownRight=true;
                    }
            DangerFromUpLeft = false;
            for (int i = 1; i <= 7; i++)
                if (((KingColumn - i) >= 1) && ((KingRow + i) <= 8) && (DangerFromUpLeft == true))
                    if (Board[(KingColumn - i - 1), (KingRow + i - 1)].Type=="Black Bishop"||Board[(KingColumn - i - 1), (KingRow + i - 1)].Type=="Black Queen")
                    {
                        KingCheck = true;
                        DangerFromUpLeft=true;
                    }
            if ( KingColumn + 1 <= 8 &&  KingRow - 1  >= 1 )
                if (Board[(KingColumn + 1 - 1), (KingRow - 1 - 1)].Type=="Black Pawn")
                    KingCheck = true;
            if ( KingColumn - 1 >= 1 && KingRow - 1 >= 1 )
                if (Board[(KingColumn - 1 - 1), (KingRow - 1 - 1)].Type=="Black Pawn")
                    KingCheck = true;
            if ( KingColumn + 1 <= 8 &&  KingRow + 2 <= 8)
                if (Board[(KingColumn + 1 - 1), (KingRow + 2 - 1)].Type=="Black Knight")
                    KingCheck = true;
            if (KingColumn + 2  <= 8 && KingRow - 1 >= 1)
                if (Board[(KingColumn + 2 - 1), (KingRow - 1 - 1)].Type=="Black Knight")
                    KingCheck = true;
            if (((KingColumn + 1) <= 8) && ((KingRow - 2) >= 1))
                if (Board[(KingColumn + 1 - 1), (KingRow - 2 - 1)].Type=="Black Knight")
                    KingCheck = true;
            if (((KingColumn - 1) >= 1) && ((KingRow - 2) >= 1))
                if (Board[(KingColumn - 1 - 1), (KingRow - 2 - 1)].Type=="Black Knight")
                    KingCheck = true;
            if (((KingColumn - 2) >= 1) && ((KingRow - 1) >= 1))
                if (Board[(KingColumn - 2 - 1), (KingRow - 1 - 1)].Type=="Black Knight")
                    KingCheck = true;
            if (((KingColumn - 2) >= 1) && ((KingRow + 1) <= 8))
                if (Board[(KingColumn - 2 - 1), (KingRow + 1 - 1)].Type=="Black Knight")
                    KingCheck = true;
            if (((KingColumn - 1) >= 1) && ((KingRow + 2) <= 8))
                if (Board[(KingColumn - 1 - 1), (KingRow + 2 - 1)].Type=="Black Knight")
                    KingCheck = true;
            if (((KingColumn + 2) <= 8) && ((KingRow + 1) <= 8))
                if (Board[(KingColumn + 2 - 1), (KingRow + 1 - 1)].Type=="Black Knight")
                    KingCheck = true;
            return KingCheck;
        }
     

     }
}
