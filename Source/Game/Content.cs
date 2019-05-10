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
            public const string scoreFont = @"font\scoreFont";
            public const string textFont = @"font\textFont";
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
            public const string player = @"Sprites\player";
            public const string coin = @"Sprites\coin";
            public const string diamond = @"Sprites\diamond";
            public const string bug1 = @"Sprites\bug1";
			public const string exit = @"Sprites\exit";
            public const string splash = @"Sprites\splash";
            public const string mine = @"Sprites\mine";
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
            public const string tiledMap = @"Map\test";
            public const string tileset = @"Map\tileset";
        }
    }
}
