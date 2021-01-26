using UnityEngine;

using Project.EventBusSystem;

namespace Project.Systems
{
    internal sealed class PlayerInputSystem : SystemBase, IUpdatable
    {
        private readonly PlayerInputEvent EventData;

        public void OnUpdate(float deltaTime)
        {
            if (Input.GetMouseButtonDown(0))
                EventBus.Instance.PostEvent(EventData);
        }
    }
}
