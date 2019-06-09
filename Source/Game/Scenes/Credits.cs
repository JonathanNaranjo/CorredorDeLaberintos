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
using Nez.BitmapFonts;
using Game.Scenes.Base;

namespace Game.Scenes
{
    /// <summary>
    /// Escena que presenta los creditos del juego
    /// </summary>
    class Credits : SceneBase
    {

        public override void onStart()
        {
            // Fondo
            var texture = content.Load<Texture2D>(Content.Image.credits);
            Image imag = canvas.stage.addElement(new Image(texture));
            imag.setWidth(Constants.SCREEN_WIDTH);
            imag.setHeight(Constants.SCREEN_HEIGHT);
            imag.setZIndex(0);

            // Boton atras
            //---------------
            var buttonStyle = new TextButtonStyle(new PrimitiveDrawable(new Color(78, 91, 98), 10f), new PrimitiveDrawable(new Color(244, 23, 135)), new PrimitiveDrawable(new Color(168, 207, 115)))
            {
                downFontColor = Color.Black
            };

            var backButton = canvas.stage.addElement(new TextButton(Constants.MENU_BACK, buttonStyle));
            backButton.onClicked += BackMenu => { Game.ManagerState.SetState(StateType.MainMenu, true); };
            backButton.setWidth(100);
            backButton.setHeight(20);
            backButton.setPosition(Constants.SCREEN_WIDTH - backButton.getWidth() - 15, Constants.SCREEN_HEIGHT - backButton.getHeight() - 5);
            //---------------
        }
    }
}
