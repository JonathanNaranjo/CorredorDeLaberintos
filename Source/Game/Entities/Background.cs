using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Nez.Sprites;
using Nez.Tiled;
using Nez.Textures;
using Microsoft.Xna.Framework.Graphics;
using Game.Components;
using Microsoft.Xna.Framework;

namespace Game.Entities
{
    class Background : Entity
    {
		ScrollingSprite _sprite;
		TextureBasic texture;
		Vector2 positionCamera;

		public Background() : base("Background")
		{
			// Position in screen center (important for y coordinate)
			transform.position = Vector2.Zero;
			
		}

		public override void onAddedToScene()
		{
			this.
			//positionCamera = new Vector2(scene.camera.bounds.top, scene.camera.bounds.left);
			texture = new TextureBasic(scene.content.Load<Texture2D>(Content.Sprite.splash));
			texture.renderLayer = 2;
			//texture.width = (int)scene.camera.bounds.width;
			//texture.height = (int)scene.camera.bounds.height;

			texture.width = Constants.SCREEN_WIDTH;
			texture.height = Constants.SCREEN_HEIGHT;
			addComponent(texture).renderLayer = 2;

			/*
			// Load background sprite (scrolling background with a specific speed)
			_sprite = new ScrollingSprite(scene.content.Load<Texture2D>(Content.Terrain.bg1))
			{
				scrollSpeedX = Constants.BackgroundSpeed
			};

			// Add sprite component with renderLayer to 2 (in this way, background renders are in the back of screen)
			addComponent(_sprite)
				.renderLayer = 2;
				*/

		}

		public override void update()
		{
			base.update();
			var cameraBounds = scene.camera.bounds;
			//this.transform.position = scene.findEntity("camera").position;
			//this.transform.position = Screen.center / 2;
			//positionCamera.X = scene.camera.bounds.top;
			//positionCamera.Y = scene.camera.bounds.left;
			//this.position = positionCamera;
			/*
			// If it is GameOver, stop background scrolling
			if ((scene as Level).State == LevelState.GameOver)
				_sprite.scrollSpeedX = 0;
				*/
		}
	}
}
