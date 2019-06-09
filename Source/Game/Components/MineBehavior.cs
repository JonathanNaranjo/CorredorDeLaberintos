using Game.Entities;
using Game.Entities.Base;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Components
{
    /// <summary>
    /// Comportamiento de la entidad Mine
    /// </summary>
	class MineBehavior : Component, ITriggerListener
	{
		private Mine mineEntity;
		private float moveSpeed = 50;
		private float gravity = 1000;
		BoxCollider boxCollider;

		public override void onAddedToEntity()
		{
			mineEntity = (Mine)entity;
			boxCollider = entity.getComponent<BoxCollider>();
            boxCollider.setHeight(20);
        }

		#region ITriggerListener implementation

		void ITriggerListener.onTriggerEnter(Collider other, Collider self)
		{
			Debug.log("triggerEnter: {0}", other.entity.name);

			var characterEntity = other.entity as CharacterBase;
			if (characterEntity != null)
			{
                characterEntity.enabled = false;
				mineEntity.Kill();
			}


		}

		void ITriggerListener.onTriggerExit(Collider other, Collider self)
		{
			Debug.log("triggerExit: {0}", other.entity.name);
		}

		#endregion
	}

}
