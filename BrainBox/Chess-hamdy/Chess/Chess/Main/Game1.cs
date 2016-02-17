using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Chess.Board;
using Chess.Managers;
namespace WindowsGame1
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        bool FirstInput;
        SpriteBatch spriteBatch;
        Color a = Color.White;
        MouseState CurrentMouseState, PreviousMouseState;
        board GameBoard=new board();
        int oldRow, oldColumn, newRow, newColumn;
        #region Cursor
        Texture2D CursorImage;
        Rectangle CursorRectangle;
        #endregion
        public Game1()
        {
            this.IsMouseVisible = false;
            //graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 648;
            graphics.PreferredBackBufferWidth = 1152;
        }
        protected override void Initialize()
        {
            FirstInput = true;
            GameBoard.Initialize();
            a = Color.White;
            base.Initialize();

        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            GameBoard.LoadContent(Content);
            CursorImage = Content.Load<Texture2D>("Resources/Menue/cursor");
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
         
            GameBoard.Update();
           
            CursorRectangle = new Rectangle((int)Mouse.GetState().X, (int)Mouse.GetState().Y, 25, 25);
           
            PreviousMouseState = CurrentMouseState;
            CurrentMouseState = Mouse.GetState();
            if (FirstInput)
            {
                for (int i = 0; i < 8 && FirstInput; i++)
                    for (int j = 0; j < 8; j++)
                    {
                        //if (CursorRectangle.Intersects(GameBoard.GetRectangle(i, j)))
                        //    a = Color.Red;
                        if (CursorRectangle.Intersects(GameBoard.GetRectangle(i, j)) && CurrentMouseState.LeftButton == ButtonState.Pressed && PreviousMouseState.LeftButton == ButtonState.Released)
                        {
                            oldRow = i;
                            oldColumn = j;
                            a = Color.Green;
                            FirstInput = false;
                            break;
                        }
                    }
            }
            else
            {
                if (CurrentMouseState.LeftButton == ButtonState.Pressed && PreviousMouseState.LeftButton == ButtonState.Released)
                {
                    newRow =(int)((CurrentMouseState.Y-85)/62);
                    newColumn = (int)((CurrentMouseState.X-76)/62);
                    a = Color.Red;
                   //GameBoard.SetCell(oldRow, oldColumn, newRow, newColumn);
                     GameBoard.Move(oldRow, oldColumn, newRow, newColumn);
                    FirstInput = true;
                }
            }
                base.Update(gameTime);
            
        }
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.CornflowerBlue);
            GameBoard.Draw(spriteBatch);
            spriteBatch.Draw(CursorImage, CursorRectangle,a);
            // TODO: Add your drawing code here
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}