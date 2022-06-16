using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

namespace TimeGames
{
    public class PanelPlayerStatus : MonoBehaviour
    {
        public EnumStat statName;

        [Space]
        public TextMeshProUGUI textStatusName;
        public TextMeshProUGUI textStatusValue;
        public TextMeshProUGUI textStatusUpgraded;
        public TextMeshProUGUI textUpStatus;

        public int upgrade { get; private set; }

        [Header("Reference")]
        private PlayerStatus playerStatus;

        private void Start()
        {
            playerStatus = PlayerStatus.Instance;
        }

        public void Initialize()
        {
            textStatusName.text = string.Format($"{statName.ToString().ToUpper()}   : ");

            Refresh();
        }

        public void Refresh()
        {
            if (!playerStatus)
                playerStatus = PlayerStatus.Instance;

            textStatusValue.text = playerStatus.GetStat(statName).stat.ToString();
            textStatusUpgraded.text = string.Format($"+{upgrade}");
            textUpStatus.text = string.Format($"+{playerStatus.GetStat(statName).UpgradePoint(playerStatus.GetStat(statName).level + upgrade)}");
        }

        public void BtnUpgrade()
        {
            upgrade++;

            Refresh();
        }
    }
}