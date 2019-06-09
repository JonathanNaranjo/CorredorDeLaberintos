using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using Nez.Tiled;
using Nez.Textures;

namespace Game.Components
{
    /// <summary>
    /// Comportamiento de las animaciones del Player
    /// </summary>
    public class PlayerAnimations : Component
    {
        private Sprite<AnimationType> animation;

        public override void onAddedToEntity()
        {
            var texture = entity.scene.content.Load<Texture2D>(Content.Sprite.player);
            var subtextures = Subtexture.subtexturesFromAtlas(texture, 32, 32);
            animation = this.addComponent(new Sprite<AnimationType>(subtextures[0]));

            // Set animations
            //---------------------------------------------------------------------------------
            // Idle
            animation.addAnimation(AnimationType.Idle, new SpriteAnimation(new List<Subtexture>()
            {
                subtextures[11],
                subtextures[11],
                subtextures[11],
                subtextures[11],
                subtextures[11],
                subtextures[11],
                subtextures[11],
                subtextures[11],
                subtextures[11],
                subtextures[11],
                subtextures[0]
            }));

            // Walk
            animation.addAnimation(AnimationType.Walk, new SpriteAnimation(new List<Subtexture>()
            {
                subtextures[13],
                subtextures[14],
                subtextures[15],
                subtextures[16],
                subtextures[17],
                subtextures[18]
            }));

            // Run
            animation.addAnimation(AnimationType.Run, new SpriteAnimation(new List<Subtexture>()
            {
                subtextures[13],
                subtextures[14],
                subtextures[15],
                subtextures[16],
                subtextures[17],
                subtextures[18]
            }));

            // Blink
            animation.addAnimation(AnimationType.Blink, new SpriteAnimation(new List<Subtexture>()
            {
                subtextures[0],
                subtextures[11]
            }));

            // Slide
            animation.addAnimation(AnimationType.Slide, new SpriteAnimation(new List<Subtexture>()
            {
                subtextures[10],
                subtextures[10],
                subtextures[10],
                subtextures[10],
                subtextures[10],
                subtextures[10],
                subtextures[10],
                subtextures[10],
                subtextures[10]

            }));

            // Flip
            animation.addAnimation(AnimationType.Flip, new SpriteAnimation(new List<Subtexture>()
            {
                subtextures[2],
                subtextures[3],
                subtextures[4],
                subtextures[5],
                subtextures[6],
                subtextures[7],
                subtextures[8],
                subtextures[9]
            }));

            // Falling
            animation.addAnimation(AnimationType.Falling, new SpriteAnimation(new List<Subtexture>()
            {
                subtextures[1]
            }));

            // Jumping
            animation.addAnimation(AnimationType.Jumping, new SpriteAnimation(new List<Subtexture>()
            {
                subtextures[12]
            }));
        }

        public AnimationType Animation
        {
            get => this.animation.currentAnimation;
            set => this.animation.play(value);
        }
        public bool FlipX { get => this.animation.flipX; set => this.animation.flipX = value; }
    }


}
