using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Game.Entities;
using Nez;
using Nez.Tiled;
using Game.Scenes;

namespace Game.Components
{
    /// <summary>
    /// Comportamiento de la entidad Bug1
    /// </summary>
	public class Bug1Behavior : Component, IUpdatable, ITriggerListener
	{
		private Bug1 bugEntity;
		private float moveSpeed = 50;
		private float gravity = 1000;
		TiledMapMover mover;
		BoxCollider boxCollider;
		TiledMapMover.CollisionState collisionState = new TiledMapMover.CollisionState();
		Vector2 velocity;
		Vector2 moveDir;

		public override void onAddedToEntity()
		{
			this.bugEntity = (Bug1)entity;
			this.boxCollider = entity.getComponent<BoxCollider>();
			this.mover = entity.getComponent<TiledMapMover>();
			moveDir = new Vector2(-1, 0);
		}

		public void update()
		{
			if (bugEntity.Alive)
			{
				if (collisionState.left)
					moveDir.X = 1;

				if (collisionState.right)
					moveDir.X = -1;

				if (moveDir.X < 0)
				{
					this.bugEntity.FlipX = true;
					this.velocity.X = -moveSpeed;
				}

				if (moveDir.X > 0)
				{
					this.bugEntity.FlipX = false;
					this.velocity.X = moveSpeed;
				}

				// apply gravity
				this.velocity.Y += gravity * Time.deltaTime;

				// move
				this.mover.move(this.velocity * Time.deltaTime, this.boxCollider, this.collisionState);
			}
		}



		#region ITriggerListener implementation

		void ITriggerListener.onTriggerEnter(Collider other, Collider self)
		{
			Debug.log("triggerEnter: {0}", other.entity.name);

			var playerEntity = other.entity as Player;
			if (bugEntity.Alive && playerEntity != null)
			{
				if (bugEntity.position.Y + bugEntity.Height > playerEntity.position.Y + playerEntity.Height)
				{
					playerEntity.Impulse();
					bugEntity.Kill();
				}
				else
				{
					if (playerEntity.getComponent<PlayerController>().Sliding)
						bugEntity.Kill();
					else
						playerEntity.Kill();
				}
			}

		}

		void ITriggerListener.onTriggerExit(Collider other, Collider self)
		{
			Debug.log("triggerExit: {0}", other.entity.name);
		}

		#endregion
	}
}
