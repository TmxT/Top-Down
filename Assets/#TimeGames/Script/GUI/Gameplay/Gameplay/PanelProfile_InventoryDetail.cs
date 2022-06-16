using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TimeGames.Event;
using TMPro;

namespace TimeGames
{
    public class PanelProfile_InventoryDetail : MonoBehaviour, IEventProfileComponent
    {
        public GameObject objPanel;
        public GameObject objTextPotionResistance;

        [Space]
        public Image imgIcon;

        [Space]
        public TextMeshProUGUI textName;
        public TextMeshProUGUI textQty;
        public TextMeshProUGUI textDesc;
        [Space]
        public TextMeshProUGUI textAtk;
        public TextMeshProUGUI textDef;
        public TextMeshProUGUI textAgi;
        public TextMeshProUGUI textVit;
        public TextMeshProUGUI textInt;
        public TextMeshProUGUI textDex;
        public TextMeshProUGUI textLuk;
        public TextMeshProUGUI textHp;
        public TextMeshProUGUI textMp;
        public TextMeshProUGUI textHunger;

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

        public void Refresh()
        {

        }

        public void OnEventGame(string _panelName)
        {
            if (_panelName != objPanel.name)
                Close();
        }
    }
}