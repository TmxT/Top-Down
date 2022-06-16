using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TimeGames.Misc;

namespace TimeGames.Event
{
    public class EventSettings : Singleton<EventSettings>
    {
        private event Action<EnumSettings> onSettings;

        public void Invoke(EnumSettings _settings)
        {
            onSettings?.Invoke(_settings);
        }

        public void AddListener(Action<EnumSettings> _action)
        {
            onSettings += _action;
        }

        public void RemoveListener(Action<EnumSettings> _action)
        {
            onSettings -= _action;
        }
    }

    public interface IEventSettings
    {
        void OnEventSettings(EnumSettings _settings);
    }
}