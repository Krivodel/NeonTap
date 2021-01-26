using System;

namespace Project.EventBusSystem
{
    public static partial class EventBusExtensions
    {
        public static void Register<T>(this EventBus eventBus, Action<T> listenerAction)
        {
            eventBus.RegisterListenerEvent(typeof(T), new EventListener<T>(listenerAction));
        }
    }
}
