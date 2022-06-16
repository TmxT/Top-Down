using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TimeGames.Event;
using TMPro;

namespace TimeGames
{
    public class PanelProfile_PlayerStatus : MonoBehaviour, IEventProfileComponent
    {
        public GameObject objPanel;

        [Space]
        public TextMeshProUGUI textTotalPoint;

        [Space]
        public PanelPlayerStatus[] listPlayerStatus;

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            EventProfileComponent.Instance.AddListener(OnEventGame);
        }

        public void Open()
        {
            objPanel.SetActive(true);
            EventProfileComponent.Instance.Invoke(objPanel.name);

            Refresh();
        }

        public void Close()
        {
            objPanel.SetActive(false);
        }

        public void BtnConfirm()
        {

        }

        private void Refresh()
        {
            textTotalPoint.text = string.Format($"+{PlayerStatus.Instance.upgradePoint}");

            foreach (PanelPlayerStatus _playerStatus in listPlayerStatus)
                _playerStatus.Initialize();
        }

        public void OnEventGame(string _panelName)
        {
            if (_panelName != objPanel.name)
                Close();
        }
    }
}