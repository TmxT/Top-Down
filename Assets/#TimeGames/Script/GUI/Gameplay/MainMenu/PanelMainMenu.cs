using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TimeGames.Event;
using TimeGames.Misc;

namespace TimeGames
{
    public class PanelMainMenu : MonoBehaviour, IEventKeyboard
    {
        public ButtonBase[] listBtnMenu;

        [Space]
        public GameObject objPanelMenu;
        public GameObject objPanelMainMenu;
        public GameObject objPanelGameplay;

        private event Action<ButtonBase> onButtonSelected;

        private int selectedBtn;

        [Header("Reference")]
        private PanelSettings panelSettings;

        private void Start()
        {
            panelSettings = GetComponent<PanelSettings>();

            Initialize();
        }

        private void Initialize()
        {
            for (int i = 0; i < listBtnMenu.Length; i++)
            {
                listBtnMenu[i].SetId(i);
                onButtonSelected += listBtnMenu[i].OnButtonSelected;
            }
        }

        public void Open()
        {
            objPanelMenu.SetActive(true);

            ChangeButton(0);
        }

        public void Close()
        {
            objPanelMenu.SetActive(false);
        }

        public void BtnNewGame()
        {
            GameManager.Instance.NewGame();

            objPanelMainMenu.SetActive(false);
            objPanelGameplay.SetActive(true);
            Close();
        }

        public void BtnLoad()
        {
            GameManager.Instance.LoadGame();

            objPanelMainMenu.SetActive(false);
            objPanelGameplay.SetActive(true);
            Close();
        }

        public void BtnSettings()
        {
            panelSettings.Open();
            Close();
        }

        public void BtnQuit()
        {
            Application.Quit();
        }

        private void ChangeButton(int _dir)
        {
            ButtonBase btn;

            selectedBtn += _dir;

            if (selectedBtn > listBtnMenu.Length - 1)
                selectedBtn = 0;
            else if(selectedBtn < 0)
                selectedBtn = listBtnMenu.Length - 1;

            btn = listBtnMenu[selectedBtn];
            btn.PointerEnter();

            onButtonSelected?.Invoke(btn);
        }

        public void OnKeyboard(EnumKeyboardAction _keyboardAction)
        {
            if(EventCursor.Instance.currentCursorPosition != EnumCursorPosition.MainMenu)
                return;

            if (_keyboardAction == EnumKeyboardAction.Up)
                ChangeButton(-1);
            else if (_keyboardAction == EnumKeyboardAction.Down)
                ChangeButton(1);
            else if(_keyboardAction == EnumKeyboardAction.Enter)
                listBtnMenu[selectedBtn].PointerClick();
        }

        private void OnEnable()
        {
            EventKeyboard.Instance.AddListener(OnKeyboard);
        }

        private void OnDisable()
        {
            if (!this.gameObject.scene.isLoaded) return;

            EventKeyboard.Instance?.RemoveListener(OnKeyboard);
        }
    }
}