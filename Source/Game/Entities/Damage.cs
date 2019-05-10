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
using Game.Entities.Base;

namespace Game.Entities
{
	class Damage : EnvironmentBase
	{
		public Damage(Vector2 position, int width, int heigth) : base(EntityType.Damage.ToString())
		{
			this.position = position;
			addComponent(new DamageBehavior());
			var boxCollider = addComponent(new BoxCollider(width, heigth));
			boxCollider.setLocalOffset(new Vector2(width / 2, heigth / 2));
		}
	}
}
