using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeGames
{
    public class PanelBase : MonoBehaviour
    {
        public enum EnumAnimPanel
        {
            Hide,
            Show
        }

        protected IEnumerator CoroutinePanel(Animator _animator, EnumAnimPanel _parameter)
        {
            _animator.Play(_parameter.ToString());

            float delay = _animator.GetCurrentAnimatorClipInfo(0).Length;

            while (delay > 0)
            {
                delay -= Time.deltaTime;
                yield return null;
            }
        }
    }
}