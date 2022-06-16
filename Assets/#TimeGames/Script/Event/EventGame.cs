using System;

using TimeGames.Misc;

namespace TimeGames.Event
{
    public class EventGame : Singleton<EventGame>
    {
        private event Action<EnumGame> onGame;

        public void Invoke(EnumGame _game)
        {
            onGame?.Invoke(_game);
        }

        public void AddListener(Action<EnumGame> _action)
        {
            onGame += _action;
        }

        public void RemoveListener(Action<EnumGame> _action)
        {
            onGame -= _action;
        }
    }

    public interface IEventGame
    {
        void OnEventGame(EnumGame _game);
    }
}