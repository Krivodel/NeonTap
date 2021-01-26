namespace Project.EventBusSystem
{
    public readonly struct TrapTakenEvent
    {
        public readonly int Damage;

        public TrapTakenEvent(int damage)
        {
            Damage = damage;
        }
    }
}
