using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.UI;
using Nez.Sprites;
using Nez.Textures;
using Microsoft.Xna.Framework;
using Nez.Tweens;

namespace Game.Scenes
{
    class Menu : SceneBase
    {
        public const int SCREEN_SPACE_RENDER_LAYER = 999;
        public UICanvas canvas;

        Table _table;
        List<Button> _sceneButtons = new List<Button>();
        ScreenSpaceRenderer _screenSpaceRenderer;

        public Menu() : base()
        {

        }
        public override void initialize()
        {
            base.initialize();

            // setup a pixel perfect screen that fits our map
            //setDesignResolution(512, 256, Scene.SceneResolutionPolicy.ShowAllPixelPerfect);
            //Screen.setSize(512 * 3, 256 * 3);
            //------
            clearColor = Color.BurlyWood;
			addRenderer(new DefaultRenderer());
            
            Screen.setSize(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);

			bool needsFullRenderSizeForUI = false;
            bool addExcludeRenderer = true;
            // setup one renderer in screen space for the UI and then (optionally) another renderer to render everything else
            if (needsFullRenderSizeForUI)
            {
                // dont actually add the renderer since we will manually call it later
                _screenSpaceRenderer = new ScreenSpaceRenderer(100, SCREEN_SPACE_RENDER_LAYER);
                _screenSpaceRenderer.shouldDebugRender = false;
                //finalRenderDelegate = this;
            }
            else
            {
                addRenderer(new ScreenSpaceRenderer(100, SCREEN_SPACE_RENDER_LAYER));
            }

            if (addExcludeRenderer)
                addRenderer(new RenderLayerExcludeRenderer(0, SCREEN_SPACE_RENDER_LAYER));

            // create our canvas and put it on the screen space render layer
            canvas = createEntity("ui").addComponent(new UICanvas());
            canvas.isFullScreen = true;
            canvas.renderLayer = SCREEN_SPACE_RENDER_LAYER;

            setupSceneSelector();
        }


        void setupSceneSelector()
        {
            _table = canvas.stage.addElement(new Table());
			_table.setFillParent(true).center().center();

            var topButtonStyle = new TextButtonStyle(new PrimitiveDrawable(Color.Black, 10f), new PrimitiveDrawable(Color.Yellow), new PrimitiveDrawable(Color.DarkSlateBlue))
            {
                downFontColor = Color.Black
            };
			if (!(Game.ManagerState.CurrentState == StateType.GamePlay))
			{
				_table.add(new TextButton(Constants.MENU_PLAY, topButtonStyle)).setFillX().setMinHeight(30).getElement<Button>().onClicked += MenuPlay;
			}
			else
			{
				_table.add(new TextButton(Constants.MENU_RESUMEN, topButtonStyle)).setFillX().setMinHeight(30).getElement<Button>().onClicked += MenuPlay;
			}
				

            _table.row();
            _table.add(new TextButton(Constants.MENU_CONFIG, topButtonStyle)).setFillX().setMinHeight(30).getElement<Button>().onClicked += MenuConfig;
            _table.row();
            _table.add(new TextButton(Constants.MENU_CREDITS, topButtonStyle)).setFillX().setMinHeight(30).getElement<Button>().onClicked += MenuCredits;
            _table.row();
            _table.add(new TextButton(Constants.MENU_EXIT, topButtonStyle)).setFillX().setMinHeight(30).getElement<Button>().onClicked += MenuExit;
        }

        private void MenuPlay(Button butt)
        {
			Game.ManagerState.SetState(StateType.GamePlay, false);
		}

        private void MenuConfig(Button butt)
        {
			
        }

        private void MenuCredits(Button butt)
        {

        }

        private void MenuExit(Button butt)
        {
            Game.exit();
        }
    }
}
