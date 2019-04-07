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
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Game.Entities
{
    class Coin : Entity
    {
        private Sprite<TypeAnimation> animation;
        private int sizeFrame = 16;
        private Song soundCoin;

        public Coin(Vector2 position) : base("Coin")
        {
            this.position = position;
            addComponent(new CoinBehavior());
            addComponent<CircleCollider>();
        }

        public override void onAddedToScene()
        {
            soundCoin = scene.content.Load<Song>(Content.Sound.coin);

            var texture = scene.content.Load<Texture2D>(Content.Sprite.coin);
            var subtextures = Subtexture.subtexturesFromAtlas(texture, sizeFrame , sizeFrame);
            animation = this.addComponent(new Sprite<TypeAnimation>(subtextures[0]));
            this.position = new Vector2(this.position.X + sizeFrame / 2, this.position.Y);
            

            // Set animations
            //---------------------------------------------------------------------------------
            // Idle (rotate)
            animation.addAnimation(TypeAnimation.Idle, new SpriteAnimation(new List<Subtexture>()
            {
                subtextures[0],
                subtextures[1],
                subtextures[2],
                subtextures[3],
                subtextures[4],
                subtextures[5],
                subtextures[6]
            }));

            this.Animation = TypeAnimation.Idle;
        }

        public TypeAnimation Animation
        {
            get => this.animation.currentAnimation;
            set => this.animation.play(value);
        }

        public void PlayCoin()
        {
            MediaPlayer.Play(soundCoin);
        }
    }
}
