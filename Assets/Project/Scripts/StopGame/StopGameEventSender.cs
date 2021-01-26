using UnityEngine;
using Doozy.Engine;

using Project.EventBusSystem;

namespace Project
{
    public class StopGameEventSender : MonoBehaviour
    {
        public string GameEvent = "StopGame";

        private void Awake()
        {
            EventBus.Instance.Register<StopGameEvent>(OnStopGame);
        }

        private void OnStopGame(StopGameEvent data)
        {
            Message.Send(new GameEventMessage(GameEvent));
        }
    }
}
