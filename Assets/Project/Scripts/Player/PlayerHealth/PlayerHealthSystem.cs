using UnityEngine;

using Project.EventBusSystem;

namespace Project.Systems
{
    internal sealed class PlayerHealthSystem : SystemBase
    {
        private pint Health;

        private bool wasRecovered;

        protected override void OnCreate()
        {
            EventBus.Instance.RegisterListenerEvent(typeof(StartGameEvent), new EventListener<StartGameEvent>(OnStartGame));
            EventBus.Instance.RegisterListenerEvent(
                typeof(PlayerHealthRecoveredEvent), new EventListener<PlayerHealthRecoveredEvent>(OnPlayerHealthRecovered));
            EventBus.Instance.RegisterListenerEvent(typeof(GemDestroyedEvent), new EventListener<GemDestroyedEvent>(OnGemDestroyed));
            EventBus.Instance.RegisterListenerEvent(typeof(TrapTakenEvent), new EventListener<TrapTakenEvent>(OnTrapTaken));
        }

        private void OnStartGame(StartGameEvent data)
        {
            Health = 1;

            wasRecovered = false;

            EventBus.Instance.PostEvent(new PlayerHealthChangedEvent(Health));
        }

        private void OnPlayerHealthRecovered(PlayerHealthRecoveredEvent data)
        {
            AddHealth(data.Health);
        }

        private void OnGemDestroyed(GemDestroyedEvent data)
        {
            SubtractHealth(1);
        }

        private void OnTrapTaken(TrapTakenEvent data)
        {
            if (!PlayerInfo.Instance.IsInvulnerable)
                SubtractHealth(data.Damage);
        }

        private void SubtractHealth(pint damage)
        {
            Health -= damage;

            EventBus.Instance.PostEvent(new PlayerHealthChangedEvent(Health));

            if (Health <= 0)
            {
                Health = 0;

                if (wasRecovered)
                {
                    EventBus.Instance.PostEvent(new StopGameEvent());
                }
                else
                {
                    wasRecovered = true;

                    if (Application.internetReachability == NetworkReachability.NotReachable)
                        EventBus.Instance.PostEvent(new StopGameEvent());
                    else
                        EventBus.Instance.PostEvent(new PrestopGameEvent());
                }
            }
        }

        private void AddHealth(pint health)
        {
            Health += health;

            EventBus.Instance.PostEvent(new PlayerHealthChangedEvent(Health));
        }
    }
}
