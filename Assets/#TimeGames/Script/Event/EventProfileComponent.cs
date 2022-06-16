using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TimeGames.Misc;

namespace TimeGames.Event
{
    public class EventProfileComponent : Singleton<EventProfileComponent>
    {
        private event Action<string> onProfileComponent;

        public void Invoke(string _panelName)
        {
            onProfileComponent?.Invoke(_panelName);
        }

        public void AddListener(Action<string> _action)
        {
            onProfileComponent += _action;
        }

        public void RemoveListener(Action<string> _action)
        {
            onProfileComponent -= _action;
        }
    }

    public interface IEventProfileComponent
    {
        void OnEventGame(string _panelName);
    }
}