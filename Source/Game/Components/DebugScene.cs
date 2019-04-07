using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using Nez.Tiled;
using Nez.Textures;

namespace Game.Components
{
    public class DebugScene : Component, IUpdatable
    {
        VirtualButton inputKey;


        public override void onAddedToEntity()
        {
            this.inputKey = new VirtualButton();
            this.inputKey.nodes.Add(new Nez.VirtualButton.KeyboardKey(Keys.F12));
        }

        void IUpdatable.update()
        {
            if (inputKey.isReleased)
                Core.debugRenderEnabled = !Core.debugRenderEnabled;
        }
    }
}
