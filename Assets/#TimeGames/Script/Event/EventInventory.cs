using System;
using UnityEngine;

using TimeGames.Misc;

namespace TimeGames.Event
{
    public class EventInventory : Singleton<EventInventory>
    {
        private event Action<EnumInventoryAction> onInventory;

        public void Invoke(EnumInventoryAction _inventoryAction)
        {
            onInventory?.Invoke(_inventoryAction);
        }

        public void AddListener(Action<EnumInventoryAction> _action)
        {
            onInventory += _action;
        }

        public void RemoveListener(Action<EnumInventoryAction> _action)
        {
            onInventory -= _action;
        }
    }

    public interface IEventInventory
    {
        void OnEventInventory(EnumInventoryAction _inventoryAction);
    }
}