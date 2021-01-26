using UnityEngine;

using Project.EventBusSystem;

namespace Project
{
    public class GemCounterInfo
    {
        public static GemCounterInfo Instance => _instance ?? (_instance = new GemCounterInfo());
        private static GemCounterInfo _instance;

        public pint TotalCount { get; private set; }

        [RuntimeInitializeOnLoadMethod]
        private static void Awake()
        {
            EventBus.Instance.RegisterListenerEvent(typeof(StartGameEvent), new EventListener<StartGameEvent>(Instance.OnStartGame));
            EventBus.Instance.RegisterListenerEvent(
                typeof(GemTotalCountChangedEvent), new EventListener<GemTotalCountChangedEvent>(Instance.OnGemTotalCountChanged));
        }

        private void OnStartGame(StartGameEvent data)
        {
            TotalCount = 0;
        }

        private void OnGemTotalCountChanged(GemTotalCountChangedEvent data)
        {
            TotalCount = data.TotalCount;
        }
    }
}
