using UnityEngine;
using UnityEngine.UI;

using Project.EventBusSystem;

namespace Project
{
    public class GemTotalCountText : MonoBehaviour
    {
        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();

            EventBus.Instance.RegisterListenerEvent(typeof(PrestopGameEvent), new EventListener<PrestopGameEvent>(OnPrestopGame));
            EventBus.Instance.RegisterListenerEvent(typeof(StopGameEvent), new EventListener<StopGameEvent>(OnStopGame));
        }

        private void OnPrestopGame(PrestopGameEvent data)
        {
            UpdateText();
        }

        private void OnStopGame(StopGameEvent data)
        {
            UpdateText();
        }

        private void UpdateText()
        {
            _text.text = GemCounterInfo.Instance.TotalCount.ToString();
        }
    }
}
