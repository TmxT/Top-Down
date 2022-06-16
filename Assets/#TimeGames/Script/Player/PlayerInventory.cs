using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TimeGames.Misc;

namespace TimeGames
{
    public class PlayerInventory : Singleton<PlayerInventory>
    {
        private List<InventoryItem> listItem = new List<InventoryItem>();

        private InventoryItem[] tempListEquipment;
        private InventoryItem[] tempListFood;
        private InventoryItem[] tempListPotion;

        public InventoryItem GetItem(int _index) => listItem[_index];

        public InventoryItem[] GetItem(EnumSortType _sortType)
        {
            if (tempListEquipment.Length == 0)
                UpdateTempList();

            switch (_sortType)
            {
                case EnumSortType.All:
                    return listItem.ToArray();

                case EnumSortType.Equipment:
                    return tempListEquipment;

                case EnumSortType.Food:
                    return tempListFood;

                case EnumSortType.Potion:
                    return tempListPotion;
            }

            return null;
        }

        public void AddItem(InventoryItem _item)
        {
            listItem.Add(_item);

            ResetTempList();
        }

        public void RemoveItem(InventoryItem _item)
        {
            listItem.Remove(_item);

            ResetTempList();
        }

        private void UpdateTempList()
        {
            List<InventoryItem> listEquipment = new List<InventoryItem>();
            List<InventoryItem> listFood = new List<InventoryItem>();
            List<InventoryItem> listPotion = new List<InventoryItem>();

            foreach(InventoryItem _item in listItem)
            {
                switch (_item.type)
                {
                    case EnumSortType.Equipment:
                        listEquipment.Add(_item);
                        break;

                    case EnumSortType.Food:
                        listFood.Add(_item);
                        break;

                    case EnumSortType.Potion:
                        listPotion.Add(_item);
                        break;
                }
            }

            tempListEquipment = listEquipment.ToArray();
            tempListFood = listFood.ToArray();
            tempListPotion = listPotion.ToArray();
        }

        private void ResetTempList()
        {
            tempListEquipment = null;
            tempListFood = null;
            tempListPotion = null;
        }
    }
}