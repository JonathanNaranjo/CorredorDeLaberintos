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

namespace Game.Scenes.Base
{
    /// <summary>
    /// Escena base que heredan las demas escenas
    /// </summary>
    class SceneBase : Scene
    {
        public UICanvas canvas;
        ScreenSpaceRenderer _screenSpaceRenderer;

        public override void initialize()
        {
            clearColor = Color.Black;
            addRenderer(new DefaultRenderer());
            var managerScene = createEntity("ManagerScene");
            managerScene.addComponent(new DebugScene());
            managerScene.addComponent(new LevelBehavior());

            // setup a pixel perfect screen that fits our map 
            setDesignResolution(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT, Scene.SceneResolutionPolicy.ShowAllPixelPerfect);

            _screenSpaceRenderer = addRenderer(new ScreenSpaceRenderer(100, Constants.SCREEN_SPACE_MENU_RENDER_LAYER));
            _screenSpaceRenderer.shouldDebugRender = true;

            addRenderer(new RenderLayerExcludeRenderer(0, 5));
            Screen.setSize(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);

            canvas = createEntity("ui").addComponent(new UICanvas());
            canvas.isFullScreen = true;
            canvas.renderLayer = Constants.SCREEN_SPACE_MENU_RENDER_LAYER;
        }
    }
}
