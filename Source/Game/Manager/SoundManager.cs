using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public static class SoundManager
    {
        public enum MusicTrack
        {
            Cool_Morning,
            Warning
        }

        private static string _currentSong;

        public static void PlayMusic(MusicTrack track, bool repeating = true)
        {
            PlayMusic(track.ToString(), repeating);
        }

        public static void PlayMusic(string songName, bool repeating = true)
        {
            _currentSong = songName;

            // Load and play the song
            var song = Core.content.Load<Song>(songName);
            MediaPlayer.Play(song);
            MediaPlayer.Volume = Global.Volume;
            MediaPlayer.IsRepeating = repeating;
        }

        public static void StopMusic()
        {
            MediaPlayer.Stop();
        }


        public static void PlaySound(string songName)
		{
            SoundEffect song = Core.content.Load<SoundEffect>(songName);
            song.Play();
        }

        public static void SetVolume(float value)
        {
            Global.Volume = Mathf.clamp(value, 0f, 1f);
            MediaPlayer.Volume = Global.Volume;
            // TODO: Update volume UI display
        }

        public static void RaiseVolume(float value = 0.1f)
        {
            Global.Volume = Mathf.clamp(Global.Volume + value, 0f, 1f);
            MediaPlayer.Volume = Global.Volume;
            // TODO: Update volume UI display
        }

        public static void LowerVolume(float value = 0.1f)
        {
            Global.Volume = Mathf.clamp(Global.Volume - value, 0f, 1f);
            MediaPlayer.Volume = Global.Volume;
            // TODO: Update volume UI display
        }
    }
}
