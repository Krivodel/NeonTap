using UnityEngine;

using Project.EventBusSystem;

namespace Project
{
    public abstract class PowerUp : MonoBehaviour, IPowerUp, ITakeListener
    {
        public bool HasLifetime => hasLifetime;
        public bool hasLifetime = true;

        public float Lifetime => lifetime;
        public float lifetime = 10f;
        public float PrestopTime => prestopTime;
        public float prestopTime = 1f;

        public ColorGammaData ColorGammaData => colorGammaData;
        public ColorGammaData colorGammaData = new ColorGammaData(new Color(0f, 0f, 1f, 0.2f), 1f);

        public void OnTake()
        {
            OnCollected();
        }

        private void OnCollected()
        {
            EventBus.Instance.PostEvent(new PowerUpCollectedEvent(this));
        }

        public virtual void OnActive()
        {
            EventBus.Instance.PostEvent(new PowerUpActivatedEvent());
        }

        public virtual void OnDisactive()
        {
            EventBus.Instance.PostEvent(new PowerUpDisactivatedEvent());
        }
    }
}
