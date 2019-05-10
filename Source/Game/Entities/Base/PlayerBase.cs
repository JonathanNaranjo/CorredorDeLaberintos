using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;

namespace Game.Entities.Base
{
	public abstract class PlayerBase : CharacterBase
	{
		public PlayerBase(String name) : base(name)
		{
			this.tag = (int)TagType.Player;
		}

	}
}
