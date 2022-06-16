using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TimeGames.Object;
using TMPro;

namespace TimeGames
{
    public class PanelShopDetail : MonoBehaviour
    {
        public TextMeshProUGUI[] listTextStat;

        [Space]
        public TextMeshProUGUI textName;
        public TextMeshProUGUI textDesc;
        public TextMeshProUGUI textMax;
        public TextMeshProUGUI textHp;
        public TextMeshProUGUI textMp;
        public TextMeshProUGUI textQty;
        public TextMeshProUGUI textPrice;

        [Space]
        public Button btnBuy;

        private int qty;
        private int maxQty;
        private int price;
        private int totalPrice;

        [Header("Reference")]
        private PlayerManager playerManager;

        private void Start()
        {
            playerManager = PlayerManager.Instance;
        }

        public void Setup(ObjectItemBase _objectItem)
        {
            qty = 1;
            price = _objectItem.price;

            Refresh(
                _objectItem.GetListStat(),
                _objectItem.maxQty,
                _objectItem.HP,
                _objectItem.MP,
                _objectItem.itemName,
                _objectItem.desc
                );

            RefreshPrice();
        }

        public void BtnBuy()
        {
        }

        public void BtnLeft()
        {
            qty--;

            if(qty < 1)
                qty = 1;

            RefreshPrice();
        }

        public void BtnRight()
        {
            qty++;

            if(qty > maxQty)
                qty = maxQty;

            RefreshPrice();
        }

        private void Refresh(int[] _listStat, int _maxQty, int _hp, int _mp, string _name, string _desc)
        {
            for (int i = 0; i < listTextStat.Length; i++)
                listTextStat[i].text = _listStat[i].ToString();

            textName.text = _name;
            textDesc.text = _desc;
            textMax.text = _maxQty.ToString();
            textHp.text = _hp.ToString();
            textMp.text = _mp.ToString();
        }

        private void RefreshPrice()
        {
            totalPrice = qty * price;
            textPrice.text = totalPrice.ToString();

            if (totalPrice > playerManager.coin)
                btnBuy.interactable = false;
        }
    }
}