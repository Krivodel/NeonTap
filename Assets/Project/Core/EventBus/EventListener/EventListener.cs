using System;

namespace Project.EventBusSystem
{
    public readonly struct EventListener<T> : IEventListener
    {
        private readonly bool isRemovable;

        private readonly int _listenerHash;
        private readonly Action<T> ListenerAction;

        public EventListener(Action<T> listenerAction, bool isRemovable = true)
        {
            ListenerAction = listenerAction;
            _listenerHash = listenerAction.Target.GetHashCode();
            this.isRemovable = isRemovable;
        }

        public void PostEvent(object eventObject)
        {
            ListenerAction?.Invoke((T)eventObject);
        }

        public bool CheckListenerByHash(int hash)
        {
            return _listenerHash == hash;
        }

        public bool IsRemovable()
        {
            return isRemovable;
        }
    }
}
