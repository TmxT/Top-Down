using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TimeGames.Event;
using TMPro;

namespace TimeGames
{
    public class PanelLevelExp : MonoBehaviour, IEventExperience, IEventPlayer
    {
        public Slider sliderExp;

        [Space]
        public TextMeshProUGUI textLevel;

        private IEnumerator coroutinePlaySlider;

        [Header("Reference")]
        private PlayerExperience playerExperience;
        private PlayerManager playerManager;

        private void Start()
        {
            playerExperience = PlayerExperience.Instance;
            playerManager = PlayerManager.Instance;

            RefreshExp();
            RefreshLevel();
        }

        private void RefreshExp()
        {
            if(coroutinePlaySlider != null)
                StopCoroutine(coroutinePlaySlider);

            coroutinePlaySlider = CoroutinePlaySlider(sliderExp, playerExperience.exp);
            StartCoroutine(coroutinePlaySlider);
        }

        private void RefreshLevel()
        {
            textLevel.text = string.Format($"~{playerManager.level}~");

            sliderExp.maxValue = playerExperience.maxExp;
        }

        private IEnumerator CoroutinePlaySlider(Slider _slider, float _targetValue, float _speed = 20f, int _fixedPointText = 0)
        {
            float sliderValue = _slider.value;
            int dir = sliderValue < _targetValue ? 1 : -1;

            while (true)
            {
                _slider.value = sliderValue;

                sliderValue += Time.deltaTime * _speed * dir;

                yield return null;

                if (dir == 1 && sliderValue > _targetValue)
                    break;
                else if (dir == -1 && sliderValue < _targetValue)
                    break;
            }

            _slider.value = _targetValue;
        }

        public void OnEventExperience()
        {
            RefreshExp();
        }

        public void OnEventPlayer(EnumPlayerAction _playerAction)
        {
            if(_playerAction == EnumPlayerAction.Level)
                RefreshLevel();
        }

        private void OnEnable()
        {
            EventExperience.Instance.AddListener(OnEventExperience);
            EventPlayer.Instance.AddListener(OnEventPlayer);
        }

        private void OnDisable()
        {
            if (!this.gameObject.scene.isLoaded) return;

            EventExperience.Instance?.RemoveListener(OnEventExperience);
            EventPlayer.Instance?.RemoveListener(OnEventPlayer);
        }
    }
}