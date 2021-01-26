using UnityEngine;
using System;

using Project.EventBusSystem;

namespace Project.Components
{
    internal sealed class GemComponent : ComponentBase
    {
        private ITakeListener[] _takeListeners;

        [HideInInspector] public Transform Transform;
        [HideInInspector] public GameObject GameObject;
        [HideInInspector] public SpriteRenderer SpriteRenderer;

        public Sprite DefaultSprite;
        public Sprite InvertSprite;
        public string TakeLayerName = "Player";
        public string DestroyLayerName = "Ground";
        public pint Count = 1;
        public Vector3 Direction = new Vector3(0f, -1f, 0f);

        private int takeLayer;
        private int destroyLayer;

        private void Awake()
        {
            _takeListeners = GetComponents<ITakeListener>();

            Transform = GetComponent<Transform>();
            GameObject = gameObject;
            SpriteRenderer = GetComponent<SpriteRenderer>();

            takeLayer = LayerMask.NameToLayer(TakeLayerName);
            destroyLayer = LayerMask.NameToLayer(DestroyLayerName);

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
            if (collision.gameObject.layer == takeLayer)
            {
                OnTake();
                Destroy();

                EventBus.Instance.PostEvent(new GemTakenEvent(Count));
            }
            else if (collision.gameObject.layer == destroyLayer)
            {
                Destroy();

                EventBus.Instance.PostEvent(new GemDestroyedEvent());
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

        private void OnPlayerAreaBorderEntered(PlayerAreaBorderEnteredEvent data)
        {
            if (data.GameObject != GameObject)
                return;

            Direction.InvertX();
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

        private void OnTake()
        {
            for (int i = 0; i < _takeListeners.Length; i++)
                _takeListeners[i].OnTake();
        }
    }
}
