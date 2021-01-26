namespace Project.EventBusSystem
{
    public readonly struct SettingsMusicChangedEvent
    {
        public readonly bool Value;

        public SettingsMusicChangedEvent(bool value)
        {
            Value = value;
        }
    }
}
