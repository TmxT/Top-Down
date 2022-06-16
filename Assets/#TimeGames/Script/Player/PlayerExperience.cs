using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TimeGames.Event;
using TimeGames.Misc;

namespace TimeGames
{
    public class PlayerExperience : Singleton<PlayerExperience>
    {
        private int initialExp = 100;
        public int exp { get; private set; }
        public int maxExp
        {
            get
            {
                if(!playerManager)
                    playerManager = PlayerManager.Instance;

                int level = playerManager.level;

                return (level * initialExp) + (10 * level);
            }
        }

        [Header("Reference")]
        private PlayerManager playerManager;

        private void Start()
        {
            playerManager = PlayerManager.Instance;
        }

        public void AddExp(int _value)
        {
            exp += _value;

            EventExperience.Instance.Invoke();
        }
    }
}