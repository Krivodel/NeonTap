using System;
using System.Collections.Generic;

namespace Project.EventBusSystem
{
    public sealed class EventBus
    {
        public static EventBus Instance => _instance ?? (_instance = new EventBus());
        private static EventBus _instance;

        public readonly Action<Type, IEventListener> RegisterListenerEvent;
        public readonly Action<Type, int> UnregisterListenerEvent;
        public readonly Action<object> PostEvent;
        public readonly Action CleanRemovableListenerEvent;

        private readonly Dictionary<Type, List<IEventListener>> _listeners;

        private EventBus()
        {
            RegisterListenerEvent = RegisterListener;
            UnregisterListenerEvent = UnregisterListener;
            PostEvent = Post;
            CleanRemovableListenerEvent = CleanRemovableListener;

            _listeners = new Dictionary<Type, List<IEventListener>>();
        }

        private void RegisterListener(Type messageType, IEventListener listener)
        {
            if (!_listeners.TryGetValue(messageType, out List<IEventListener> currentList))
            {
                currentList = new List<IEventListener>();

                _listeners.Add(messageType, currentList);
            }

            if (!currentList.Contains(listener))
                currentList.Add(listener);
        }

        private void UnregisterListener(Type messageType, int listenerHash)
        {
            if (_listeners.TryGetValue(messageType, out List<IEventListener> currentList))
                for (int i = 0; i < currentList.Count; ++i)
                    if (currentList[i].CheckListenerByHash(listenerHash))
                        currentList.Remove(currentList[i--]);
        }

        private void Post(object message)
        {
            if (_listeners.TryGetValue(message.GetType(), out List<IEventListener> currentListenersList))
                for (int i = 0; i < currentListenersList.Count; ++i)
                    currentListenersList[i].PostEvent(message);
        }

        private void CleanRemovableListener()
        {
            foreach (var list in _listeners)
                for (int i = 0; i < list.Value.Count; ++i)
                    if (list.Value[i].IsRemovable())
                        list.Value.Remove(list.Value[i--]);
        }
    }
}
