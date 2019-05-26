using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Systems;

namespace Game.Components
{
	class LevelBehavior : Component, IUpdatable
	{
		VirtualButton escapeInput;
		private StateType nextState;
		private bool hasNewState = false;

		/// <summary>
		/// Init
		/// </summary>
		public override void onAddedToEntity()
		{
			escapeInput = new VirtualButton();
			escapeInput.nodes.Add(new Nez.VirtualButton.KeyboardKey(Keys.Escape));
		}
		public override void onRemovedFromEntity()
		{
			// deregister virtual input
			escapeInput.deregister();
		}

		public void update()
		{
			if (escapeInput.isReleased)
			{
				Game.ManagerState.SetState(StateType.MainMenu, true);
			}

			if (hasNewState)
			{
				Game.ManagerState.SetState(nextState);
				hasNewState = false;
			}
		}

		public void SetNextState(StateType nextState)
		{
			this.nextState = nextState;
			this.hasNewState = true;
		}
	}
}
