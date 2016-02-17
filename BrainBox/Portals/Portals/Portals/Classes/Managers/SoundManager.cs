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

namespace Portals
{
    static public class SoundManager
    {
        static public float PlayerVolume;
        public enum Player : short { Menu, ChoosingLevel, Credits , BtnHover , Level1 }
        private static Song MenuSound;
        private static Song GameEntrySound;
        private static SoundEffectInstance BtnSound;
        static public void Initialize()
        {
            PlayerVolume = 1.0F;
        }
        static public void LoadContent(ContentManager content)
        {
            MenuSound = content.Load<Song>("InnerGame/Sound/Menu");
            BtnSound = content.Load<SoundEffect>("InnerGame/Sound/btn").CreateInstance();
        }

        public static void Run(Player tempPlayer)
        {
            if (tempPlayer == SoundManager.Player.Menu)
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(MenuSound);
                MediaPlayer.IsRepeating = true;
            }

            else if (tempPlayer == SoundManager.Player.Credits)
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(GameEntrySound);
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Volume = 0.1F;
            }

            else if (tempPlayer == SoundManager.Player.BtnHover)
            {
                BtnSound.Volume = PlayerVolume;
                BtnSound.Play();
            }
        }

    }
}
