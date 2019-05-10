using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;

namespace Game.Entities.Base
{
	public abstract class EnemyBase : CharacterBase
	{
		public EnemyBase(String name) : base(name)
		{
			this.tag = (int)TagType.Enemy;
		}

	}
}
