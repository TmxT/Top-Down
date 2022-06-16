using System.Collections;
using System.Collections.Generic;
using TimeGames.Event;
using UnityEngine;

namespace TimeGames
{
    public class PlayerMovement : CharacterMovement, IEventController
    {
        private float horizontalMove, verticalMove;

        [Header("Reference")]
        private PlayerFitness playerFitness;

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            if (isLocked)
                return;

            Controller();
            MoveCharacter();
        }

        protected virtual void Controller()
        {
            if (isLocked)
                return;

            horizontalMove = Input.GetAxisRaw("Horizontal");
            verticalMove = Input.GetAxisRaw("Vertical");

            if (horizontalMove != 0 || verticalMove != 0)
            {
                if (horizontalMove > 0)
                {
                    lastLookAt = EnumCharacterDirection.Right;
                    verticalMove = 0;
                }
                else if (horizontalMove < 0)
                {
                    lastLookAt = EnumCharacterDirection.Left;
                    verticalMove = 0;
                }
                else if (verticalMove < 0)
                {
                    lastLookAt = EnumCharacterDirection.Down;
                    horizontalMove = 0;
                }
                else if (verticalMove > 0)
                {
                    lastLookAt = EnumCharacterDirection.Up;
                    horizontalMove = 0;
                }

                PlayAnimation(lastLookAt, false);
            }
            else
                PlayAnimation(lastLookAt, true);

            if (Input.GetKey(KeyCode.LeftShift) && !playerFitness.IsTired())
                Sprint();
            else
                sprintSpeed = 1;
        }

        /// <summary>
        /// Menggerakkan Karakter
        /// </summary>
        protected override void MoveCharacter() => rb.velocity = new Vector2(horizontalMove * movementSpeed * sprintSpeed, verticalMove * movementSpeed * sprintSpeed);

        public void OnEventController(EnumEventController _eventController, bool _isLocked)
        {
            if (_eventController == EnumEventController.Character)
                isLocked = _isLocked;
            else
                isLocked = false;
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            EventController.Instance.AddListener(OnEventController);
        }

        protected override void OnDisable()
        {
            if (!this.gameObject.scene.isLoaded) return;

            EventController.Instance.RemoveListener(OnEventController);

            base.OnDisable();
        }
    }
}