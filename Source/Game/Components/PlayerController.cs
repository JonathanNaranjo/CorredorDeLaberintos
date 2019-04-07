using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Tiled;
using Game.Entities;

namespace Game.Components
{
    public class PlayerController : Component, IUpdatable
    {
        private Player playerEntity;
        public float moveSpeed = 150;
        public float gravity = 1000;
        public float jumpHeight = 16 * 5;
        PlayerAnimations playerAnimation;
        TiledMapMover mover;
        BoxCollider boxCollider;
        TiledMapMover.CollisionState collisionState = new TiledMapMover.CollisionState();
        Vector2 velocity;

        VirtualButton jumpInput;
        VirtualButton leftInput;
        VirtualButton rightInput;
        VirtualButton downInput;
        VirtualIntegerAxis xAxisInput;

        private int _slideSpeed;
        public bool Sliding;
        private bool _slideUp;

        /// <summary>
        /// Init
        /// </summary>
        public override void onAddedToEntity()
        {
            this.playerEntity = (Player)this.entity;
            this.boxCollider = entity.getComponent<BoxCollider>();
            this.mover = entity.getComponent<TiledMapMover>();
            this.playerAnimation = entity.getComponent<PlayerAnimations>();

            _slideUp = true;
            Sliding = false;
            setupInput();
        }

        public override void onRemovedFromEntity()
        {
            // deregister virtual input
            jumpInput.deregister();
            downInput.deregister();
            leftInput.deregister();
            rightInput.deregister();
            xAxisInput.deregister();
        }


        void setupInput()
        {
            // setup input for jumping. we will allow z on the keyboard or a on the gamepad
            jumpInput = new VirtualButton();
            jumpInput.nodes.Add(new Nez.VirtualButton.KeyboardKey(Keys.Z));
            jumpInput.nodes.Add(new Nez.VirtualButton.GamePadButton(0, Buttons.A));

            downInput = new VirtualButton();
            downInput.nodes.Add(new Nez.VirtualButton.KeyboardKey(Keys.Down));
            downInput.nodes.Add(new Nez.VirtualButton.GamePadButton(0, Buttons.DPadDown));

            leftInput = new VirtualButton();
            leftInput.nodes.Add(new Nez.VirtualButton.KeyboardKey(Keys.Left));
            leftInput.nodes.Add(new Nez.VirtualButton.GamePadButton(0, Buttons.DPadLeft));

            rightInput = new VirtualButton();
            rightInput.nodes.Add(new Nez.VirtualButton.KeyboardKey(Keys.Right));
            rightInput.nodes.Add(new Nez.VirtualButton.GamePadButton(0, Buttons.DPadRight));

            // horizontal input from dpad, left stick or keyboard left/right
            xAxisInput = new VirtualIntegerAxis();
            xAxisInput.nodes.Add(new Nez.VirtualAxis.GamePadDpadLeftRight());
            xAxisInput.nodes.Add(new Nez.VirtualAxis.GamePadLeftStickX());
            xAxisInput.nodes.Add(new Nez.VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.Left, Keys.Right));
        }

        void IUpdatable.update()
        {
            // handle movement and animations
            var moveDir = new Vector2(xAxisInput.value, 0);
            var animation = TypeAnimation.Idle;

            if (moveDir.X < 0)
            {
                if (this.collisionState.below)
                    animation = TypeAnimation.Run;

                this.playerAnimation.FlipX = true;
                this.velocity.X = -moveSpeed;
            }
            else if (moveDir.X > 0)
            {
                if (this.collisionState.below)
                    animation = TypeAnimation.Run;

                this.playerAnimation.FlipX = false;
                this.velocity.X = moveSpeed;

                
            }
            else
            {
                this.velocity.X = 0;
                if (this.collisionState.below)
                    animation = TypeAnimation.Idle;
            }

            // Slide
            if (!Sliding && (!downInput.isDown) || (!leftInput.isDown && !rightInput.isDown))
                _slideUp = true;

            //if (!Sliding && this.collisionState.below && downInput.isDown)
            if (this.collisionState.below && downInput.isDown)
            {
                if (leftInput.isDown)
                {
                    this.playerAnimation.FlipX = true;
                    animation = TypeAnimation.Slide;
                    this.velocity.X = -Mathf.sqrt(2f * jumpHeight * gravity);
                    Sliding = true;
                    _slideUp = false;
                }

                if (rightInput.isDown)
                {
                    this.playerAnimation.FlipX = false;
                    animation = TypeAnimation.Slide;
                    this.velocity.X = Mathf.sqrt(2f * jumpHeight * gravity);
                    Sliding = true;
                    _slideUp = false;
                }
            }

            // Jump
            if (this.collisionState.below && jumpInput.isPressed)
            {
                animation = TypeAnimation.Jumping;
                this.velocity.Y = -Mathf.sqrt(2f * jumpHeight * gravity);
				playerEntity.PlayJump();
            }


            // Falling
            if (!this.collisionState.below && this.velocity.Y > 0)
                animation = TypeAnimation.Falling;


            // apply gravity
            this.velocity.Y += gravity * Time.deltaTime;


            // move
            this.mover.move(this.velocity * Time.deltaTime, this.boxCollider, this.collisionState);


			// Blow to the head
			if (this.collisionState.above)
				this.velocity.Y = 0;

			// On the floor
			if (this.collisionState.below)
                this.velocity.Y = 0;

            if (playerAnimation.Animation != animation)
            {
                playerAnimation.Animation = animation;
            }

        }

    }
}
