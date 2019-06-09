using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.Textures;
using Nez.Tiled;
using Nez.UI;
using Game.Entities;
using Game.Components;
using Game.Factories;
using Microsoft.Xna.Framework;
using Game.Scenes.Base;

namespace Game.Scenes
{
    /// <summary>
    /// Escena que presenta el final del juego
    /// </summary>
    class EndGame : SceneBase
    {
        public override void onStart()
        {
            var texture = content.Load<Texture2D>(Content.Image.end_game);
            Image imag = canvas.stage.addElement(new Image(texture));
            imag.setWidth(Constants.SCREEN_WIDTH);
            imag.setHeight(Constants.SCREEN_HEIGHT);
            imag.setZIndex(0);
        }
    }
}
