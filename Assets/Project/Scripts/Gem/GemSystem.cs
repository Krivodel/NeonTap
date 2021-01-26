using Project.Components;

namespace Project.Systems
{
    internal sealed class GemSystem : SystemBase, IUpdatable
    {
        private GemComponent Current;

        protected override void OnCreate()
        {
            Components = Entities.Instance.With<GemComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            for (int i = 0; i < Components.Count; i++)
            {
                Current = (GemComponent)Components[i];

                Current.Transform.position += Current.Direction * deltaTime;
            }
        }
    }
}
