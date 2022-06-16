using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TimeGames
{
    public class PanelWorldTime : MonoBehaviour
    {
        public Image imgNightTime;
        public Image imgLightEffect;

        [Header("Reference")]
        private WorldTimeManager worldTimeManager;

        private void Start()
        {
            worldTimeManager = WorldTimeManager.Instance;
        }

        private void Update()
        {
            if(!worldTimeManager || worldTimeManager.isPaused)
                return;

            Refresh();
        }

        private void Refresh()
        {
            imgNightTime.fillClockwise = worldTimeManager.clockDir < 0;

            imgLightEffect.color = new Color32(0, 0, 0, (byte)(worldTimeManager.curTime * 5));
            imgNightTime.fillAmount = worldTimeManager.curTime / worldTimeManager.totalTimePerDay;
        }
    }
}