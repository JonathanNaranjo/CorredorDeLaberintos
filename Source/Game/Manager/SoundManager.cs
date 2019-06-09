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
    /// <summary>
    /// Administra y reproduce musica y efectos de sonido
    /// </summary>
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

            // Cargamos y reproducimos el efecto de sonido
            var song = Core.content.Load<Song>(songName);
            MediaPlayer.Play(song);
            MediaPlayer.Volume = Constants.Volume;
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
            Constants.Volume = Mathf.clamp(value, 0f, 1f);
            MediaPlayer.Volume = Constants.Volume;
        }

        public static void RaiseVolume(float value = 0.1f)
        {
            Constants.Volume = Mathf.clamp(Constants.Volume + value, 0f, 1f);
            MediaPlayer.Volume = Constants.Volume;
        }

        public static void LowerVolume(float value = 0.1f)
        {
            Constants.Volume = Mathf.clamp(Constants.Volume - value, 0f, 1f);
            MediaPlayer.Volume = Constants.Volume;
        }
    }
}
