using UnityEngine;

using Project.EventBusSystem;

namespace Project.Systems
{
    internal sealed class RecordSystem : SystemBase
    {
        private RecordInfo Info => RecordInfo.Instance;

        protected override void OnCreate()
        {
            int lastRecord;

            if (PlayerPrefs.HasKey(RecordInfo.LAST_RECORD_KEY))
                lastRecord = PlayerPrefs.GetInt(RecordInfo.LAST_RECORD_KEY);
            else
                lastRecord = 0;

            PostNewRecord(lastRecord, lastRecord);

            EventBus.Instance.RegisterListenerEvent(
                typeof(GemTotalCountCompletedEvent), new EventListener<GemTotalCountCompletedEvent>(OnGemTotalCountCompleted));
        }

        private void OnGemTotalCountCompleted(GemTotalCountCompletedEvent data)
        {
            if (data.TotalCount < Info.LastRecord + 1)
                return;

            PostNewRecord(Info.LastRecord, data.TotalCount);

            PlayerPrefs.SetInt(RecordInfo.LAST_RECORD_KEY, data.TotalCount);
        }

        private void PostNewRecord(int lastRecord, int newRecord)
        {
            EventBus.Instance.PostEvent(new NewRecordEvent(lastRecord, newRecord));
        }
    }
}
