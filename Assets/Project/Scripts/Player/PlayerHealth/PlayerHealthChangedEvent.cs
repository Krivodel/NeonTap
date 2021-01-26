namespace Project.EventBusSystem
{
    public readonly struct PlayerHealthChangedEvent
    {
        public readonly pint Health;

        public PlayerHealthChangedEvent(pint health)
        {
            Health = health;
        }
    }
}
