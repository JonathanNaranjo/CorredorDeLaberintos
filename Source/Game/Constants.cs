using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Almacena todas las constantes del juego
    /// </summary>
    class Constants
    {
		public const int SCREEN_WIDTH = 640;
		public const int SCREEN_HEIGHT = 480;
        public const int SCREEN_SPACE_MENU_RENDER_LAYER = 999;

        public const int TILE_SIZE = 16;
        public static float Volume = 0.2f;

        // Menu
        public const string		GAME_TITLE			= "Corredor de Laberintos";
        public const string		MENU_PLAY			= "Jugar";
		public const string		MENU_RESUMEN		= "Resumen";
		public const string		MENU_CONFIG			= "Configurar";
        public const string		MENU_CREDITS		= "Creditos";
        public const string		MENU_EXIT			= "Salir";
        public const string     MENU_BACK           = "Atras";

        public const float BackgroundSpeed = 25f;
	}
}
