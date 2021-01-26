using UnityEngine;

using Project.EventBusSystem;
using Project.Components;

namespace Project.Systems
{
    internal sealed class PlayerRippleSystem : SystemBase
    {
        private PlayerRippleComponent Current;

        protected override void OnCreate()
        {
            Components = Entities.Instance.With<PlayerRippleComponent>();

            EventBus.Instance.RegisterListenerEvent(
                typeof(PlayerAreaBorderBottomEnteredEvent), new EventListener<PlayerAreaBorderBottomEnteredEvent>(OnPlayerAreaBorderBottomEntered));
        }

        private void OnPlayerAreaBorderBottomEntered(PlayerAreaBorderBottomEnteredEvent data)
        {
            Current = (PlayerRippleComponent)Components[0];

            Transform rippleTransform = Entities.Instance.CreatePoolableEntity(Current.RipplePrefab, Current.Transform.position + Current.Offset).transform;

            float newScale = data.VelocityMagnitude / 8f;

            rippleTransform.localScale = new Vector3(newScale, newScale, 0f);

            Current.AudioSource.PlayOneShot(Current.DropSound, Mathf.Clamp01(data.VelocityMagnitude / 12f));
        }
    }
}
