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
    class Hero : InteractiveObject
    {        
        public static Hero Instance(Texture2D Texture, Vector2 Position, float Speed, Rectangle screenBound)
        {
            if (instance == null)
            {
                instance = new Hero(Texture, Position, Speed, screenBound);
            }
            return (Hero)instance;
        }

        private Hero(Texture2D Texture, Vector2 Position, float Speed, Rectangle screenBound)
        {
            this.Texture = Texture;
            this.Position = Position;
            ground = Position.Y;
            this.Speed = Speed;
            this.screenBound = screenBound;
            Velocity = Vector2.Zero;
            isJumping = goingUp = false;
            jumpU = 2.5f;
            g = -9.8f;
            t = 0;
        }

        public override void Update(GameTime gameTime)
        {
            Position.X += (Velocity.X * Speed);
            Position.Y -= (Velocity.Y * Speed);
            goingUp = (Velocity.Y > 0);

            if (isJumping == true)
            {
                //motion equation using velocity: v = u + at
                Velocity.Y = (float)(u + (g * t));
                //Increase the timer
                t += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (isJumping == true && Position.Y > screenBound.Height - Texture.Height)
            {
                Position.Y = ground = screenBound.Height - Texture.Height;
                Velocity.Y = 0;
                isJumping = false;
                t = 0;
            }

            if (Position.X < 0)
            {
                //if Texture touches left side of the screen, set the position to zero and the velocity to zero.
                Position.X = 0;
                Velocity.X = 0;
            }

            else if (Position.X + Texture.Width > screenBound.Width)
            {
                //if Texture touches left side of the screen, set the position to zero and the velocity to zero.
                Position.X = screenBound.Width - Texture.Width;
                Velocity.X = 0;
            }
            if (Position.Y < 0)
            {
                //if the Texture touches the top of the screen, reset the timer and set the initial velocity to zero.
                Position.Y = 0;
                t = 0;
                u = 0;
            }
        }

        public Vector2 GetVelocity()
        {
            return Velocity;
        }

        public void SetVelocity(Vector2 Velocity)
        {
            this.Velocity = Velocity;
        }

        public void Input(GameTime gametime)
        {
            // Jumping Motion
            if ((InputManager.IsSpacePressed()) && (isJumping == false || Position.Y == ground))
            {
                HeroMotion = new JumpingMotion();
                HeroMotion.Move(this);
            }

            // Left motion
            if (InputManager.IsLeftPressed() && !InputManager.IsRightPressed())
            {
                HeroMotion = new LeftMotion();
                HeroMotion.Move(this);
            }

            // Right Motion
            else if (!InputManager.IsLeftPressed() && InputManager.IsRightPressed())
            {
                HeroMotion = new RightMotion();
                HeroMotion.Move(this);
            }
            // Balancing Motion
            else
            {
                HeroMotion = new BalancingMotion();
                HeroMotion.Move(this);
            }
        }

        public void Fall()
        {
            t = 0;
            u = 0;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height), Color.White);
        }
    }
}
