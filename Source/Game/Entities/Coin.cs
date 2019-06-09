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
using Game.Factories;
using Game.Entities.Base;

namespace Game.Entities
{
    /// <summary>
    /// Entidad Coin
    /// </summary>
    public class Coin : ItemBase
    {
        private Sprite<AnimationType> animation;
        private int sizeFrame = 16;

        public Coin(Vector2 position) : base(EntityType.Coin.ToString())
        {
            this.position = position;
            addComponent(new ItemBehavior());
            addComponent<CircleCollider>();
        }

        public override void onAddedToScene()
        {
            // Cargamos las hojas de sprites
            var texture = scene.content.Load<Texture2D>(Content.Sprite.coin);
            var subtextures = Subtexture.subtexturesFromAtlas(texture, sizeFrame , sizeFrame);
            animation = this.addComponent(new Sprite<AnimationType>(subtextures[0]));
            this.position = new Vector2(this.position.X + sizeFrame / 2, this.position.Y);
            

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

        public override void Touch()
        {
            var player = scene.findEntity("Player") as Player;
            if (player != null)
                player.getComponent<PlayerInventary>().Coins++;

            SoundManager.PlaySound(Content.Sound.coin);
        }
    }
}
