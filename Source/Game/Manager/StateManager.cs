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

	public class StateManager
	{
		private Dictionary<StateType, Scene> scenesDict = new Dictionary<StateType, Scene>();
		private FadeTransition fadeTransition;
		private Scene sceneNext;
		private StateType currentState;
		public StateType CurrentState { get => currentState; }

		public void SetState(StateType state, bool persistent = false)
		{
			/*
			// If exist in the dictionary
			if (scenesDict.ContainsKey(state))
			{
				scene = scenesDict[state];
				this.currentState = state;
                SetScene(scene);

                if (!persistent)
				{
					scenesDict.Remove(state);
				}
			}
			else
			{
				scene = SceneFactory.CreateScene(state);
				this.currentState = state;
                SetScene(scene);

                if (persistent)
				{
					scenesDict.Add(state, scene);
				}

				
			}*/
            
            SetScene(SceneFactory.CreateScene(state));

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
			//Game.scene.
			//Game.scene = scene;

			/*
			TweenManager.stopAllTweens();
			Game.startSceneTransition(new FadeTransition(() => scene));
			*/
		}

	}
}
