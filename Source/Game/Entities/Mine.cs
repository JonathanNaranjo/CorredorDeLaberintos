using Game.Components;
using Game.Entities.Base;
using Game.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.Textures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entities
{
    /// <summary>
    /// Entidad Mine
    /// </summary>
	public class Mine : EnemyBase
	{
		private Sprite<AnimationType> animation;
		private int sizeFrame = 32;
		private BoxCollider boxCollider;
		public int Width { get => (int)boxCollider.width; }
		public int Height { get => (int)boxCollider.height; }
		public AnimationType Animation
		{
			get => this.animation.currentAnimation;
			set => this.animation.play(value);
		}
		public bool FlipX { get => this.animation.flipX; set => this.animation.flipX = value; }
		private double deathCounter;
		private double deathLimit;

		public Mine(Vector2 position) : base(EntityType.Mine.ToString())
		{
			this.position = position;
			addComponent(new MineBehavior());
			boxCollider = addComponent<BoxCollider>();
			boxCollider.setHeight(32);
			boxCollider.setWidth(32);
			this.deathLimit = 0.8;
		}


		public override void onAddedToScene()
		{
			(scene as Level)?.SetMapCollition(this);
			this.position = new Vector2(this.position.X, this.position.Y);

            // Cargamos la hoja de sprites
			var texture = scene.content.Load<Texture2D>(Content.Sprite.mine);
			var subtextures = Subtexture.subtexturesFromAtlas(texture, sizeFrame, 32);
			animation = this.addComponent(new Sprite<AnimationType>(subtextures[0]));

			// Establecemos las animaciones
			//---------------------------------------------------------------------------------
			// Walk
			animation.addAnimation(AnimationType.Idle, new SpriteAnimation(new List<Subtexture>()
			{
				subtextures[0],
			}));

			this.Animation = AnimationType.Idle;
		}

		public override void update()
		{
			base.update();

			if (!Alive)
			{
				deathCounter += Time.deltaTime;
				if (deathCounter > deathLimit)
                {
                    var player = (Player)this.scene.findEntity("Player");
                    if (player != null)
                        player.Kill();

                    this.destroy();
                }
					
			}
		}

		public override void Kill()
		{
            this.scene.addEntity(new Puff(this.position));
            this.animation.enabled = false;
			this.Alive = false;
			SoundManager.PlaySound(Content.Sound.mine);
		}
	}
}
