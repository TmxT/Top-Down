using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

namespace TimeGames
{
    public class ButtonItemInventory : PanelBase
    {
        public Image imgIcon;

        [Space]
        public TextMeshProUGUI textQty;

        [Header("Panel Action")]
        public GameObject objPanelAction;

        [Space]
        public Animator animPanelAction;

        private int id;

        public void Setup(int _id, int _qty, Sprite _icon)
        {
            id = _id;

            textQty.text = _qty.ToString();
            imgIcon.sprite = _icon;
        }

        public void Clicked()
        {
            if (objPanelAction.activeSelf)
                StartCoroutine(CoroutineHidePanelAction());
            else
                objPanelAction.SetActive(true);
        }

        public void BtnUse()
        {

        }

        public void BtnRemove()
        {

        }

        private IEnumerator CoroutineHidePanelAction()
        {
            yield return StartCoroutine(CoroutinePanel(animPanelAction, EnumAnimPanel.Hide));
            objPanelAction.SetActive(false);
        }
    }
}