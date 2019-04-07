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
		public static ManagerState ManagerState;
        public Game() : base(width: 635, height: 475, isFullScreen: false)
        {
			ManagerState = new ManagerState();
		}

        protected override void Initialize()
        {
            base.Initialize();
			exitOnEscapeKeypress = false;
            Window.Title = Constants.GAME_TITLE;
			ManagerState.SetState(StateType.MainMenu);
        }
    }
}
