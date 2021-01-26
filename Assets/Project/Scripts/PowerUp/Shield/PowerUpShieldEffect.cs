using UnityEngine;

using Project.EventBusSystem;

namespace Project
{
    public class PowerUpShieldEffect : MonoBehaviour
    {
        private ParticleSystem _particleSystem;

        private void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();

            EventBus.Instance.Register<StopGameEvent>(OnStopGame);
            EventBus.Instance.Register<PowerUpShieldActivatedEvent>(OnPowerUpShieldActivated);
            EventBus.Instance.Register<PowerUpShieldDisactivatedEvent>(OnPowerUpShieldDisactivated);
        }

        private void OnStopGame(StopGameEvent data)
        {
            _particleSystem.Stop();
        }

        private void OnPowerUpShieldActivated(PowerUpShieldActivatedEvent data)
        {
            _particleSystem.Play();
        }

        private void OnPowerUpShieldDisactivated(PowerUpShieldDisactivatedEvent data)
        {
            _particleSystem.Stop();
        }
    }
}
