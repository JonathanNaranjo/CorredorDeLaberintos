using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game.Components;
using Nez;
using Nez.Sprites;
using Nez.Tiled;
using Nez.Textures;
using Microsoft.Xna.Framework.Media;
using Game.Entities.Base;
using Game.Scenes;

namespace Game.Entities
{
    /// <summary>
    /// Crea las explosiones
    /// </summary>
    class Puff : Entity, IUpdatable
    {
        private Sprite<AnimationType> animation;
        private int width = 27;
        private int height = 43;

        public Puff(Vector2 position) : base(EntityType.Puff.ToString())
        {
            this.position = position;
            addComponent(new PuffBehavior());
        }

        public override void onAddedToScene()
        {
            // Cargamos la hoja de sprites
            var texture = scene.content.Load<Texture2D>(Content.Sprite.puff_red);
            var subtextures = Subtexture.subtexturesFromAtlas(texture, width, height);
            animation = this.addComponent(new Sprite<AnimationType>(subtextures[0]));
            this.position = new Vector2(this.position.X, this.position.Y);


            // Establecemos las animaciones
            //---------------------------------------------------------------------------------
            // Idle (rotate)
            animation.addAnimation(AnimationType.Idle, new SpriteAnimation(new List<Subtexture>()
            {
                subtextures[0],
                subtextures[1],
                subtextures[2],
                subtextures[3],
                subtextures[4],
                subtextures[5],
                subtextures[6]
            }));

            this.Animation = AnimationType.Idle;   
        }

        public AnimationType Animation
        {
            get => this.animation.currentAnimation;
            set => this.animation.play(value);
        }

        public int GetCurrentFrameAnimacion()
        {
            return this.animation.currentFrame;
        }


    }
}
