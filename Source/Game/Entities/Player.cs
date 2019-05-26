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
    public class Player : PlayerBase
    {
        private BoxCollider boxCollider;
		private PlayerController playerController;
        private PlayerInventary playerInventary;
		public int Width { get => (int)boxCollider.width; }
		public int Height { get => (int)boxCollider.height; }



		public Player(Vector2 position) : base("Player")
        {
            this.position = position;
			boxCollider = addComponent<BoxCollider>();
            addComponent<PlayerAnimations>();
            playerController = addComponent<PlayerController>();
            addComponent<ColliderNotify>();
            playerInventary = addComponent<PlayerInventary>();
			
        }

        public override void onAddedToScene()
        {
			(scene as Level)?.SetMapCollition(this);
			this.scene.camera.entity.addComponent(new FollowCamera(this));

            boxCollider.setWidth(12);
            boxCollider.setHeight(32);
        }


		public void SetInitialPosition()
		{
            playerInventary.ResetInventary();
			playerController.SetInitialPosition();
		}

		public override void Kill()
		{
			var level = scene as Level;
			level?.RestartLevel();
			SoundManager.PlaySound(Content.Sound.death);
			SetInitialPosition();
		}

		public void Impulse()
		{
			playerController.Impulse();
		}
	}
}
