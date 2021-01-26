namespace Project.EventBusSystem
{
    public readonly struct PowerUpCollectedEvent
    {
        public readonly IPowerUp PowerUp;

        public PowerUpCollectedEvent(IPowerUp powerUp)
        {
            PowerUp = powerUp;
        }
    }
}
