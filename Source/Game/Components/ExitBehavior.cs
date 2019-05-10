using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Entities;
using Game.Scenes;
using Nez;

namespace Game.Components
{
    class ExitBehavior : Component, ITriggerListener
	{
		#region ITriggerListener implementation

		void ITriggerListener.onTriggerEnter(Collider other, Collider self)
		{
			Debug.log("triggerEnter: {0}", other.entity.name);

			if ((other.entity as Player) != null)
			{
				//Game.ManagerState.SetState(StateType.MainMenu);
				(other.entity.scene as Level)?.findComponentOfType<LevelBehavior>().SetNextState(StateType.MainMenu);
			}
		}


		void ITriggerListener.onTriggerExit(Collider other, Collider self)
		{
			Debug.log("triggerExit: {0}", other.entity.name);
		}

		#endregion
	}
}
