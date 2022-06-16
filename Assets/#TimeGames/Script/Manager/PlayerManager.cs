using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TimeGames.Event;
using TimeGames.Misc;

namespace TimeGames
{
    public class PlayerManager : Singleton<PlayerManager>, IEventGame
    {
        public int level { get; private set; }
        public int coin { get; private set; }

        public void AddLevel(int _value)
        {
            level = _value;

            EventPlayer.Instance.Invoke(EnumPlayerAction.Level);
        }

        public void AddCoin(int _value)
        {
            coin = _value;

            EventPlayer.Instance.Invoke(EnumPlayerAction.Coin);
        }

        private void NewGame()
        {
            coin = 38;
            level = 15;
        }

        public void OnEventGame(EnumGame _game)
        {
            if(_game == EnumGame.New)
                NewGame();
        }

        private void OnEnable()
        {
            EventGame.Instance.AddListener(OnEventGame);
        }

        private void OnDisable()
        {
            if (!this.gameObject.scene.isLoaded) return;

            EventGame.Instance?.RemoveListener(OnEventGame);
        }
    }
}