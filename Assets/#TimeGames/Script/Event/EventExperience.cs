using System;
using UnityEngine;

using TimeGames.Misc;

namespace TimeGames.Event
{
    public class EventExperience : Singleton<EventExperience>
    {
        private event Action onExperience;

        public void Invoke()
        {
            onExperience?.Invoke();
        }

        public void AddListener(Action _action)
        {
            onExperience += _action;
        }

        public void RemoveListener(Action _action)
        {
            onExperience -= _action;
        }
    }

    public interface IEventExperience
    {
        void OnEventExperience();
    }
}