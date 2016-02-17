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
    class Animation
    {
        Texture2D SpriteSheet;
       
        Rectangle DestinationRectangle;
        Rectangle SourceRectangle;
        double ElapsedTime;
        double Delay = 65f;
        int Frames = 0;

        public void Initialize()
        {
            DestinationRectangle = new Rectangle(30, 100, 597/9, 80);
            SourceRectangle = new Rectangle((597 / 9), 0, 597 / 9, 80);
        }

        public Rectangle GetRect()
        {
            return DestinationRectangle;
        }
        public void Load(ContentManager content , string path)
        {
            SpriteSheet = content.Load<Texture2D>(path);
        }

        public void Update(GameTime gametime)
        {
            
            ElapsedTime += gametime.ElapsedGameTime.TotalMilliseconds;
            if (ElapsedTime >= Delay)
            {
                if (Frames >= 8)
                {
                    Frames = 0;
                }
                else
                {
                    Frames++;
                }
                ElapsedTime = 0;
            }
            SourceRectangle = new Rectangle((597 / 9) * Frames, 0, 597 / 9, 80);

        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(SpriteSheet, DestinationRectangle, SourceRectangle, Color.White);
        }
    }
    /*
            //public Animation animation = new Animation();
            float Angle;
            double moveSpeed = 500f;
            double jumpSpeed = 1500f;
            bool jump = false;
            Rectangle DestinationRectangle;
            Rectangle SourceRectangle;
            double ElapsedTime;
            double Delay = 65f;
            int Frames = 0;

            public override void Initialize()
            {
                DestinationRectangle = new Rectangle(200, 100, 597 / 9, 80);
                SourceRectangle = new Rectangle((597 / 9), 0, 597 / 9, 80);
                //Position = new Vector2(300, 300);
                Position = Velocity = new Vector2(0);
                //HeroState = State.Walking;
                //animation.Initialize();
                //volume = animation.GetRect();
            }

            public void SetPosition(float x, float y)
            {
                Position = new Vector2(x, y);
            }
            public void SetDestiationX(int a)
            {
                DestinationRectangle = new Rectangle((int)Position.X, a, 597 / 9, 80);
            }

            public Rectangle GetRectangle()
            {
                return DestinationRectangle;
            }
        

            public override void Update(GameTime gametime)
            {

                MouseState mouse = Mouse.GetState();
                Vector2 mouseLocation = new Vector2(mouse.X, mouse.Y);

                Vector2 Direction = mouseLocation - Position;

                Angle = (float)(Math.Atan2(Direction.Y, Direction.X));


                DestinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, 597 / 9, 80);

            
            
            
                if (Position.X <= 0)
                {
                    Position.X = 0;
                }
                else if (Position.X >= 1020)
                {
                    Position.X = 1020;
                }

                else if (Position.Y <= 0)
                {
                    Position.Y = 0;
                }

                else if (Position.Y >= 500)
                {
                    Position.Y = 500;
                }

                if (InputManager.IsRightPressed())
                {
                    Velocity.X = (float)moveSpeed * (float)(gametime.ElapsedGameTime.TotalSeconds);
                }

                else if (InputManager.IsLeftPressed())
                {
                    Velocity.X = -(float)moveSpeed * (float)gametime.ElapsedGameTime.TotalSeconds;

                }

                else
                    Velocity.X = 0;


                if (InputManager.IsSpacePressed() && jump )
                {
                    Velocity.Y = -(float)jumpSpeed * (float)gametime.ElapsedGameTime.TotalSeconds;
                    jump = false;
                    /*
                    ElapsedTime += gametime.ElapsedGameTime.TotalSeconds;
                    if (ElapsedTime * 1000 >= Delay)
                    {
                        if (Frames >= 8)
                        {
                            Frames = 0;
                        }
                        else
                        {
                            Frames++;
                        }
                        ElapsedTime = 0;
                    }
                SourceRectangle = new Rectangle((597 / 9) * Frames, 0, 597 / 9, 80);
             * 
                     * 
                    //animation.Update(gametime);
                }

            

                

                if (!jump)
                    Velocity.Y += (float)InteractiveObject.Gravity * (float)gametime.ElapsedGameTime.TotalSeconds;
                else
                    Velocity.Y = 0;
            
                Position += Velocity;

                // Limit 
                jump = Position.Y >= 500;
                if (jump) Position.Y = 500;
            }
            public override void Draw(SpriteBatch spritebatch)
            {
                spritebatch.Draw(Texture, DestinationRectangle, SourceRectangle, Color.White);
                //spritebatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height), null, Color.White, Angle, new Vector2(Texture.Width / 2, Texture.Height / 2), SpriteEffects.None, 0);   
                //animation.Draw(spritebatch);
            }
            public override void LoadContent(ContentManager content)
            {
                Texture = content.Load<Texture2D>("InnerGame/Textures/lklk");
                //animation.Load(content, "InnerGame/Textures/lklk");
            }
        }
        */
}
