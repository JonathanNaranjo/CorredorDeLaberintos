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

namespace Game.Scenes
{
    class Credits : Scene
    {
        public const int SCREEN_SPACE_RENDER_LAYER = 999;
        public UICanvas canvas;

        public override void initialize()
        {
            base.initialize();
            clearColor = Color.Black;
            var managerScene = createEntity("ManagerScene");
            managerScene.addComponent(new DebugScene());
            managerScene.addComponent(new LevelBehavior());

            addRenderer(new DefaultRenderer());

            Screen.setSize(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            canvas = createEntity("ui").addComponent(new UICanvas());
            canvas.isFullScreen = true;
            canvas.renderLayer = SCREEN_SPACE_RENDER_LAYER;
        }

        public override void onStart()
        {
            var texture = content.Load<Texture2D>(Content.Image.credits);
            Image imag = canvas.stage.addElement(new Image(texture));
            imag.setWidth(Constants.SCREEN_WIDTH);
            imag.setHeight(Constants.SCREEN_HEIGHT);
            imag.setZIndex(0);
        }
    }
}
