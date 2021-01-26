using UnityEngine;
using UnityEngine.UI;

using Project.EventBusSystem;

namespace Project
{
    public class LastRecordText : MonoBehaviour
    {
        private Text _text;

        public string Prefix = "Best: ";

        private void Awake()
        {
            _text = GetComponent<Text>();

            EventBus.Instance.RegisterListenerEvent(typeof(StopGameEvent), new EventListener<StopGameEvent>(OnStopGame));
        }

        private void OnStopGame(StopGameEvent data)
        {
            if (RecordInfo.Instance.IsNewRecord)
                return;

            _text.text = Prefix + "<color=yellow>" + RecordInfo.Instance.LastRecord.ToString() + "</color>";
        }
    }
}
