using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TimeGames.Misc;

namespace TimeGames.Event
{
    public class EventPlayer : Singleton<EventPlayer>
    {
        private event Action<EnumPlayerAction> onPlayer;

        public void Invoke(EnumPlayerAction _playerAction)
        {
            onPlayer?.Invoke(_playerAction);
        }

        public void AddListener(Action<EnumPlayerAction> _action)
        {
            onPlayer += _action;
        }

        public void RemoveListener(Action<EnumPlayerAction> _action)
        {
            onPlayer -= _action;
        }
    }

    public interface IEventPlayer
    {
        void OnEventPlayer(EnumPlayerAction _playerAction);
    }
}