using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeGames
{
    public class Status
    {
        public EnumStat statName { get; private set; }

        private int initStat;
        public int stat { get; private set; }
        private int maxStat;
        public int level { get; private set; }
        private int maxLevel;
        public int upgradePoint { get; private set; }

        public Status(EnumStat _statName)
        {
            statName = _statName;
            initStat = Random.Range(10, 30);
            maxStat = 100;
            maxLevel = 10;

            level = Random.Range(1, 5);
            stat = initStat + (level * 7);
            upgradePoint = UpgradePoint(level);
        }

        public void IncreaseLevel(int _value)
        {
            if (level + _value > maxLevel)
                Debug.LogWarning("Level Player melebihi batas!");

            level += _value;

            stat = initStat + (level * 7);
            upgradePoint = UpgradePoint(level);

            if (stat > maxStat)
                stat = maxStat;
        }

        public bool Upgradeable() => level < maxLevel;

        public int UpgradePoint(int _level) => level * 2;
    }
}