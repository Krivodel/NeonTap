namespace Project.EventBusSystem
{
    public readonly struct PlayerSkinChangeEvent
    {
        public readonly PlayerSkinData Data;

        public PlayerSkinChangeEvent(PlayerSkinData data)
        {
            Data = data;
        }
    }
}
