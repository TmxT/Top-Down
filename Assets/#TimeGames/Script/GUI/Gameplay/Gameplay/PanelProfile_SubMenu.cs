using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TimeGames.Event;
using TMPro;

namespace TimeGames
{
    public class PanelProfile_SubMenu : MonoBehaviour, IEventProfileComponent
    {
        public GameObject objPanel;

        [Space]
        public TextMeshProUGUI textPlayTime;

        [Header("Reference")]
        private PanelProfile_Settings panelProfile_Settings;

        private void Start()
        {
            panelProfile_Settings = GetComponent<PanelProfile_Settings>();

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

        public void BtnSave()
        {

        }

        public void BtnLoad()
        {

        }

        public void BtnSettings()
        {
            panelProfile_Settings.Open();
        }

        public void BtnQuit()
        {
            Application.Quit();
        }

        private void Refresh()
        {
            textPlayTime.text = string.Format($"{PlayTImeManager.Instance.playTime_Hour} : {PlayTImeManager.Instance.playTime_Minute} : {PlayTImeManager.Instance.PlayTime_Second}");
        }

        public void OnEventGame(string _panelName)
        {
            if (_panelName != objPanel.name)
                Close();
        }
    }
}