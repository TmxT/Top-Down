using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

namespace TimeGames.Misc
{
    public class Typewriter : PanelBase
    {
        public event Action onNext;

        protected bool skip { get; private set; }

        protected IEnumerator CoroutineWrite(string _text, TextMeshProUGUI _tmp, float _delay = .1f)
        {
            float delay;
            skip = false;

            for (int i = 0; i <= _text.Length; i++)
            {
                _tmp.text = _text.Substring(0, i);

                delay = _delay;
                while (delay > 0)
                {
                    delay -= Time.deltaTime;
                    yield return null;
                }

                if (skip)
                    break;
            }

            _tmp.text = _text;

            OnWriteEnd();
        }

        protected void SkipWrite()
        {
            if(skip)
                OnNext();
            else
                skip = true;
        }

        private void OnNext()
        {
            onNext?.Invoke();
            onNext = null;
        }

        protected virtual void OnWriteEnd()
        {
            SkipWrite();
        }
    }
}