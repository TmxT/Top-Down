using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TimeGames.Event;

namespace TimeGames
{
    public class PanelProfile_Equipment : MonoBehaviour, IEventProfileComponent
    {
        public GameObject objPanel;

        [Space]
        public Image imgWeapon;
        public Image imgHelmet;
        public Image imgArmor;
        public Image imgBoots;
        public Image imgGloves;

        [Header("Reference")]
        private PlayerEquipment playerEquipment;

        private void Start()
        {
            playerEquipment = PlayerEquipment.Instance;

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

            Setup();
        }

        public void Close()
        {
            objPanel.SetActive(false);
        }

        private void Setup()
        {
            imgWeapon.sprite = playerEquipment.weapon.icon;
            imgHelmet.sprite = playerEquipment.helmet.icon;
            imgArmor.sprite = playerEquipment.armor.icon;
            imgBoots.sprite = playerEquipment.boots.icon;
            imgGloves.sprite = playerEquipment.gloves.icon;
        }

        public void OnEventGame(string _panelName)
        {
            if (_panelName != objPanel.name)
                Close();
        }
    }
}