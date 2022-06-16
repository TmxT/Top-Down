using System;
using UnityEngine;

using TimeGames.Misc;

namespace TimeGames.Event
{
    public class EventHealth : Singleton<EventHealth>
    {
        private event Action<EnumHealthAction> onHealth;

        public void Invoke(EnumHealthAction _healthAction)
        {
            onHealth?.Invoke(_healthAction);
        }

        public void AddListener(Action<EnumHealthAction> _action)
        {
            onHealth += _action;
        }

        public void RemoveListener(Action<EnumHealthAction> _action)
        {
            onHealth -= _action;
        }
    }

    public interface IEventHealth
    {
        void OnEventHealth(EnumHealthAction _healthAction);
    }
}