using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Game.Entities;
using Nez;
using Game.Entities.Base;

namespace Game.Components
{
    /// <summary>
    /// Comportamiento de las entidades Coin y Diamond
    /// </summary>
    class ItemBehavior : Component, ITriggerListener
    {
        #region ITriggerListener implementation

        void ITriggerListener.onTriggerEnter(Collider other, Collider self)
        {
            Debug.log("triggerEnter: {0}", other.entity.name);

            var parent = this.entity as ItemBase;
			if (parent != null)
				parent.Touch();

            entity.destroy();
        }


        void ITriggerListener.onTriggerExit(Collider other, Collider self)
        {
            Debug.log("triggerExit: {0}", other.entity.name);
        }

        #endregion
    }
}
