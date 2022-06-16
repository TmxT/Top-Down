using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TimeGames.Event;
using TMPro;

namespace TimeGames
{
    public class PanelCoin : MonoBehaviour, IEventPlayer
    {
        public TextMeshProUGUI textCoin;

        [Header("Reference")]
        private PlayerManager playerManager;

        private void Start()
        {
            playerManager = PlayerManager.Instance;
        }

        private void Refresh()
        {
            textCoin.text = playerManager.coin.ToString();
        }

        public void OnEventPlayer(EnumPlayerAction _playerAction)
        {
            if(_playerAction == EnumPlayerAction.Coin)
                Refresh();
        }

        private void OnEnable()
        {
            EventPlayer.Instance.AddListener(OnEventPlayer);
        }

        private void OnDisable()
        {
            if (!this.gameObject.scene.isLoaded) return;

            EventPlayer.Instance?.RemoveListener(OnEventPlayer);
        }
    }
}