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
    /// Escena que define la pantalla de configuración
    /// </summary>
    class Config : SceneBase
    {
        public override void onStart()
        {
            var texture = content.Load<Texture2D>(Content.Image.configurar);
            Image Config = canvas.stage.addElement(new Image(texture));
            Config.setWidth(Constants.SCREEN_WIDTH);
            Config.setHeight(Constants.SCREEN_HEIGHT);
            Config.setZIndex(0);

            // Boton atras
            var buttonStyle = new TextButtonStyle(new PrimitiveDrawable(new Color(78, 91, 98), 10f), new PrimitiveDrawable(new Color(244, 23, 135)), new PrimitiveDrawable(new Color(168, 207, 115)))
            {
                downFontColor = Color.Black
            };

            var backButton = canvas.stage.addElement(new TextButton(Constants.MENU_BACK, buttonStyle));
            backButton.onClicked += BackMenu => { Game.ManagerState.SetState(StateType.MainMenu, true); };
            backButton.setWidth(100);
            backButton.setHeight(20);
            backButton.setPosition(Constants.SCREEN_WIDTH - backButton.getWidth() - 15, Constants.SCREEN_HEIGHT - backButton.getHeight() - 5);
        }
    }
}
