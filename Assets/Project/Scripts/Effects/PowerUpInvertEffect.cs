using UnityEngine;
using Krivodeling.Animation;

using Project.EventBusSystem;

namespace Project
{
    public class PowerUpInvertEffect : MonoBehaviour
    {
        private TransformAnimator _animator;

        private void Awake()
        {
            _animator = GetComponent<TransformAnimator>();

            EventBus e = EventBus.Instance;

            e.Register<PowerUpInvertActivatedEvent>(OnPowerUpInvertActivated);
        }

        private void OnPowerUpInvertActivated(PowerUpInvertActivatedEvent data)
        {
            _animator.Play();
        }
    }
}
