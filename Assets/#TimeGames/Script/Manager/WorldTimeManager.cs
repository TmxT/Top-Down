using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TimeGames.Event;
using TimeGames.Misc;

namespace TimeGames
{
    public class WorldTimeManager : Singleton<WorldTimeManager>, IEventGame
    {
        public int debugSpeed = 10;
        private int morningTime = 12;
        private int nightTime = 24;
        private int timePerHour = 10;
        public int clockDir { get; private set; }
        public int totalTimePerDay { get; private set; }

        public float curTime { get; private set; }

        public bool isPaused { get; private set; }

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            totalTimePerDay = nightTime - morningTime;
        }

        private void Update()
        {
            if(isPaused)
                return;

            WorldTime();
        }

        private void WorldTime()
        {
            if (curTime < morningTime && clockDir == -1)
            {
                clockDir = 1;

                EventWorldTime.Instance.Invoke(EnumWorldTime.Day);
            }
            else if (curTime > nightTime && clockDir == 1)
            {
                clockDir = -1;

                EventWorldTime.Instance.Invoke(EnumWorldTime.Night);
            }

            curTime += (Time.deltaTime * clockDir) / timePerHour * debugSpeed;
        }

        private void NewGame()
        {
            clockDir = 1;
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
            EventGame.Instance.AddListener(OnEventGame);
        }

        private void OnDisable()
        {
            if (!this.gameObject.scene.isLoaded) return;

            EventGame.Instance?.RemoveListener(OnEventGame);
        }
    }
}