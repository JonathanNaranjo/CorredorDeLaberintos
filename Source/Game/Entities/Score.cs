using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Nez.Sprites;
using Nez.Tiled;
using Nez.Textures;
using Nez.UI;
using Nez.BitmapFonts;
using Microsoft.Xna.Framework;
using Game.Components;

namespace Game.Entities
{
    class Score : Entity
    {
        private UICanvas canvas;
        private Label score;
        private PlayerInventary playerInventary;

        public Score(UICanvas canvas) : base(EntityType.Score.ToString())
        {
            this.canvas = canvas;
        }

        public override void onAddedToScene()
        {
            // Cargamos el estilo
            var textFont = scene.content.Load<BitmapFont>(Content.Font.text);
            score = new Label("", textFont);
            score.setPosition(20, 20);
            score.setFontColor(Color.LightGoldenrodYellow);
            score.setScale(1);
            canvas.stage.addElement(score);
            SearchPlayerInventy();
        }

        public override void update()
        {
            if (playerInventary != null)
            {
                score.setText("Coins: " + playerInventary.Coins + "   " + "Diamonds: " + playerInventary.Diamonds);
            }
            else
            {
                SearchPlayerInventy();
            }

        }

        private void SearchPlayerInventy()
        {
            var player = scene.findEntity("Player") as Player;
            if (player != null)
                playerInventary = player.getComponent<PlayerInventary>();
        }
    }
}
