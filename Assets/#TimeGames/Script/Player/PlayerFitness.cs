using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TimeGames.Event;
using TimeGames.Misc;

namespace TimeGames
{
    public class PlayerFitness : Singleton<PlayerFitness>, IEventWorldTime, IEventGame
    {
        private float tired;
        private float hungry;
        private float sleepy;

        private float minHungry;
        private float minSleepy;

        private float maxTired = 3;
        private float maxHungry = 300;
        private float maxSleepy = 100;

        private float tiredTime = 1;

        private bool isTired;
        private bool isSleepy;
        private bool isPaused;

        public float Tired { get { return tired / maxTired; } }
        public float Hungry { get { return hungry / maxHungry; } }
        public float Sleepy { get { return sleepy / maxSleepy; } }

        [Header("Reference")]
        private CharacterMovement characterMovement;

        private void Start()
        {
            characterMovement = GetComponent<CharacterMovement>();

            Initialize();
        }

        private void Initialize()
        {
            minHungry = maxHungry * .25f;
            minSleepy = maxSleepy * .25f;
        }

        private void Update()
        {
            if(isPaused || !characterMovement)
                return;

            RefreshTired();
            RefreshHungry();
            RefreshSleepy();
        }

        private void NewGame()
        {
            tired = maxTired;
            hungry = maxHungry;
            sleepy = maxSleepy;
        }

        public bool IsTired() => isTired;

        private void RefreshTired()
        {
            if (characterMovement.IsSprint() && !isTired)
            {
                if (tired > 0)
                    tired -= Time.deltaTime;
                else
                {
                    tiredTime = .5f;
                    isTired = true;
                }
            }
            else if (hungry > minHungry && sleepy > minSleepy && tired < maxTired)
                tired += Time.deltaTime * tiredTime;

            if (isTired)
            {
                if (tired >= maxTired)
                {
                    tiredTime = 1;
                    isTired = false;
                }
            }
        }

        private void RefreshHungry()
        {
            if (hungry > 0)
            {
                if (sleepy > minSleepy)
                    hungry -= Time.deltaTime;
                else
                    hungry -= Time.deltaTime * 2;
            }
        }

        private void RefreshSleepy()
        {
            if (isSleepy)
                sleepy -= Time.deltaTime;
        }

        public void OnEventWorldTime(EnumWorldTime _worldTime)
        {
            if (_worldTime == EnumWorldTime.Night)
                isSleepy = true;
        }

        public void OnEventGame(EnumGame _game)
        {
            if (_game == EnumGame.New)
                NewGame();

            if (_game == EnumGame.New || _game == EnumGame.Load || _game == EnumGame.Resume)
                isPaused = false;
            else if (_game == EnumGame.Pause || _game == EnumGame.Battle || _game == EnumGame.CutScene)
                isPaused = true;
        }

        private void OnEnable()
        {
            EventWorldTime.Instance.AddListener(OnEventWorldTime);
            EventGame.Instance.AddListener(OnEventGame);
        }

        private void OnDisable()
        {
            if (!this.gameObject.scene.isLoaded) return;

            EventWorldTime.Instance?.RemoveListener(OnEventWorldTime);
            EventGame.Instance?.RemoveListener(OnEventGame);
        }
    }
}