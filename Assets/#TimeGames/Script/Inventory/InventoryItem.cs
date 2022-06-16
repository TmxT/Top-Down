using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TimeGames.Object;

namespace TimeGames
{
    public class InventoryItem : MonoBehaviour
    {
        public EnumSortType type { get; private set; }

        [Header("Item")]
        private Equipment equipment;
        private ObjectItemFood food;
        private ObjectItemPotion potion;

        public InventoryItem(Equipment _equipment)
        {
            type = EnumSortType.Equipment;

            equipment = _equipment;
        }

        public InventoryItem(ObjectItemFood _food)
        {
            type = EnumSortType.Food;

            food = _food;
        }

        public InventoryItem(ObjectItemPotion _potion)
        {
            type = EnumSortType.Potion;

            potion = _potion;
        }

        public void Use()
        {
            switch (type)
            {
                case EnumSortType.Equipment:
                    UseEquipment();
                    break;

                case EnumSortType.Food:
                    UseFood();
                    break;

                case EnumSortType.Potion:
                    UsePotion();
                    break;
            }
        }

        private void UseEquipment()
        {

        }

        private void UseFood()
        {

        }

        private void UsePotion()
        {

        }
    }
}