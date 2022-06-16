using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeGames
{
    public class NpcMovement : CharacterMovement
    {
        /// <summary>
        /// Menggerakkan Karakter
        /// </summary>
        /// <param name="_targetPos"></param>
        /// <returns></returns>
        public IEnumerator MoveCharacter(Vector2 _targetPos)
        {
            PlayAnimation(_targetPos);

            while (Vector2.Distance(transform.position, _targetPos) > .5f)
            {
                transform.position = Vector2.MoveTowards(transform.position, _targetPos, movementSpeed * Time.deltaTime);
                yield return null;
            }

            PlayAnimation(lastLookAt, true);
        }
    }
}