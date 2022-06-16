using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TimeGames.Misc;
using TimeGames.Event;

namespace TimeGames
{
    public class GameManager : Singleton<GameManager>
    {
        private EnumLanguage language;

        public EnumLanguage Language
        {
            get
            {
                return language;
            }
            set
            {
                language = value;

                EventSettings.Instance.Invoke(EnumSettings.Language);
            }
        }

        private void Start()
        {
            Language = EnumLanguage.English; //Debug
        }

        public void NewGame()
        {

            EventGame.Instance.Invoke(EnumGame.New);
        }

        public void LoadGame()
        {


            EventGame.Instance.Invoke(EnumGame.Load);
        }
    }
}