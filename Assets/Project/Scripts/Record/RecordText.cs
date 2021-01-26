using UnityEngine;
using UnityEngine.UI;

using Project.EventBusSystem;

namespace Project
{
    public class RecordText : MonoBehaviour
    {
        private Text _text;

        [TextArea] public string Prefix = "B\nE\nS\nT\n";

        private void Awake()
        {
            _text = GetComponent<Text>();

            EventBus.Instance.RegisterListenerEvent(typeof(NewRecordEvent), new EventListener<NewRecordEvent>(OnNewRecord));
        }

        private void OnNewRecord(NewRecordEvent data)
        {
            UpdateText(data.NewRecord);
        }

        private void UpdateText(int record)
        {
            _text.text = Prefix + "<color=yellow>" + record.ToString() + "</color>";
        }
    }
}
