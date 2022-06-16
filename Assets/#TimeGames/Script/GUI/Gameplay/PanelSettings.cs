using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

using TimeGames.Event;
using TimeGames.Misc;

namespace TimeGames
{
    public class PanelSettings : MonoBehaviour, IEventKeyboard
    {
        public GameObject objPanel;

        public GameObject objSelectedLangIndo;
        public GameObject objSelectedLangUsEng;

        [Space]
        public Toggle toggleBgm;
        public Toggle toggleSfx;

        [Space]
        public Slider sliderBgm;
        public Slider sliderSfx;

        [Space]
        public Button btnLangIndo;
        public Button btnLangUsEng;

        [Space]
        public ButtonBase btnApply;

        private float lastBgmValue, lastSfxValue;

        private bool lastBgmMute, lastSfxMute;
        private bool lastLanguage;

        [Header("Reference")]
        private AudioManager audioManager;

        protected virtual void Start()
        {
            audioManager = AudioManager.Instance;
        }

        public virtual void Open()
        {
            objPanel.SetActive(true);

            btnApply.PointerEnter();

            RefreshPanel();
        }

        public virtual void Close()
        {
            RevertData();

            objPanel.SetActive(false);
        }

        /// <summary>
        /// Menyimpan data Settings baru.
        /// </summary>
        public virtual void BtnApply()
        {
            //Untuk pergantian bahasa
            //Buka transisi
            //Update bahasa
            //Tutup transisi

            AppliedData();
            Close();
        }

        public void BtnLanguage() => ChangeLanguage(objSelectedLangIndo.activeSelf);

        public void OnToggleBgm() => SetBgmMute(!toggleBgm.isOn);

        public void OnToggleSfx() => SetSfxMute(!toggleSfx.isOn);

        /// <summary>
        /// Mengganti Bahasa dari game.
        /// </summary>
        /// <param name="_isLangIndo"></param>
        private void ChangeLanguage(bool _isLangIndo)
        {
            btnLangIndo.interactable = _isLangIndo;
            btnLangUsEng.interactable = !_isLangIndo;

            objSelectedLangIndo.SetActive(!_isLangIndo);
            objSelectedLangUsEng.SetActive(_isLangIndo);
        }

        public void SetBgmVolume(float _value)
        {
            audioManager.AudioBgm = _value;
            SetBgmMute(_value == 0);
        }

        public void SetSfxVolume(float _value)
        {
            audioManager.AudioSfx = _value;
            SetSfxMute(_value == 0);
        }

        protected void SetBgmMute(bool _isMute) => audioManager.MuteBgm = _isMute;

        protected void SetSfxMute(bool _isMute) => audioManager.MuteSfx = _isMute;

        protected virtual void AppliedData()
        {
            audioManager.Save();
            GameManager.Instance.Language = objSelectedLangIndo.activeSelf ? EnumLanguage.Bahasa : EnumLanguage.English;

            RefreshPanel();
        }

        /// <summary>
        /// Mengembalikan data Settings seperti sebelum tombol Settings ditekan.
        /// </summary>
        protected virtual void RevertData()
        {
            if (!audioManager)
                audioManager = AudioManager.Instance;

            SetBgmVolume(lastBgmValue);
            SetSfxVolume(lastSfxValue);

            SetBgmMute(lastBgmMute);
            SetSfxMute(lastSfxMute);

            ChangeLanguage(lastLanguage);
        }

        protected virtual void RefreshPanel()
        {
            lastBgmValue = audioManager.AudioBgm;
            lastSfxValue = audioManager.AudioSfx;

            lastBgmMute = audioManager.MuteBgm;
            lastSfxMute = audioManager.MuteSfx;

            lastLanguage = GameManager.Instance.Language == EnumLanguage.Bahasa;

            sliderBgm.value = lastBgmValue;
            sliderSfx.value = lastSfxValue;

            toggleBgm.isOn = lastBgmMute;
            toggleSfx.isOn = lastSfxMute;

            ChangeLanguage(lastLanguage);
        }

        public virtual void OnKeyboard(EnumKeyboardAction _keyboardAction)
        {
            if (_keyboardAction == EnumKeyboardAction.Enter)
                BtnApply();
            else if(_keyboardAction == EnumKeyboardAction.Escape)
                Close();
        }

        protected virtual void OnEnable()
        {
            EventKeyboard.Instance.AddListener(OnKeyboard);
        }

        protected virtual void OnDisable()
        {
            if (!this.gameObject.scene.isLoaded) return;

            EventKeyboard.Instance?.RemoveListener(OnKeyboard);
        }
    }
}