using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace Game.Components
{
    /// <summary>
    /// Detecta y notifica las colisiones producidas entre las entidades
    /// </summary>
    class ColliderNotify : Component, IUpdatable
    {
        private List<ITriggerListener> _tempTriggerList = new List<ITriggerListener>();
        private Collider _collider;

        public override void onAddedToEntity()
        {
            _collider = entity.getComponent<Collider>();
            //Assert.isNotNull(_collider, "null Collider. ProjectilMover requires a Collider!");
        }

        public void update()
        {
            // fetch anything that we might collide with us at our new position
            var neighbors = Physics.boxcastBroadphase(_collider.bounds, _collider.collidesWithLayers);
            foreach (var neighbor in neighbors)
            {
                if (_collider.overlaps(neighbor))
                {
                    //didCollide = true;
                    notifyTriggerListeners(_collider, neighbor);
                }
            }
        }

        private void notifyTriggerListeners(Collider self, Collider other)
        {
            // notify any listeners on the Entity of the Collider that we overlapped
            other.entity.getComponents(_tempTriggerList);
            for (var i = 0; i < _tempTriggerList.Count; i++)
                _tempTriggerList[i].onTriggerEnter(self, other);

            _tempTriggerList.Clear();

            // notify any listeners on this Entity
            entity.getComponents(_tempTriggerList);
            for (var i = 0; i < _tempTriggerList.Count; i++)
                _tempTriggerList[i].onTriggerEnter(other, self);

            _tempTriggerList.Clear();
        }
    }


}
