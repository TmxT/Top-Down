using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TimeGames.Misc;

namespace TimeGames.Event
{
    public class EventCursor : Singleton<EventCursor>
    {
        private event Action<EnumCursorPosition> OnCursorChanged;

        public EnumCursorPosition currentCursorPosition { get; private set; }

        /// <summary>
        /// Mengganti informasi panel yang saat ini sedang aktif.
        /// </summary>
        /// <param name="_cursorPosition"></param>
        public void Invoke(EnumCursorPosition _cursorPosition)
        {
            OnCursorChanged?.Invoke(_cursorPosition);

            currentCursorPosition = _cursorPosition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_listener"></param>
        public void AddListener(Action<EnumCursorPosition> _listener)
        {
            OnCursorChanged += _listener;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_listener"></param>
        public void RemoveListener(Action<EnumCursorPosition> _listener)
        {
            OnCursorChanged -= _listener;
        }
    }

    public interface IEventCursor
    {
        /// <summary>
        /// Dipanggil ketika TriggerOnKeyboardAction (EventCursor) dipanggil.
        /// </summary>
        /// <param name="_cursorPosition"></param>
        public void OnEventCursor(EnumCursorPosition _cursorPosition);
    }
}