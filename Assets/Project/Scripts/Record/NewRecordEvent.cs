namespace Project.EventBusSystem
{
    public readonly struct NewRecordEvent
    {
        public readonly pint LastRecord;
        public readonly pint NewRecord;

        public NewRecordEvent(pint lastRecord, pint newRecord)
        {
            LastRecord = lastRecord;
            NewRecord = newRecord;
        }
    }
}
