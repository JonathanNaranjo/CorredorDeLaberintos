using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Entities;
using Nez;

namespace Game.Components
{
	class DamageBehavior : Component, ITriggerListener
	{
		#region ITriggerListener implementation

		void ITriggerListener.onTriggerEnter(Collider other, Collider self)
		{
			Debug.log("triggerEnter: {0}", other.entity.name);

			if ((other.entity as Player) != null)
			{
				Game.ManagerState.SetState(StateType.GamePlay);
			}
		}

		void ITriggerListener.onTriggerExit(Collider other, Collider self)
		{
			Debug.log("triggerExit: {0}", other.entity.name);
		}

		#endregion
	}
}
