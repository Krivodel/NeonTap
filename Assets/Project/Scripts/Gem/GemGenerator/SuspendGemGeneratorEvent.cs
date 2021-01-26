namespace Project.EventBusSystem
{
    public readonly struct SuspendGemGeneratorEvent
    {
        public readonly float Time;

        public SuspendGemGeneratorEvent(float time)
        {
            Time = time;
        }
    }
}
