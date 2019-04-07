using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Nez;
using Nez.Sprites;
using Nez.Tiled;
using Nez.Textures;
using Game.Components;

namespace Game.Entities
{
	class Bug : Entity
	{
		private Sprite<TypeAnimation> animation;
		private int sizeFrame = 32;
		private BoxCollider boxCollider;
		public Bug(Vector2 position) : base("Bug")
		{
			this.position = position;
			addComponent(new BugBehavior());
			boxCollider = addComponent<BoxCollider>();
			boxCollider.setHeight(21);
			boxCollider.setWidth(32);
		}

		public override void onAddedToScene()
		{
			this.position = new Vector2(this.position.X + sizeFrame / 2, this.position.Y);

			var texture = scene.content.Load<Texture2D>(Content.Sprite.bug1);
			var subtextures = Subtexture.subtexturesFromAtlas(texture, sizeFrame, 21);
			animation = this.addComponent(new Sprite<TypeAnimation>(subtextures[0]));

			// Set animations
			//---------------------------------------------------------------------------------
			// Walk
			animation.addAnimation(TypeAnimation.Walk, new SpriteAnimation(new List<Subtexture>()
			{
				subtextures[1],
				subtextures[2],
				subtextures[3]
			}));

			// Dead
			animation.addAnimation(TypeAnimation.Death, new SpriteAnimation(new List<Subtexture>()
			{
				subtextures[0]
			}));


			this.Animation = TypeAnimation.Walk;
		}

		public TypeAnimation Animation
		{
			get => this.animation.currentAnimation;
			set => this.animation.play(value);
		}
		public bool FlipX { get => this.animation.flipX; set => this.animation.flipX = value; }
	}
}
