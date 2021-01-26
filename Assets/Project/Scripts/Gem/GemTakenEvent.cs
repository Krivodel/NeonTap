namespace Project.EventBusSystem
{
    public readonly struct GemTakenEvent
    {
        public readonly pint Count;

        public GemTakenEvent(pint count)
        {
            Count = count;
        }
    }
}
