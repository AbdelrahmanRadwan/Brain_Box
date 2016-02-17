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

namespace BrainBox
{
    static public class SoundManager
    {
        static public float PlayerVolume;
        public enum Player : short {EntrySound, BtnHover }
        private static Song EntrySound;
        private static SoundEffectInstance BtnSound;
        static public void Initialize()
        {
            PlayerVolume = 1.0F;
        }
        static public void LoadContent(ContentManager content)
        {
            EntrySound = content.Load<Song>("mus_theme");
            BtnSound = content.Load<SoundEffect>("btnhover").CreateInstance();
        }

        public static void Run(Player tempPlayer)
        {
            if (tempPlayer == SoundManager.Player.EntrySound)
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(EntrySound);
                MediaPlayer.IsRepeating = true;
            }

            else if (tempPlayer == SoundManager.Player.BtnHover)
            {
                BtnSound.Volume = PlayerVolume;
                BtnSound.Play();
            }
        }

        public static void Update()
        {

        }
        static public void Draw(SpriteBatch sp)
        {

        }
    }
}
