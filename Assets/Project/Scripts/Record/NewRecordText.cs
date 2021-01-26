using UnityEngine;
using UnityEngine.UI;

using Project.EventBusSystem;

namespace Project
{
    public class NewRecordText : MonoBehaviour
    {
        private Text _text;

        public string Prefix = "+";
        [TextArea] public string Suffix = '\n' + "New Record";

        private void Awake()
        {
            _text = GetComponent<Text>();

            EventBus.Instance.RegisterListenerEvent(typeof(StartGameEvent), new EventListener<StartGameEvent>(OnStartGame));
            EventBus.Instance.RegisterListenerEvent(typeof(NewRecordEvent), new EventListener<NewRecordEvent>(OnNewRecord));
        }

        private void OnStartGame(StartGameEvent data)
        {
            _text.text = string.Empty;
        }

        private void OnNewRecord(NewRecordEvent data)
        {
            _text.text = Prefix + (data.NewRecord - data.LastRecord) + Suffix;
        }
    }
}
