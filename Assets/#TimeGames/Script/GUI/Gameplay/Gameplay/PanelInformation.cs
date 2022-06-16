using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TimeGames.Misc;
using TMPro;

namespace TimeGames
{
    public class PanelInformation : Typewriter
    {
        public GameObject objPanel;

        [Space]
        public TextMeshProUGUI textTitle;
        public TextMeshProUGUI textDesc;

        [Space]
        public Animator animator;

        public void Open(string _title, string _desc)
        {
            objPanel.SetActive(true);

            StopAllCoroutines();
            StartCoroutine(Coroutine());

            IEnumerator Coroutine()
            {
                yield return StartCoroutine(CoroutinePanel(animator, EnumAnimPanel.Show));
                Setup(_title, _desc);
            }
        }

        public void Close()
        {
            StopAllCoroutines();
            StartCoroutine(Coroutine());

            IEnumerator Coroutine()
            {
                yield return StartCoroutine(CoroutinePanel(animator, EnumAnimPanel.Hide));
                objPanel.SetActive(false);
            }
        }

        private void Setup(string _title, string _desc)
        {
            textTitle.text = _title;

            StartCoroutine(CoroutineWrite(_desc, textDesc));
        }

        public void BtnNext()
        {
            SkipWrite();
        }
    }
}