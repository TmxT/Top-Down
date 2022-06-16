using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TimeGames.Event;

namespace TimeGames
{
    public class PanelProfile_EquipmentStatus : MonoBehaviour, IEventProfileComponent
    {
        public GameObject objPanel;

        [Space]
        public SliderEquipmentStatus helmet;
        public SliderEquipmentStatus armor;
        public SliderEquipmentStatus weapon;
        public SliderEquipmentStatus boots;
        public SliderEquipmentStatus gloves;

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
            helmet.Setup(playerEquipment.helmet.strength, playerEquipment.helmet.maxStrength);
            armor.Setup(playerEquipment.armor.strength, playerEquipment.armor.maxStrength);
            weapon.Setup(playerEquipment.weapon.strength, playerEquipment.weapon.maxStrength);
            boots.Setup(playerEquipment.boots.strength, playerEquipment.boots.maxStrength);
            gloves.Setup(playerEquipment.gloves.strength, playerEquipment.gloves.maxStrength);
        }

        public void OnEventGame(string _panelName)
        {
            if (_panelName != objPanel.name)
                Close();
        }
    }
}