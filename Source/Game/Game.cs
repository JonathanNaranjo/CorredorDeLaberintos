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
        public Game() : base(width: Constants.SCREEN_WIDTH, height: Constants.SCREEN_HEIGHT, isFullScreen: false)
        {
			ManagerState = new StateManager();
		}

        protected override void Initialize()
        {
            base.Initialize();
			exitOnEscapeKeypress = false;
            Window.Title = Constants.GAME_TITLE;
            Window.AllowUserResizing = false;
            ManagerState.SetState(StateType.MainMenu);
        }
    }
}
