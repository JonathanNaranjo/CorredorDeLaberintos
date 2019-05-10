using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Game.Scenes;
using System;
using Game.Factories;

namespace Game
{
    public class Game : Core
    {
		public static StateManager ManagerState;
        public Game() : base(width: 635, height: 475, isFullScreen: false)
        {
			ManagerState = new StateManager();
		}

        protected override void Initialize()
        {
            base.Initialize();
			exitOnEscapeKeypress = false;
            Window.Title = Constants.GAME_TITLE;
            Window.AllowUserResizing = false;
            scene = new Level();
        }
    }
}
