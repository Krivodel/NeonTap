using UnityEngine;

using Project.EventBusSystem;

namespace Project
{
    public class RecordInfo
    {
        public static RecordInfo Instance => _instance ?? (_instance = new RecordInfo());
        private static RecordInfo _instance;

        public const string LAST_RECORD_KEY = "LastRecord";

        public bool IsNewRecord { get; private set; }
        public int LastRecord { get; private set; }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        private static void Awake()
        {
            EventBus.Instance.RegisterListenerEvent(typeof(StartGameEvent), new EventListener<StartGameEvent>(Instance.OnStartGame));
            EventBus.Instance.RegisterListenerEvent(typeof(NewRecordEvent), new EventListener<NewRecordEvent>(Instance.OnNewRecord));
        }

        private void OnStartGame(StartGameEvent data)
        {
            IsNewRecord = false;
        }

        private void OnNewRecord(NewRecordEvent data)
        {
            LastRecord = data.NewRecord;
            IsNewRecord = true;
        }
    }
}
