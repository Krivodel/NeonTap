using UnityEngine;
using UnityEngine.UI;

using Project.EventBusSystem;
using Doozy.Engine.UI;

namespace Project
{
    public class StartGameButton : MonoBehaviour
    {
        private StartGameEvent EventData;

        private void Awake()
        {
            //GetComponent<Button>().onClick.AddListener(Play);
            GetComponent<UIButton>().OnClick.OnTrigger.Event.AddListener(Play);
        }

        private void Play()
        {
            EventBus.Instance.PostEvent(EventData);
        }
    }
}
