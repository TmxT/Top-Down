using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TimeGames.Misc;
using TMPro;

namespace TimeGames
{
    public class PanelDialog : Typewriter
    {
        public GameObject objPanel;

        [Space]
        public TextMeshProUGUI textName;
        public TextMeshProUGUI textDialog;

        public void Open()
        {
            objPanel.SetActive(true);
        }

        public void Close()
        {
            objPanel.SetActive(false);
        }

        public void Setup(string _name, string _dialog, Action _onNext)
        {
            textName.text = _name;
            StartCoroutine(CoroutineWrite(_dialog, textDialog));

            onNext += _onNext;
        }

        public void BtnDialog()
        {
            SkipWrite();
        }
    }
}