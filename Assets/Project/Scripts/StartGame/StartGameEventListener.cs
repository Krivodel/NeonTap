using Doozy.Engine;
using UnityEngine;

using Project.EventBusSystem;

namespace Project
{
    public class StartGameEventListener : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<GameEventListener>().Event.AddListener(OnEvent);
        }

        private void OnEvent(string call)
        {
            EventBus.Instance.PostEvent(new StartGameEvent());
        }
    }
}
