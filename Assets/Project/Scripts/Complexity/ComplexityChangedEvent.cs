namespace Project.EventBusSystem
{
    public readonly struct ComplexityChangedEvent
    {
        public readonly Complexity NewComplexity;

        public ComplexityChangedEvent(Complexity newComplexity)
        {
            NewComplexity = newComplexity;
        }
    }
}
