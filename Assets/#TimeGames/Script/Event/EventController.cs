using System;
using UnityEngine;

using TimeGames.Misc;

namespace TimeGames.Event
{
    public enum EnumEventController
    {
        All,

        Character,
        Cursor
    }

    public class EventController : Singleton<EventController>
    {
        private event Action<EnumEventController, bool> OnControllerLock;

        public EnumEventController currentActiveController { get; private set; }

        /// <summary>
        /// Mengontrol controller yang aktif.
        /// Hanya satu controller yang dapat aktif dalam satu waktu.
        /// </summary>
        /// <param name="_eventController"></param>
        /// <param name="_lock"></param>
        public void Invoke(EnumEventController _eventController, bool _lock)
        {
            OnControllerLock?.Invoke(_eventController, _lock);

            currentActiveController = _eventController;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_listener"></param>
        public void AddListener(Action<EnumEventController, bool> _listener)
        {
            OnControllerLock += _listener;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_listener"></param>
        public void RemoveListener(Action<EnumEventController, bool> _listener)
        {
            OnControllerLock -= _listener;
        }
    }

    public interface IEventController
    {
        /// <summary>
        /// Dipanggil ketika Trigger (EventController) dipanggil.
        /// </summary>
        /// <param name="_eventController"></param>
        /// <param name="_isLocked"></param>
        public void OnEventController(EnumEventController _eventController, bool _isLocked);
    }
}