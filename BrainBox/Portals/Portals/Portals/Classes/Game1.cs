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

namespace Portals
{
    // Game 1 Class
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Menu MainMenu;

        GameLevel CurrentLevel = new Level1();


        GameState Current = GameState.MainMenu;
        public Game1()
        {
            MainMenu = new InnerMenu();
            graphics = new GraphicsDeviceManager(this); // new graphics manager
            Content.RootDirectory = "Content"; // setting the root directory
            graphics.PreferredBackBufferHeight = 600; // Window height
            graphics.PreferredBackBufferWidth = 1050; // window width
            MainMenu = new InnerMenu();

            if (Current == GameState.ChooseLevel)
            {
                MainMenu = new ChooseLevel();
            }
        }

        protected override void Initialize()
        {
            CurrentLevel.Initialize();
            MainMenu.Initialize();

            if (Current == GameState.ChooseLevel)
            {
                MainMenu = new ChooseLevel();
                MainMenu.Initialize();
            }
            SoundManager.Initialize();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            MainMenu.LoadContent(Content);

            if (Current == GameState.ChooseLevel)
            {
                MainMenu = new ChooseLevel();
                MainMenu.LoadContent(Content);
            }
            CurrentLevel.LoadContent(Content);
            SoundManager.LoadContent(Content);
            SoundManager.Run(SoundManager.Player.Menu);
        }

        protected override void Update(GameTime gameTime)
        {
            Current = MainMenu.GetState();
            
            if (Current == GameState.Quit)
            {
                this.Exit();
            }

            else if (Current == GameState.Playing)
            {
                CurrentLevel.Update(gameTime);
            }

            else
            {
                MainMenu.Update(gameTime);
            }

            if (CurrentLevel.GetIsPassed())
            {
                Current = GameState.MainMenu;
            }

            InputManager.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            if (Current == GameState.MainMenu)
            {
                MainMenu.Draw(spriteBatch);
            }

            else if (Current == GameState.ChooseLevel)
            {
                MainMenu = new ChooseLevel();
                MainMenu.Draw(spriteBatch);
            }

            else if (Current == GameState.Playing)
            {
                CurrentLevel.Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}