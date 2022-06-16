using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TimeGames.Event;
using TimeGames.Misc;

namespace TimeGames
{
    public class PlayerHealth : Singleton<PlayerHealth>, IEventGame
    {
        private int health;
        private int maxHealth = 100;

        private int magic;
        private int maxMagic = 100;

        public int Health { get { return health; } }
        public int MaxHealth { get { return maxHealth; } }
        public int Magic { get { return magic; } }
        public int MaxMagic { get { return maxMagic; } }

        private void NewGame()
        {
            health = maxHealth;
            magic = maxMagic;
        }

        public void Healed(int _health)
        {
            health += _health;

            if (health > maxHealth)
                health = maxHealth;

            EventHealth.Instance.Invoke(EnumHealthAction.Healed);
        }

        public void Damaged(int _health)
        {
            health -= _health;

            if (health < 0)
                health = 0;

            EventHealth.Instance.Invoke(EnumHealthAction.Damaged);
        }

        public void IncreaseMagic(int _magic)
        {
            magic += _magic;

            if (magic > maxMagic)
                magic = maxMagic;

            EventHealth.Instance.Invoke(EnumHealthAction.MagicIncreased);
        }

        public void UseMagic(int _magic)
        {
            magic -= _magic;

            if (magic < 0)
                magic = 0;

            EventHealth.Instance.Invoke(EnumHealthAction.MagicUsed);
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