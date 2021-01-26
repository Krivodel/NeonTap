namespace Project.EventBusSystem
{
    public readonly struct ColorGammaDataChangeEvent
    {
        public readonly ColorGammaData Data;

        public ColorGammaDataChangeEvent(ColorGammaData data)
        {
            Data = data;
        }
    }
}
