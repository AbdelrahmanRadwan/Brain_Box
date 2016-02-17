using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;
namespace BrainBox
{
    public class Main : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Vector2 MainBGVector;
        Texture2D MainBG;
        CustomPointer pointer = new CustomPointer();
        Rectangle QuitRECT = new Rectangle(513, 522, 216, 48);
        Rectangle CheckMate = new Rectangle(80, 237, 660, 86);
        Rectangle Portals = new Rectangle(80, 346, 660, 86);

        bool isClicked1 = false;
        bool isClicked2 = false;
        public Main()
        {
            MainBGVector = new Vector2(0);
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
        }

        protected override void Initialize()
        {
            SoundManager.Initialize();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            pointer.LoadContent(Content);
            MainBG = Content.Load<Texture2D>("BrainBOX");
            SoundManager.LoadContent(Content);
            SoundManager.Run(SoundManager.Player.EntrySound);
        }

        protected override void UnloadContent()
        {

        }

        double millisecondsPerFrame = 1000; //Update every 1 second
        double timeSinceLastUpdate = 0; //Accumulate the elapsed time
        protected override void Update(GameTime gameTime)
        {
            pointer.Update(gameTime);
            InputManager.Update();

            if (InputManager.IsRectangleClicked(QuitRECT))
            {
                SoundManager.Run(SoundManager.Player.BtnHover);
                this.Exit();
            }
            
            else if (InputManager.IsRectangleClicked(CheckMate)){
                SoundManager.Run(SoundManager.Player.BtnHover);
                if(!isClicked1)
                {
                     timeSinceLastUpdate = 0;
                     Process notePad = new Process();
                    notePad.StartInfo.FileName = "Chess-hamdy\\Chess\\Chess\\bin\\x86\\Debug\\Chess.exe";

                     notePad.Start();
                     isClicked1 = true;
                }
                MediaPlayer.Pause();
            }

            else if (InputManager.IsRectangleClicked(Portals)){
             ///   SoundManager.Run(SoundManager.Player.BtnHover);
                if (!isClicked2)
                {
                    timeSinceLastUpdate = 0;
                    Process notePad = new Process();
                    notePad.StartInfo.FileName = "Portals\\Portals\\Portals\\bin\\x86\\Debug\\Portals.exe";
                    notePad.Start();
                    isClicked2 = true;
                }
                MediaPlayer.Pause();
            }
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(MainBG, MainBGVector, Color.White);
            pointer.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}