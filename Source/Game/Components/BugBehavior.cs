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

namespace Game.Components
{
	public class BugBehavior : Component, IUpdatable, ITriggerListener
	{
		private Bug bugEntity;
		private float moveSpeed = 50;
		private float gravity = 1000;
		TiledMapMover mover;
		BoxCollider boxCollider;
		TiledMapMover.CollisionState collisionState = new TiledMapMover.CollisionState();
		Vector2 velocity;
		Vector2 moveDir;

		public override void onAddedToEntity()
		{
			this.bugEntity = (Bug)entity;
			this.boxCollider = entity.getComponent<BoxCollider>();
			this.mover = entity.getComponent<TiledMapMover>();
			moveDir = new Vector2(-1, 0);

		}

		public void update()
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



		#region ITriggerListener implementation

		void ITriggerListener.onTriggerEnter(Collider other, Collider self)
		{
			Debug.log("triggerEnter: {0}", other.entity.name);

			var playerEntity = other.entity as Player;
			if (playerEntity != null)
			{
				if (entity.position.Y > playerEntity.position.Y)
					entity.destroy();
				
			}

		}
		/*
		bool checkCollideTop(Collider other, Collider self)
		{
			double x = other.absolutePosition.X;
			double x2 = other.absolutePosition.X + other.
			double y;

			if (Position.Y < spr.Position.Y)
			{
				//Check for collisions on one side of the sprite
				y = spr.Position.Y;
				if (!_hit && LineCheckH(y, x, x2))
				{
					spr._hit = true;
					HitObjectFloor(spr);
					spr.HitObjectCeiling(this);
				}
			}
			else if ((Position.Y + Dimensions.Height) > (spr.Position.Y + spr.Dimensions.Height))
			{
				//Check for collisions on the other side
				y = spr.Position.Y + spr.Dimensions.Height;
				if (!_hit && LineCheckH(y, x, x2))
				{
					return true;
				}
			}
		}
		*/


		void ITriggerListener.onTriggerExit(Collider other, Collider self)
		{
			Debug.log("triggerExit: {0}", other.entity.name);
		}

		#endregion
	}
}
