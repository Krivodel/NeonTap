namespace Project.EventBusSystem
{
    public readonly struct GemTotalCountCompletedEvent
    {
        public readonly pint TotalCount;

        public GemTotalCountCompletedEvent(pint totalCount)
        {
            TotalCount = totalCount;
        }
    }
}
