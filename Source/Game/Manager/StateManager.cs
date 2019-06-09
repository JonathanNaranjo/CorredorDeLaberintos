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
    /// <summary>
    /// Realiza las transiciones a otras escenas
    /// </summary>
	public class StateManager
	{
		private Dictionary<StateType, Scene> scenesDict = new Dictionary<StateType, Scene>();
		private FadeTransition fadeTransition;
		private Scene sceneNext;
		private StateType currentState;
		public StateType CurrentState { get => currentState; }

		public void SetState(StateType state, bool transition = false)
		{
            // Codigo descartado, "Pause", no es viable reanudar una escena
            //----------
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

            SoundManager.StopMusic();
            SetScene(SceneFactory.CreateScene(state), transition);

		}

		private void SetScene(Scene scene, bool transition)
		{
            if (transition)
			{
                TweenManager.stopAllTweens();
                Game.startSceneTransition(new FadeTransition(() => scene));
            }
			else
			{
				Game.scene = scene;
			}
            
		}

	}
}
