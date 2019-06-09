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
    /// Comportamiento de la entidad Puff
    /// </summary>
    class PuffBehavior : Component, IUpdatable
    {
        private Puff puffEntity;


        public override void onAddedToEntity()
        {
            this.puffEntity = (Puff)entity;
        }

        public void update()
        {
            if (puffEntity.GetCurrentFrameAnimacion() == 6)
            {
                puffEntity.destroy();
            }
        }
    }
}
