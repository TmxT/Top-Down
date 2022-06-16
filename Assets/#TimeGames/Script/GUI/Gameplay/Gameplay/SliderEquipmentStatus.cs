using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

namespace TimeGames
{
    public class SliderEquipmentStatus : MonoBehaviour
    {
        public Slider slider;

        [Space]
        public TextMeshProUGUI textValue;

        public void Setup(int _strength, int _maxStrength)
        {
            StopAllCoroutines();
            StartCoroutine(SliderText(_strength, _maxStrength));
        }

        private IEnumerator SliderText(int _strength, int _maxStrength)
        {
            int strength = 0;
            slider.value = 0;

            while (slider.value < _strength / _maxStrength)
            {
                slider.value += Time.deltaTime;
                strength += (int)(Time.deltaTime * (_strength / _maxStrength));

                textValue.text = string.Format($"{strength} / {_maxStrength}");
                yield return null;
            }
        }
    }
}