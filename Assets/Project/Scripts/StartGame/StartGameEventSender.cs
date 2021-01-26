using UnityEngine;
using Doozy.Engine;

using Project.EventBusSystem;

namespace Project
{
    public class StartGameEventSender : MonoBehaviour
    {
        public string GameEvent = "StartGame";

        private void Awake()
        {
            EventBus.Instance.Register<StartGameEvent>(OnStartGame);
        }

        private void OnStartGame(StartGameEvent data)
        {
            Message.Send(new GameEventMessage(GameEvent));
        }
    }
}
