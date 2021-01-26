using UnityEngine;
using Doozy.Engine;

using Project.EventBusSystem;

namespace Project
{
    public class PrestopGameEventSender : MonoBehaviour
    {
        public string GameEvent = "PrestopGame";

        private void Awake()
        {
            EventBus.Instance.Register<PrestopGameEvent>(OnPrestopGame);
        }

        private void OnPrestopGame(PrestopGameEvent data)
        {
            Message.Send(new GameEventMessage(GameEvent));
        }
    }
}
