namespace Project.EventBusSystem
{
    public readonly struct SettingsCounterStepChangedEvent
    {
        public readonly int CounterStep;

        public SettingsCounterStepChangedEvent(int counterStep)
        {
            CounterStep = counterStep;
        }
    }
}
