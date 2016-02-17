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
    class InnerMenu : Menu
    {
        Texture2D PlayBTN;
        Vector2 PlayBTNPosition;
        Color PlayBTNColor = Color.White;

        Texture2D CreditsBTN;
        Vector2 CreditsBTNPosition;
        Color CreditsBTNColor = Color.White;

        Texture2D QuitBTN;
        Vector2 QuitBTNPosition;
        Color QuitBTNColor = Color.White;


        public  GameState GetState(){
            return CurrentSate;
        }

        public InnerMenu() { }
        public override void Initialize()
        {
            CurrentSate = GameState.MainMenu;
            MenuBGPosistion = new Vector2(0);
            PlayBTNPosition = new Vector2(37, 173);
            CreditsBTNPosition = new Vector2(37, 300);
            QuitBTNPosition = new Vector2(37, 427);
        }

        public override void LoadContent(ContentManager content)
        {
            MenuBG = content.Load<Texture2D>("Menu/InnerMenu/bg");
            PlayBTN = content.Load<Texture2D>("Menu/InnerMenu/Play");
            CreditsBTN = content.Load<Texture2D>("Menu/InnerMenu/Credits");
            QuitBTN = content.Load<Texture2D>("Menu/InnerMenu/Quit");

        }

        double timer;
        double pressdelay = 100f;
        int PointCounter = 1;
        public override void Update(GameTime gametime)
        {
            timer += (float)gametime.ElapsedGameTime.TotalMilliseconds;
            if (CurrentSate == GameState.MainMenu)
            {
                if (timer >= pressdelay)
                {   //For every pressdelay in milliseconds , the menu will let the user to choose a choise
                    timer = 0;
                    if (InputManager.IsDownPressed())
                    {
                        PointCounter++;
                        SoundManager.Run(SoundManager.Player.BtnHover);
                        // Moving in a cycle - Presenting the menu buttons (looping the choises) 
                        if (PointCounter == 4) PointCounter = 1;
                    }
                    if (InputManager.IsUpPressed())
                    {
                        PointCounter--;
                        SoundManager.Run(SoundManager.Player.BtnHover);
                        // Moving in a cycle - Presenting the menu buttons (looping the choises)
                        if (PointCounter == 0) PointCounter = 3;
                    }
                }
                switch (PointCounter)
                {
                    // Identifying the Current choosen button
                    case 1:
                        PlayBTNColor = Color.SteelBlue;
                        CreditsBTNColor = Color.White;
                        QuitBTNColor = Color.White;
                        break;
                    case 2:
                        PlayBTNColor = Color.White;
                        CreditsBTNColor = Color.SteelBlue;
                        QuitBTNColor = Color.White;
                        break;
                    case 3:
                        PlayBTNColor = Color.White;
                        CreditsBTNColor = Color.White;
                        QuitBTNColor = Color.SteelBlue;
                        break;
                }
            }

            if (InputManager.IsEnterPressed())
            {
                switch (PointCounter)
                {
                    // Directing the user to the prefered game state - According to his choise 
                    case 1:
                        {
                            CurrentSate = GameState.Playing;
                            SoundManager.Run(SoundManager.Player.BtnHover);                            
                            break;
                        }
                    case 2:
                        {
                            CurrentSate = GameState.Credits;
                            SoundManager.Run(SoundManager.Player.BtnHover);
                            break;
                        }
                    case 3:
                        {
                            CurrentSate = GameState.Quit;
                            SoundManager.Run(SoundManager.Player.BtnHover);
                            break;
                        }
                }
            }
        }

        public override void Draw(SpriteBatch Spritebatch)
        {
            Spritebatch.Draw(MenuBG, MenuBGPosistion, Color.White);
            Spritebatch.Draw(PlayBTN, PlayBTNPosition, PlayBTNColor);
            Spritebatch.Draw(CreditsBTN, CreditsBTNPosition, CreditsBTNColor);
            Spritebatch.Draw(QuitBTN, QuitBTNPosition, QuitBTNColor);
        }
    }
}
