using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TimeGames.Misc
{
    public class SfxTrigger : MonoBehaviour
    {
        public EnumSfx sfx;

        [Header("Reference")]
        private SfxManager sfxManager;

        private void Start()
        {
            sfxManager = SfxManager.Instance;
            Button button = GetComponent<Button>();

            if(button)
                button.onClick.AddListener(OnClick);
        }

        public void OnClick()
        {
            sfxManager.Play(sfx);
        }
    }
}