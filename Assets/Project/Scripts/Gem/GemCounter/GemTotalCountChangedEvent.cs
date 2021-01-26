namespace Project.EventBusSystem
{
    public readonly struct GemTotalCountChangedEvent
    {
        public readonly pint TotalCount;

        public GemTotalCountChangedEvent(pint totalCount)
        {
            TotalCount = totalCount;
        }
    }
}
