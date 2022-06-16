using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TimeGames.Event;
using TMPro;

namespace TimeGames
{
    public class PanelHpMp : MonoBehaviour, IEventHealth
    {
        public Slider sliderHealth;
        public Slider sliderMagic;

        [Space]
        public TextMeshProUGUI textHealth;
        public TextMeshProUGUI textMagic;

        private IEnumerator coroutinePlaySliderHealth;
        private IEnumerator coroutinePlaySliderMagic;

        [Header("Reference")]
        private PlayerHealth playerHealth;

        private void Start()
        {
            playerHealth = PlayerHealth.Instance;
        }

        public void Refresh()
        {
            RefreshHealth();
            RefreshMagic();
        }

        private void RefreshHealth()
        {
            if(coroutinePlaySliderHealth != null)
                StopCoroutine(coroutinePlaySliderHealth);

            sliderHealth.maxValue = playerHealth.MaxHealth;
            sliderHealth.value = playerHealth.Health;

            coroutinePlaySliderHealth = CoroutinePlaySlider(sliderHealth, textHealth, playerHealth.Health);
            StartCoroutine(coroutinePlaySliderHealth);
        }

        private void RefreshMagic()
        {
            if(coroutinePlaySliderMagic != null)
                StopCoroutine(coroutinePlaySliderMagic);

            sliderMagic.maxValue = playerHealth.MaxMagic;
            sliderMagic.value = playerHealth.Magic;

            coroutinePlaySliderMagic = CoroutinePlaySlider(sliderMagic, textMagic, playerHealth.Magic);
            StartCoroutine(coroutinePlaySliderMagic);
        }

        private IEnumerator CoroutinePlaySlider(Slider _slider, TextMeshProUGUI _text, float _targetValue, float _speed = 20f, int _fixedPointText = 0)
        {
            float sliderValue = _slider.value;
            int dir = sliderValue < _targetValue ? 1 : -1;

            while (true)
            {
                _slider.value = sliderValue;

                if (_text != null)
                    _text.text = sliderValue.ToString("F" + _fixedPointText) + "/" + _slider.maxValue;

                sliderValue += Time.deltaTime * _speed * dir;

                yield return null;

                if (dir == 1 && sliderValue > _targetValue)
                    break;
                else if (dir == -1 && sliderValue < _targetValue)
                    break;
            }

            _slider.value = _targetValue;

            if (_text != null)
                _text.text = _targetValue.ToString() + "/" + _slider.maxValue;
        }

        public void OnEventHealth(EnumHealthAction _healthAction)
        {
            if(_healthAction == EnumHealthAction.Healed || _healthAction == EnumHealthAction.Damaged)
                RefreshHealth();
            else if(_healthAction == EnumHealthAction.MagicIncreased || _healthAction == EnumHealthAction.MagicUsed)
                RefreshMagic();
        }
    }
}