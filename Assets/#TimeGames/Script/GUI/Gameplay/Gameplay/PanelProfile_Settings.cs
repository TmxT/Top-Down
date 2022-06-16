using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TimeGames.Event;

namespace TimeGames
{
    public class PanelProfile_Settings : PanelSettings, IEventProfileComponent
    {
        protected override void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            EventProfileComponent.Instance.AddListener(OnEventGame);
        }

        public override void Open()
        {
            base.Open();

            EventProfileComponent.Instance.Invoke(objPanel.name);
        }

        public void OnEventGame(string _panelName)
        {
            if (_panelName != objPanel.name)
                Close();
        }
    }
}