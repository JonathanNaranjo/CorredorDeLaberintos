using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Game.Entities;
using Game.Components;
using Microsoft.Xna.Framework;
using Nez.Textures;
using Microsoft.Xna.Framework.Graphics;
using Nez.Sprites;

namespace Game.Scenes
{
    class IntroGame : Scene
    {

        public int timeToChange = 2;

        public override void initialize()
        {
            /*
            base.initialize();
            clearColor = Color.Aqua;
            addRenderer(new DefaultRenderer());

            // Time Entity
            var timeEntity = this.createEntity("Time");
            
            // TimeEvent to chage of scene in seconds
            var timedEvent = new TimeEvent(timeToChange);
            //timedEvent.Interval += this.ChangeToMenu;
            timedEvent.Active = true;
            timeEntity.addComponent(timedEvent);

            
            //Splash Entity
            var splashEntity = this.createEntity("Splash");
            var textureSplash = this.content.Load<Texture2D>(Content.Sprite.exit);
            var subtextureSplash = Subtexture.subtexturesFromAtlas(textureSplash, textureSplash.Width, textureSplash.Height);
            var spriteSplash = new TiledSprite(subtextureSplash[0]);
            spriteSplash.setOrigin(Vector2.Zero);
            //spriteSplash.width = 200;
            //spriteSplash.height = 200;

            splashEntity.position = new Vector2(100, 100);




            splashEntity.addComponent(spriteSplash);
            
          

            this.addEntity(timeEntity);
            */



        }

        public override void onStart()
        {
 
        }

        private void ChangeToMenu(object sender, EventArgs e)
        {
            //Game.ManagerState.SetState(StateType.MainMenu);
 
        }
    }
}
