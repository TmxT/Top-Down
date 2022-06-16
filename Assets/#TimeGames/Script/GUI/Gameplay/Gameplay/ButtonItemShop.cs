using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

namespace TimeGames
{
    public class ButtonItemShop : MonoBehaviour
    {
        public Image imgIcon;

        [Space]
        public TextMeshProUGUI textName;

        private int id;

        [Header("Reference")]
        private PanelShop panelShop;

        public void Setup(int _id, PanelShop _panelShop)
        {
            id = _id;
            panelShop = _panelShop;
        }

        public void Clicked()
        {
            panelShop.Selected(id);
        }
    }
}