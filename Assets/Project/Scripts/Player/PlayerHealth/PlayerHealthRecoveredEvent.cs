namespace Project.EventBusSystem
{
    public readonly struct PlayerHealthRecoveredEvent
    {
        public readonly pint Health;

        public PlayerHealthRecoveredEvent(pint health)
        {
            Health = health;
        }
    }
}
