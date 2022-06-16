using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using TimeGames.Misc;
using TMPro;

namespace TimeGames
{
    public class ButtonQuestion : ButtonBase
    {
        public TextMeshProUGUI textQuestion;

        public void Setup(int _id, string _question)
        {
            gameObject.SetActive(true);

            textQuestion.text = _question;

            SetId(id);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}