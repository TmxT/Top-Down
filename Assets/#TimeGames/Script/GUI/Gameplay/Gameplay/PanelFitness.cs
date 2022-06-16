using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TimeGames
{
    public class PanelFitness : MonoBehaviour
    {
        public Image imgTired;
        public Image imgHungry;
        public Image imgSleepy;

        [Header("Reference")]
        private PlayerFitness playerFitness;

        private void Start()
        {
            playerFitness = PlayerFitness.Instance;
        }

        private void Update()
        {
            if(!playerFitness)
                return;

            RefreshTired();
            RefreshHungry();
            RefreshSleepy();
        }

        private void RefreshTired()
        {
            imgTired.fillAmount = playerFitness.Tired;
        }

        private void RefreshHungry()
        {
            imgHungry.fillAmount = playerFitness.Hungry;
        }

        private void RefreshSleepy()
        {
            imgSleepy.fillAmount = playerFitness.Sleepy;
        }
    }
}