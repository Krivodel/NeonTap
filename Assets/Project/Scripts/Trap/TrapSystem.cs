using Project.EventBusSystem;
using Project.Components;

namespace Project.Systems
{
    internal sealed class TrapSystem : SystemBase, IUpdatable
    {
        private TrapComponent Current;

        protected override void OnCreate()
        {
            Components = Entities.Instance.With<TrapComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            for (int i = 0; i < Components.Count; i++)
            {
                Current = (TrapComponent)Components[i];

                Current.transform.position += Current.Direction * deltaTime;
            }
        }
    }
}
