using Project.EventBusSystem;

namespace Project.Systems
{
    internal sealed class GemCounterSystem : SystemBase
    {
        private pint TotalCount;

        protected override void OnCreate()
        {
            EventBus.Instance.RegisterListenerEvent(typeof(StartGameEvent), new EventListener<StartGameEvent>(OnStartGame));
            EventBus.Instance.RegisterListenerEvent(typeof(StopGameEvent), new EventListener<StopGameEvent>(OnStopGame));
            EventBus.Instance.RegisterListenerEvent(typeof(GemTakenEvent), new EventListener<GemTakenEvent>(OnGemTaken));
        }

        private void OnStartGame(StartGameEvent data)
        {
            TotalCount = 0;
        }

        private void OnStopGame(StopGameEvent data)
        {
            PostGemTotalCountCompleted();
        }

        private void OnGemTaken(GemTakenEvent data)
        {
            TotalCount += data.Count;

            PostGemTotalCountChanged();
        }

        private void PostGemTotalCountChanged()
        {
            EventBus.Instance.PostEvent(new GemTotalCountChangedEvent(TotalCount));
        }

        private void PostGemTotalCountCompleted()
        {
            EventBus.Instance.PostEvent(new GemTotalCountCompletedEvent(TotalCount));
        }
    }
}
