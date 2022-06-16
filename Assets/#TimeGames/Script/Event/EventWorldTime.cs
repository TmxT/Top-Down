using System;
using UnityEngine;

using TimeGames.Misc;

namespace TimeGames.Event
{
    public class EventWorldTime : Singleton<EventWorldTime>
    {
        private event Action<EnumWorldTime> OnWorldTime;

        /// <summary>
        /// Mengganti waktu Siang dan Malam.
        /// </summary>
        /// <param name="_worldTime"></param>
        public void Invoke(EnumWorldTime _worldTime)
        {
            OnWorldTime?.Invoke(_worldTime);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_listener"></param>
        public void AddListener(Action<EnumWorldTime> _listener)
        {
            OnWorldTime += _listener;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_listener"></param>
        public void RemoveListener(Action<EnumWorldTime> _listener)
        {
            OnWorldTime -= _listener;
        }
    }

    public interface IEventWorldTime
    {
        public void OnEventWorldTime(EnumWorldTime _worldTime);
    }
}