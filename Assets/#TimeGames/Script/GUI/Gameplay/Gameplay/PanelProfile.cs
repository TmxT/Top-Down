using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeGames
{
    public class PanelProfile : PanelBase
    {
        public static PanelProfile Instance;

        public GameObject objPanel;

        [Space]
        public Animator animator;

        [Header("Reference")]
        private PanelProfile_Equipment panelProfile_Equipment;
        private PanelProfile_EquipmentStatus panelProfile_EquipmentStatus;
        private PanelProfile_PlayerStatus panelProfile_PlayerStatus;
        private PanelProfile_SubMenu panelProfile_SubMenu;
        private PanelProfile_Settings panelProfile_Settings;
        private PanelProfile_InventoryDetail panelProfile_InventoryDetail;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            panelProfile_Equipment = GetComponent<PanelProfile_Equipment>();
            panelProfile_EquipmentStatus = GetComponent<PanelProfile_EquipmentStatus>();
            panelProfile_PlayerStatus = GetComponent<PanelProfile_PlayerStatus>();
            panelProfile_SubMenu = GetComponent<PanelProfile_SubMenu>();
            panelProfile_Settings = GetComponent<PanelProfile_Settings>();
            panelProfile_InventoryDetail = GetComponent<PanelProfile_InventoryDetail>();
        }

        public void Open()
        {
            objPanel.SetActive(true);
        }

        public void Close()
        {
            StartCoroutine(Coroutine());

            IEnumerator Coroutine()
            {
                yield return StartCoroutine(CoroutinePanel(animator, EnumAnimPanel.Hide));
                objPanel.SetActive(false);
            }
        }

        public void BtnMiniProfile()
        {
            Open();
        }

        public void BtnLeftBar(EnumPanelProfileComponent _component)
        {
            switch (_component)
            {
                case EnumPanelProfileComponent.Equipment:
                    panelProfile_Equipment.Open();
                    break;

                case EnumPanelProfileComponent.EquipmentStatus:
                    panelProfile_EquipmentStatus.Open();
                    break;

                case EnumPanelProfileComponent.PlayerStatus:
                    panelProfile_PlayerStatus.Open();
                    break;

                case EnumPanelProfileComponent.SubMenu:
                    panelProfile_SubMenu.Open();
                    break;

                case EnumPanelProfileComponent.Settings:
                    panelProfile_Settings.Open();
                    break;

                case EnumPanelProfileComponent.InventoryDetail:
                    panelProfile_InventoryDetail.Open();
                    break;
            }
        }

        public void BtnSortBar(EnumSortType _sortType)
        {
            switch (_sortType)
            {
                case EnumSortType.All:
                    break;

                case EnumSortType.Equipment:
                    break;

                case EnumSortType.Potion:
                    break;

                case EnumSortType.Food:
                    break;
            }
        }
    }
}