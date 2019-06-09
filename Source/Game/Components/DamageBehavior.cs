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
    /// <summary>
    /// Comportamiento de la entidad Damage
    /// </summary>
	class DamageBehavior : Component, ITriggerListener
	{
		#region ITriggerListener implementation

		void ITriggerListener.onTriggerEnter(Collider other, Collider self)
		{
			Debug.log("triggerEnter: {0}", other.entity.name);

			var playerEntity = other.entity as Player;
			if (playerEntity != null)
			{
				playerEntity.Kill();
			}
		}

		void ITriggerListener.onTriggerExit(Collider other, Collider self)
		{
			Debug.log("triggerExit: {0}", other.entity.name);
		}

		#endregion
	}
}
