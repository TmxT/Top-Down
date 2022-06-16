using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TimeGames.Misc;

namespace TimeGames.Event
{
    public class EventKeyboard : Singleton<EventKeyboard>
    {
        private event Action<EnumKeyboardAction> OnKeyboardAction;

        /// <summary>
        /// Mendapatkan informasi perubahan Keyboard Action untuk panel yang sedang aktif.
        /// </summary>
        /// <param name="_cursorPosition"></param>
        /// <param name="_keyboardAction"></param>
        public void Invoke(EnumKeyboardAction _keyboardAction)
        {
            OnKeyboardAction?.Invoke(_keyboardAction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_listener"></param>
        public void AddListener(Action<EnumKeyboardAction> _listener)
        {
            OnKeyboardAction += _listener;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_listener"></param>
        public void RemoveListener(Action<EnumKeyboardAction> _listener)
        {
            OnKeyboardAction -= _listener;
        }
    }

    public interface IEventKeyboard
    {
        /// <summary>
        /// Mengganti posisi cursor ketika Player berinteraksi menggunakan Keyboard.
        /// </summary>
        /// <param name="_cursorPosition"></param>
        /// <param name="_keyboardAction"></param>
        public void OnKeyboard(EnumKeyboardAction _keyboardAction);
    }
}