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
	public class Mine : EnemyBase
	{
		private Sprite<TypeAnimation> animation;
		private int sizeFrame = 32;
		private BoxCollider boxCollider;
		public int Width { get => (int)boxCollider.width; }
		public int Height { get => (int)boxCollider.height; }
		public TypeAnimation Animation
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
			this.deathLimit = 0.5;
		}


		public override void onAddedToScene()
		{
			(scene as Level)?.SetMapCollition(this);
			this.position = new Vector2(this.position.X, this.position.Y);

			var texture = scene.content.Load<Texture2D>(Content.Sprite.mine);
			var subtextures = Subtexture.subtexturesFromAtlas(texture, sizeFrame, 32);
			animation = this.addComponent(new Sprite<TypeAnimation>(subtextures[0]));

			// Set animations
			//---------------------------------------------------------------------------------
			// Walk
			animation.addAnimation(TypeAnimation.Idle, new SpriteAnimation(new List<Subtexture>()
			{
				subtextures[0],
			}));

			// Dead
			animation.addAnimation(TypeAnimation.Death, new SpriteAnimation(new List<Subtexture>()
			{
				subtextures[0]
			}));

			this.Animation = TypeAnimation.Idle;
		}

		public override void update()
		{
			base.update();

			if (!Alive)
			{
				deathCounter += Time.deltaTime;
				if (deathCounter > deathLimit)
					this.destroy();
			}
		}

		public override void Kill()
		{
			this.Animation = TypeAnimation.Death;
			this.Alive = false;
			SoundManager.PlaySound(Content.Sound.mine);
		}
	}
}
