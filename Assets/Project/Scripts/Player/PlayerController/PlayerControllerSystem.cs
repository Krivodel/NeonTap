using UnityEngine;

using Project.Components;
using Project.EventBusSystem;

namespace Project.Systems
{
    internal sealed class PlayerControllerSystem : SystemBase, IUpdatable
    {
        private PlayerControllerComponent Current;

        private Vector3 velocity;

        protected override void OnCreate()
        {
            Components = Entities.Instance.With<PlayerControllerComponent>();

            for (int i = 0; i < Components.Count; i++)
            {
                Current = (PlayerControllerComponent)Components[i];

                Current.Rigidbody.velocity = new Vector3(Current.HorizontalSpeed, 0f, 0f);
            }

            EventBus.Instance.RegisterListenerEvent(typeof(PlayerInputEvent), new EventListener<PlayerInputEvent>(PlayerJump));
            EventBus.Instance.RegisterListenerEvent(
                typeof(PlayerAreaBorderEnteredEvent), new EventListener<PlayerAreaBorderEnteredEvent>(OnPlayerAreaBorderEntered));
        }

        public void OnUpdate(float deltaTime)
        {
            for (int i = 0; i < Components.Count; i++)
            {
                Current = (PlayerControllerComponent)Components[i];

                velocity = Current.Rigidbody.velocity;

                velocity.x = Current.isRight ? Current.HorizontalSpeed : -Current.HorizontalSpeed;

                Current.Rigidbody.velocity = velocity;
            }
        }

        private void PlayerJump(PlayerInputEvent data)
        {
            for (int i = 0; i < Components.Count; i++)
            {
                Current = (PlayerControllerComponent)Components[i];

                velocity = Current.Rigidbody.velocity;

                velocity.y = 0f;

                Current.Rigidbody.velocity = velocity;

                Current.Rigidbody.AddForce(Current.JumpForce);
            }
        }

        private void OnPlayerAreaBorderEntered(PlayerAreaBorderEnteredEvent data)
        {
            for (int i = 0; i < Components.Count; i++)
            {
                Current = (PlayerControllerComponent)Components[i];

                if (data.GameObject != Current.gameObject)
                    continue;

                Current.isRight = !Current.isRight;
            }
        }
    }
}
