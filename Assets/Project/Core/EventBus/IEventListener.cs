namespace Project.EventBusSystem
{
    public interface IEventListener
    {
        void PostEvent(object eventObject);
        bool CheckListenerByHash(int hash);
        bool IsRemovable();
    }
}
