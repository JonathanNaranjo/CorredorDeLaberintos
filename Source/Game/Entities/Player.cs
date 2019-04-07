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

namespace Game.Entities
{
    enum Animations
    {
        Walk,
        Run,
        Idle,
        Attack,
        Death,
        Falling,
        Hurt,
        Jumping
    }

    

    public class Player : Entity
    {

        BoxCollider boxCollider;
        private Song soundJump;


        public Player(Vector2 position) : base("Player")
        {
            this.position = position;
            boxCollider = addComponent<BoxCollider>();
            addComponent<PlayerAnimations>();
            addComponent<PlayerController>();
            addComponent<ColliderNotify>();
        }

        public override void onAddedToScene()
        {
            boxCollider.setWidth(16);
            boxCollider.setHeight(32);

            soundJump = scene.content.Load<Song>(Content.Sound.jump);
        }

        public void PlayJump()
        {
            MediaPlayer.Play(soundJump);
        }
    }
}
