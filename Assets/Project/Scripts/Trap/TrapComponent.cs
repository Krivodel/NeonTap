using UnityEngine;
using System;

using Project.EventBusSystem;

namespace Project.Components
{
    internal sealed class TrapComponent : ComponentBase
    {
        [HideInInspector] public Transform Transform;
        [HideInInspector] public GameObject GameObject;
        [HideInInspector] public SpriteRenderer SpriteRenderer;

        public Sprite DefaultSprite;
        public Sprite InvertSprite;
        public string TakeLayerName = "Player";
        public string DestroyLayerName = "Ground";
        public pint Damage = 1;
        public Vector3 Direction = new Vector3(0f, -1f, 0f);

        private void Awake()
        {
            Transform = GetComponent<Transform>();
            GameObject = gameObject;
            SpriteRenderer = GetComponent<SpriteRenderer>();

            EventBus e = EventBus.Instance;

            e.Register<PrestopGameEvent>(OnPrestopGame);
            e.Register<StopGameEvent>(OnStopGame);
            e.Register<PlayerAreaBorderEnteredEvent>(OnPlayerAreaBorderEntered);
            e.Register<PowerUpInvertActivatedEvent>(OnPowerUpInvertActivated);
            e.Register<PowerUpInvertDisactivatedEvent>(OnPowerUpInvertDisactivated);
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            SetSprite();

            Transform.rotation = Quaternion.Euler(0f, 0f, Environment.TickCount % 180f);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer(TakeLayerName))
            {
                Destroy();

                if (PlayerInfo.Instance.IsInvulnerable)
                    EventBus.Instance.PostEvent(new GemTakenEvent(Damage));
                else
                    EventBus.Instance.PostEvent(new TrapTakenEvent(Damage));
            }
            else if (collision.gameObject.layer == LayerMask.NameToLayer(DestroyLayerName))
            {
                Destroy();
            }
        }

        private void OnPrestopGame(PrestopGameEvent data)
        {
            Destroy();
        }

        private void OnStopGame(StopGameEvent data)
        {
            Destroy();
        }

        private void OnPowerUpInvertActivated(PowerUpInvertActivatedEvent data)
        {
            Destroy();
        }

        private void OnPowerUpInvertDisactivated(PowerUpInvertDisactivatedEvent data)
        {
            SetSprite();
        }

        private void Destroy()
        {
            Entities.Instance.DestroyPoolableEntity(GameObject);
        }

        private void SetSprite()
        {
            SpriteRenderer.sprite = PlayerInfo.Instance.IsInvert ? InvertSprite : DefaultSprite;
        }

        private void OnPlayerAreaBorderEntered(PlayerAreaBorderEnteredEvent data)
        {
            if (data.GameObject != GameObject)
                return;

            Direction.InvertX();
        }
    }
}
