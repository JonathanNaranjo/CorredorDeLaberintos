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
    /// <summary>
    /// Escena que define el menu principal
    /// </summary>
    class Menu : Scene
    {
        public UICanvas canvas;

        Table _table;
        List<Button> _sceneButtons = new List<Button>();

        public Menu() : base()
        {

        }
        public override void initialize()
        {
            base.initialize();

            clearColor = Color.BurlyWood;
			addRenderer(new DefaultRenderer());
            
            Screen.setSize(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);

            addRenderer(new ScreenSpaceRenderer(100, Constants.SCREEN_SPACE_MENU_RENDER_LAYER));
            addRenderer(new RenderLayerExcludeRenderer(0, Constants.SCREEN_SPACE_MENU_RENDER_LAYER));

            // creamos el canvas y lo ponemos por encima de la pantalla
            canvas = createEntity("ui").addComponent(new UICanvas());
            canvas.isFullScreen = true;
            canvas.renderLayer = Constants.SCREEN_SPACE_MENU_RENDER_LAYER;

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

        #region Eventos

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
        #endregion
    }
}
