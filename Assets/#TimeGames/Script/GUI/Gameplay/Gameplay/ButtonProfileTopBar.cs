using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TimeGames.Misc;

namespace TimeGames
{
    public class ButtonProfileTopBar : ButtonBase
    {
        public EnumSortType sortType;

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
            panelProfile.BtnSortBar(sortType);
        }
    }
}