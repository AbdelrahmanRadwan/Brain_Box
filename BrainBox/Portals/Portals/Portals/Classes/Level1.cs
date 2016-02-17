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
    class Level1 : GameLevel
    {
        CustomPointer Pointer = new CustomPointer();
        Hero Player;
        Texture2D LevelBackground;
        InPortal Inport = new InPortal();
        OutPortal Outport = new OutPortal();
        Target LevelTarget;
        List<Obstacle> Obstacles;


        public override bool GetIsPassed()
        {
            return IsPassed;
        }

        public override void SetIsPassed(bool choise)
        {
            this.IsPassed = choise;
        }


        public 

        int tileWidth, tileHeight;

        char[,] Pattern = {{'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
                              {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
                              {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','T','.','.','.'},
                              {'.','.','.','.','.','.','.','#','.','.','.','.','.','#','.','.','.','.','.','.','.'},
                              {'#','#','#','#','#','#','.','.','#','.','.','.','#','.','.','#','#','#','#','#','#'},
                              {'.','.','.','.','.','.','.','.','.','#','-','#','.','.','.','.','.','.','.','.','.'},
                              {'.','.','.','.','.','.','.','.','.','#','-','#','.','.','.','.','.','.','.','.','.'},
                              {'#','#','#','#','#','.','.','.','#','.','.','.','#','.','.','.','#','#','#','#','#'},
                              {'.','.','.','.','.','.','.','#','.','.','.','.','.','#','.','.','.','.','.','.','.'},
                              {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
                              {'#','#','#','#','.','.','.','.','.','.','.','.','.','.','.','.','.','#','#','#','#'},
                              {'P','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
                              };
        
        public override void LoadContent(ContentManager content)
        {

            Inport.LoadContent(content);
            Outport.LoadContent(content);
            Pointer.LoadContent(content);
            LevelBackground = content.Load<Texture2D>("InnerGame/Levels/Texture-1");
            Player = Hero.Instance(content.Load<Texture2D>("hero"), Vector2.Zero, 6.0f, new Rectangle(0, 0, 1050, 600));
            LoadLevel(content);
        }

        public override void Initialize()
        {
            
            Inport.Initialize();
            Outport.Initialize();
            Obstacles = new List<Obstacle>();
        }

        void LoadLevel(ContentManager content)
        {
            Obstacles.Clear();
            Player.Position = Vector2.Zero;

            tileWidth = 21;
            tileHeight = 12;

            Texture2D blockSpriteA = content.Load<Texture2D>("blockA");
            Texture2D blockSpriteB = content.Load<Texture2D>("blockB");
            //Texture2D coin = content.Load<Texture2D>("coin");

            for (int x = 0; x < tileWidth; x++)
            {
                for (int y = 0; y < tileHeight; y++)
                {
                    //Inpassable Blocks
                    if (Pattern[y, x] == '#')
                    {
                        Obstacles.Add(new Obstacle(blockSpriteA, new Vector2(x * 50, y * 50), 1));
                    }
                    //Blocks that are only passable if going up them
                    if (Pattern[y, x] == '-')
                    {
                        Obstacles.Add(new Obstacle(blockSpriteB, new Vector2(x * 50, y * 50), 2));
                    }

                    if (Pattern[y, x] == 'T')
                    {
                        LevelTarget = new Target(content.Load<Texture2D>("test") , new Vector2(x*50 , y*50));
                    }


                    if (Pattern[y, x] == 'P' && Player.Position == Vector2.Zero)
                    {
                        Player.Position = new Vector2(x * 50, (y + 1) * 50 - Player.Texture.Height);
                    }
                    else if (Pattern[y, x] == 'P' && Player.Position != Vector2.Zero)
                    {
                        throw new Exception("Only one 'P' is needed for each level");
                    }
                }
            }

            if (Player.Position == Vector2.Zero)
            {
                throw new Exception("Player Position needs to be set with 'P'");
            }
        }

        public override void Update(GameTime gametime)
        {
            Pointer.SetColor(Color.Red);
            Pointer.Update(gametime);
            foreach (Obstacle b in Obstacles)
            {
                Player = b.BlockCollision(Player);
                if (new Rectangle((int)b.GetPosition().X, (int)b.GetPosition().Y, b.GetTexture().Width, b.GetTexture().Height).Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)))
                {

                    if ((b.GetPosition().Y - Player.Position.Y <= 10 && b.GetPosition().X - Player.Position.X <= 10))
                    {
                        Pointer.SetColor(Color.Green);
                        if (InputManager.IsRightShiftClicked())
                        {
                            Inport.SetPortal((int)b.GetPosition().X, (int)b.GetPosition().Y);
                        }

                        if (InputManager.IsEscapePressed())
                        {
                            Outport.SetPortal((int)b.GetPosition().X, (int)b.GetPosition().Y);
                        }
                    }
                }

                if (Inport.GetRect().Intersects(new Rectangle((int)Player.Position.X , (int)Player.Position.Y , Player.Texture.Height , Player.Texture.Width))){
                    Player.Position.X = Outport.GetRect().X;
                    Player.Position.Y = Outport.GetRect().Y;
                }
            }

            IsPassed = LevelTarget.Update(Player); 
            Player.Update(gametime);
            Player.Input(gametime);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(LevelBackground, Vector2.Zero, Color.White);
            foreach (Obstacle b in Obstacles)
            {
                b.Draw(spritebatch);
            }
            Player.Draw(spritebatch);

            LevelTarget.Draw(spritebatch);
            Inport.Draw(spritebatch);
            Outport.Draw(spritebatch);
            Pointer.Draw(spritebatch);
        }
    } // End Of Level 1
}
