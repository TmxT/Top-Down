using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TimeGames.Object;
using TMPro;

namespace TimeGames
{
    public class PanelShop : PanelBase
    {
        private List<ButtonItemShop> listBtnItem = new List<ButtonItemShop>();
        private ObjectItemBase[] listItem;

        [Space]
        public GameObject objPanel;
        public GameObject prefabBtnItem;

        [Space]
        public Transform parentBtnItem;

        [Space]
        public Animator animator;

        [Space]
        public TextMeshProUGUI textShopName;

        [Header("Reference")]
        private PanelShopDetail panelShopDetail;

        private void Start()
        {
            panelShopDetail = GetComponent<PanelShopDetail>();
        }

        public void Open()
        {
            objPanel.SetActive(true);

            StartCoroutine(Coroutine());

            IEnumerator Coroutine()
            {
                yield return StartCoroutine(CoroutinePanel(animator, EnumAnimPanel.Show));
                Refresh();
            }
        }

        public void Close()
        {
            StartCoroutine(Coroutine());

            IEnumerator Coroutine()
            {
                yield return StartCoroutine(CoroutinePanel(animator, EnumAnimPanel.Hide));
                objPanel.SetActive(false);
            }
        }

        public void Selected(int _id)
        {
            panelShopDetail.Setup(listItem[_id]);
        }

        private void Refresh()
        {
            int length = 0;
            int i = 0;

            for (; i < length; i++)
            {
                if (i > listBtnItem.Count - 1)
                    listBtnItem.Add(Instantiate(prefabBtnItem, parentBtnItem).GetComponent<ButtonItemShop>());

                listBtnItem[i].Setup(i, this);
            }

            for (; i < listBtnItem.Count; i++)
                listBtnItem[i].gameObject.SetActive(true);
        }
    }
}