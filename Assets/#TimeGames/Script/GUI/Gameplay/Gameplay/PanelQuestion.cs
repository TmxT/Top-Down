using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TimeGames.Misc;
using TMPro;

namespace TimeGames
{
    public class PanelQuestion : MonoBehaviour
    {
        public ButtonQuestion[] listBtnQuestion;

        private event Action<ButtonBase> onButtonSelected;

        public void Setup(string[] _listQuestion)
        {
            for (int i = 0; i < listBtnQuestion.Length; i++)
            {
                if(i > _listQuestion.Length - 1)
                    listBtnQuestion[i].Hide();
                else
                    listBtnQuestion[i].Setup(i, _listQuestion[i]);
            }
        }

        public void BtnQuestion()
        {

        }
    }
}