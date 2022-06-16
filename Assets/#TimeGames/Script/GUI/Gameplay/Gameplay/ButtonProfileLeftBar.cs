using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TimeGames.Misc;

namespace TimeGames
{
    public class ButtonProfileLeftBar : ButtonBase
    {
        public EnumPanelProfileComponent component;

        [Header("Reference")]
        private PanelProfile panelProfile;

        protected override void Start()
        {
            panelProfile = PanelProfile.Instance;

            base.Start();

            Initialize();
        }

        protected override void Initialize()
        {
            base.Initialize();

            GetComponent<ButtonBase>().onClick.AddListener(OnClicked);
        }

        public void OnClicked()
        {
            panelProfile.BtnLeftBar(component);
        }
    }
}