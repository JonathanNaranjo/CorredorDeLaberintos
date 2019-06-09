using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entities.Base
{
	public abstract class CharacterBase : Entity
	{
		public bool Alive;

		public CharacterBase(String name) : base(name)
		{
			this.Alive = true;
		}
		virtual public void Kill() { }
	}
}
