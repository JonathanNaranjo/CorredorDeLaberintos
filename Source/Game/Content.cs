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

        public static class Sprite
        {
            public const string player = @"Sprites\player";
            public const string coin = @"Sprites\coin";
			public const string bug1 = @"Sprites\bug1";
			public const string exit = @"Sprites\exit";
		}

        public static class Sound
        {
            public const string coin = @"Sound\coin";
            public const string jump = @"Sound\jump";
        }

        public static class Map
        {
            public const string tiledMap = @"Map\test";
            public const string tileset = @"Map\tileset";
        }
    }
}
