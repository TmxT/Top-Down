using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TimeGames.Attribute;

namespace TimeGames
{
    public class CharacterMovement : MonoBehaviour
    {
        protected enum EnumCharacterDirection
        {
            Up,
            Down,
            Left,
            Right
        }

        protected enum EnumAnimParam
        {
            Walk_Up,
            Walk_Down,
            Walk_Left,
            Walk_Right,

            Idle_Up,
            Idle_Down,
            Idle_Left,
            Idle_Right
        }

        [ReadOnly]
        private string currentAction;

        protected EnumCharacterDirection lastLookAt;

        public Rigidbody2D rb;

        [Space]
        public Animator animator;

        [Space]
        public AudioSource sfxStep;

        [Space]
        [Range(1f, 10f)]
        public float movementSpeed = 5f;
        [Range(1f, 5f)]
        public float targetSprintSpeed = 2.5f;
        [Range(1f, 10f)]
        public float delaySprintSpeed = 5f;
        protected float sprintSpeed = 1;

        protected bool isLocked;

        protected virtual void Start() { }

        protected virtual void FixedUpdate() { }

        protected virtual void MoveCharacter() { }

        /// <summary>
        /// Sprint dengan kecepatan dinamis yang naik secara bertahap.
        /// </summary>
        protected virtual void Sprint()
        {
            if (sprintSpeed < targetSprintSpeed)
                sprintSpeed += Time.deltaTime * delaySprintSpeed;
            else
                sprintSpeed = targetSprintSpeed;

            UpdateSfxStep();

            void UpdateSfxStep()
            {
                if (sprintSpeed > 1)
                    sfxStep.pitch = 2;
                else
                    sfxStep.pitch = 1;
            }
        }

        public bool IsSprint() => sprintSpeed > 1;

        protected void PlayAnimation(Vector2 _targetPos)
        {
            float distanceX = Mathf.Abs(Mathf.Abs(_targetPos.x) - Mathf.Abs(transform.position.x));
            float distanceY = Mathf.Abs(Mathf.Abs(_targetPos.y) - Mathf.Abs(transform.position.y));

            Vector3 direction = _targetPos - (Vector2)transform.position;

            float x = direction.x;
            float y = direction.y;

            if (distanceX > distanceY)
            {
                if (x > 0)
                    lastLookAt = EnumCharacterDirection.Right;
                else if (x < 0)
                    lastLookAt = EnumCharacterDirection.Left;
            }
            else
            {
                if (y > 0)
                    lastLookAt = EnumCharacterDirection.Up;
                else if (y < 0)
                    lastLookAt = EnumCharacterDirection.Down;
            }

            PlayAnimation(lastLookAt, false);
        }

        protected virtual void PlayAnimation(EnumCharacterDirection _direction, bool _idle)
        {
            string parameter = "";

            switch (_direction)
            {
                case EnumCharacterDirection.Up:
                    parameter = _idle ? EnumAnimParam.Idle_Up.ToString() : EnumAnimParam.Walk_Up.ToString();
                    break;

                case EnumCharacterDirection.Down:
                    parameter = _idle ? EnumAnimParam.Idle_Down.ToString() : EnumAnimParam.Walk_Down.ToString();
                    break;

                case EnumCharacterDirection.Right:
                    parameter = _idle ? EnumAnimParam.Idle_Right.ToString() : EnumAnimParam.Walk_Right.ToString();
                    break;

                case EnumCharacterDirection.Left:
                    parameter = _idle ? EnumAnimParam.Idle_Left.ToString() : EnumAnimParam.Walk_Left.ToString();
                    break;
            }

            if (currentAction == parameter)
                return;

            animator.Play(parameter);
            PlaySfxStep();

            currentAction = parameter;
        }

        protected void PlaySfxStep()
        {
            if (!sfxStep.isPlaying)
                sfxStep.Play();
            else
                sfxStep.Stop();
        }

        protected virtual void OnEnable() { }

        protected virtual void OnDisable() { }
    }
}