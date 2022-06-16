using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TimeGames.Event;
using TimeGames.Misc;

namespace TimeGames
{
    public class PlayTImeManager : Singleton<PlayTImeManager>, IEventGame
    {
        public int playTime_Hour { get; private set; }
        public int playTime_Minute { get; private set; }
        private float playTime_Second;
        public int PlayTime_Second
        {
            get { return (int)playTime_Second; }
        }

        private bool isPaused;

        private void Start()
        {
            StartCoroutine(CoroutinePlayTime());
        }

        private IEnumerator CoroutinePlayTime()
        {
            while (true)
            {
                if (!isPaused)
                {
                    playTime_Second += Time.deltaTime;

                    if(playTime_Second >= 60)
                    {
                        playTime_Second = 0;
                        playTime_Minute++;
                    }

                    if(playTime_Minute >= 60)
                    {
                        playTime_Minute = 0;
                        playTime_Hour++;
                    }

                    yield return null;
                }
            }
        }

        public void OnEventGame(EnumGame _game)
        {
            if (_game == EnumGame.New || _game == EnumGame.Load || _game == EnumGame.Resume)
                isPaused = false;
            else if (_game == EnumGame.Pause || _game == EnumGame.Battle || _game == EnumGame.CutScene)
                isPaused = true;
        }
    }
}