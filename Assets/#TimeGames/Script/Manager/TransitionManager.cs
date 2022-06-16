using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

using TimeGames.Misc;
using TMPro;

namespace TimeGames
{
    public class TransitionManager : Singleton<TransitionManager>
    {
        public enum EnumTransition
        {
            In,
            Out
        }

        public Animator animator;

        [Space]
        public TextMeshProUGUI textDestination;

        public void Transition(string _destination)
        {
            StopAllCoroutines();
            StartCoroutine(CoroutineTransition(_destination, EnumTransition.In));
        }

        private IEnumerator CoroutineTransition(string _destination, EnumTransition _transition)
        {
            animator.gameObject.SetActive(true);

            textDestination.text = Regex.Replace(_destination, "A-Z", " ");

            animator.Play(_transition.ToString());

            if(_transition == EnumTransition.In)
            {
                yield return new WaitForSeconds(animator.runtimeAnimatorController.animationClips.Length * .2f);
                yield return StartCoroutine(CoroutineTransition(_destination, EnumTransition.Out));

                animator.gameObject.SetActive(false);
            }
        }
    }
}