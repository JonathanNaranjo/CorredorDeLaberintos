using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.Tiled;
using Nez.Textures;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Game.Components;
using Microsoft.Xna.Framework.Graphics;
using Game.Entities.Base;

namespace Game.Entities
{
	class Exit : EnvironmentBase
	{
		public Exit(Vector2 position, int width, int height) : base("Exit")
		{
			this.position = position;
			addComponent(new ExitBehavior());
			var boxCollider = addComponent(new BoxCollider(width, height));
		}

		public override void onAddedToScene()
		{
			var texture = scene.content.Load<Texture2D>(Content.Sprite.exit);
			addComponent(new Sprite(texture)).renderLayer = 1;
				
		}
	}
}
