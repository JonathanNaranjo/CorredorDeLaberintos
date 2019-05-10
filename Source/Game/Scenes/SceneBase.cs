using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Tweens;


namespace Game.Scenes
{
    class SceneBase : Scene, IFinalRenderDelegate
    {
        public const int SCREEN_SPACE_RENDER_LAYER = 999;
        ScreenSpaceRenderer _screenSpaceRenderer;

        public SceneBase()
        {
            _screenSpaceRenderer = new ScreenSpaceRenderer(100, SCREEN_SPACE_RENDER_LAYER);
            addRenderer(new ScreenSpaceRenderer(100, SCREEN_SPACE_RENDER_LAYER));
            addRenderer(new RenderLayerExcludeRenderer(0, SCREEN_SPACE_RENDER_LAYER));
        }
        #region IFinalRenderDelegate

        public Scene scene { get; set; }



        public void onSceneBackBufferSizeChanged(int newWidth, int newHeight)
        {
            _screenSpaceRenderer.onSceneBackBufferSizeChanged(newWidth, newHeight);
        }


        public void onAddedToScene(Scene scene)
        {

        }

        public void handleFinalRender(RenderTarget2D finalRenderTarget, Color letterboxColor, RenderTarget2D source, Rectangle finalRenderDestinationRect, SamplerState samplerState)
        {
            Core.graphicsDevice.SetRenderTarget(null);
            Core.graphicsDevice.Clear(letterboxColor);
            Graphics.instance.batcher.begin(BlendState.Opaque, samplerState, DepthStencilState.None, RasterizerState.CullNone, null);
            Graphics.instance.batcher.draw(source, finalRenderDestinationRect, Color.White);
            Graphics.instance.batcher.end();

            _screenSpaceRenderer.render(scene);
        }

        #endregion
    }
}
