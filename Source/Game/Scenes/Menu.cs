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
using Nez.BitmapFonts;

namespace Game.Scenes
{
    class Menu : Scene
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
        }


        public override void onStart()
        {
            // Fondo de menu
            var texture = content.Load<Texture2D>(Content.Image.menu_background);
            Image imag = canvas.stage.addElement(new Image(texture));
            imag.setWidth(Constants.SCREEN_WIDTH);
            imag.setHeight(Constants.SCREEN_HEIGHT);
            imag.setZIndex(0);

            // Cargamos el estilo
            var textFont = content.Load<BitmapFont>(Content.Font.text);
            TextButtonStyle topButtonStyle = new TextButtonStyle()
            {
                font = textFont,
                fontColor = Color.Black,
                overFontColor = Color.Brown,
                downFontColor = Color.DarkRed
            };

            // Creamos los botones
            _table.add(new TextButton(Constants.MENU_PLAY, topButtonStyle)).setFillX().setMinHeight(30).getElement<Button>().onClicked += MenuPlay;
            _table.row();
            _table.add(new TextButton(Constants.MENU_CONFIG, topButtonStyle)).setFillX().setMinHeight(30).getElement<Button>().onClicked += MenuConfig;
            _table.row();
            _table.add(new TextButton(Constants.MENU_CREDITS, topButtonStyle)).setFillX().setMinHeight(30).getElement<Button>().onClicked += MenuCredits;
            _table.row();
            _table.add(new TextButton(Constants.MENU_EXIT, topButtonStyle)).setFillX().setMinHeight(30).getElement<Button>().onClicked += MenuExit;

        }

        private void MenuPlay(Button butt)
        {
            Game.ManagerState.SetState(StateType.GamePlay, true);
        }

        private void MenuConfig(Button butt)
        {
            Game.ManagerState.SetState(StateType.Config, true);
        }

        private void MenuCredits(Button butt)
        {
            Game.ManagerState.SetState(StateType.Credits, true);
        }

        private void MenuExit(Button butt)
        {
            Game.exit();
        }
    }
}
