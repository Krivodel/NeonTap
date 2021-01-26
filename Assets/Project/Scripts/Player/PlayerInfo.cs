using UnityEngine;

using Project.EventBusSystem;

namespace Project
{
    public class PlayerInfo
    {
        public static PlayerInfo Instance => _instance ?? (_instance = new PlayerInfo());
        private static PlayerInfo _instance;

        public bool IsInvulnerable;
        public bool IsInvert;

        [RuntimeInitializeOnLoadMethod]
        private static void Awake()
        {
            EventBus.Instance.Register<StopGameEvent>(Instance.OnStopGame);
        }

        private void OnStopGame(StopGameEvent data)
        {
            IsInvulnerable = false;
            IsInvert = false;
        }
    }
}
