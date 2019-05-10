using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;


namespace Game.Entities.Base
{
	public abstract class ItemBase : Entity
	{
		public ItemBase(String name) : base(name)
		{
			this.tag = (int)TagType.Item;
		}

		public virtual void Touch() { }
	}
}
