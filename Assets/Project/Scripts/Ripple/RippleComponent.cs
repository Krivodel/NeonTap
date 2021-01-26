using UnityEngine;

namespace Project.Components
{
    internal sealed class RippleComponent : ComponentBase
    {
        [HideInInspector] public GameObject GameObject;
        [HideInInspector] public Transform Transform;
        [HideInInspector] public SpriteRenderer SpriteRenderer;
        public float DissolutionSpeed = 0.5f;

        private void Awake()
        {
            GameObject = gameObject;
            Transform = GetComponent<Transform>();
            SpriteRenderer = GetComponent<SpriteRenderer>();
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            SpriteRenderer.color = new Color(SpriteRenderer.color.r, SpriteRenderer.color.g, SpriteRenderer.color.b, 1f);
        }
    }
}
