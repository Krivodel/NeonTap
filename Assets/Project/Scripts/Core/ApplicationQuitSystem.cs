using Project.EventBusSystem;

namespace Project.Systems
{
    internal sealed class ApplicationQuitSystem : SystemBase, IOnApplicationQuit
    {
        public void OnApplicationQuit()
        {
            EventBus.Instance.PostEvent(new ApplicationQuitEvent());
        }
    }
}
