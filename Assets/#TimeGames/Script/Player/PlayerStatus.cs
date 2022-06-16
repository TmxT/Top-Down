using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TimeGames.Event;
using TimeGames.Misc;

namespace TimeGames
{
    public class PlayerStatus : Singleton<PlayerStatus>, IEventGame
    {
        private Status[] listStat;

        public int upgradePoint { get; private set; }

        public Status GetStat(EnumStat _stat) => listStat[(int)_stat];

        public void IncreaseLevel(EnumStat _stat, int _value)
        {
            listStat[(int)_stat].IncreaseLevel(_value);
        }

        public void AddUpgradePoint(int _value) => upgradePoint += _value;

        private void NewGame()
        {
            RandomizeStat();
        }

        private void RandomizeStat()
        {
            int length = typeof(EnumStat).GetEnumValues().Length;
            listStat = new Status[length];

            for (int i = 0; i < length; i++)
                listStat[i] = new Status((EnumStat)i);
        }

        public void OnEventGame(EnumGame _game)
        {
            if (_game == EnumGame.New)
                NewGame();
        }

        private void OnEnable()
        {
            EventGame.Instance.AddListener(OnEventGame);
        }

        private void OnDisable()
        {
            if (!this.gameObject.scene.isLoaded) return;

            EventGame.Instance.RemoveListener(OnEventGame);
        }
    }
}