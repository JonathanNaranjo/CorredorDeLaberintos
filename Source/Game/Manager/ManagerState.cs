using Game.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Nez.Tweens;
using Game.Scenes;

namespace Game
{
	public enum StateType
	{
		IntroGame, MainMenu, Config, Credits, GamePlay, LoadLevel, EndOfGame
	}

	public class ManagerState
	{
		private Dictionary<StateType, Scene> scenesDict = new Dictionary<StateType, Scene>();

		private StateType currentState;
		public StateType CurrentState { get => currentState; }

		public void SetState(StateType state, bool persistent = false)
		{
			Scene scene = null;
			
			// If exist in the dictionary
			if (scenesDict.ContainsKey(state))
			{
				scene = scenesDict[state];
				this.currentState = state;

				if (!persistent)
				{
					scenesDict.Remove(state);
				}

				SetScene(scene);
			}
			else
			{
				scene = SceneFactory.CreateScene(state);
				this.currentState = state;

				if (persistent)
				{
					scenesDict.Add(state, scene);
				}

				SetScene(scene);
			}

		}

		private void SetScene(Scene scene)
		{
			Game.scene = scene;
			/*
			if (Game.scene != null)
			{
				TweenManager.stopAllTweens();
				Game.startSceneTransition(new FadeTransition(() => scene));
			}
			else
			{
				Game.scene = scene;
			}
			*/
		}

		
	}
}
