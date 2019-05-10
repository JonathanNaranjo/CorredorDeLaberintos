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
            // If the song is already playing, then bail out
            if (_currentSong == songName)
                return;
            _currentSong = songName;

            // Load and play the song
            var song = Core.content.Load<Song>(songName);
            MediaPlayer.Play(song);
            MediaPlayer.Volume = Global.Volume;
            MediaPlayer.IsRepeating = repeating;
        }

		public static void PlaySound(string songName)
		{
			var song = Core.content.Load<Song>(songName);
			MediaPlayer.Play(song);
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
