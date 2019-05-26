using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Content
    {
        public static class Font
        {
            public const string text = @"Font\textFont";
        }
		public static class Terrain
		{
			public const string bg1 = @"Terrain\bg1";
			public const string bg2 = @"Terrain\bg2";
			public const string bg3 = @"Terrain\bg3";
			public const string bg4 = @"Terrain\bg4";
		}
		public static class Sprite
        {
            public const string player = @"Sprite\player";
            public const string coin = @"Sprite\coin";
            public const string diamond = @"Sprite\diamond";
            public const string bug1 = @"Sprite\bug1";
            public const string bug2 = @"Sprite\bug2";
            public const string exit = @"Sprite\exit";
            public const string mine = @"Sprite\mine";

        }

        public static class Image
        {
            public const string end_game = @"Image\end_game";
            public const string credits = @"Image\credits";
            public const string configurar = @"Image\configurar";
            public const string menu_background = @"Image\menu_background";
        }

        public static class Menu
        {
            public const string btn_jugar_on = @"Menu\btn_jugar_on";
            public const string btn_jugar_off = @"Menu\btn_jugar_off";
        }

        public static class Music
        {
            public const string level1 = @"Music\level1_music";
        }

        public static class Sound
        {
            public const string coin = @"Sound\coin";
            public const string jump = @"Sound\jump";
			public const string squish = @"Sound\squish";
			public const string slide = @"Sound\slide";
			public const string diamond = @"Sound\diamond";
			public const string death = @"Sound\death";
			public const string slidejump = @"Sound\slidejump";
			public const string land = @"Sound\land";
			public const string mine = @"Sound\mine";
		}

        public static class Map
        {
            public const string level1 = @"Map\Level1";
        }
    }
}
