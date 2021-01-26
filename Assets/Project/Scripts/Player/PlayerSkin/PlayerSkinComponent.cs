using UnityEngine;

namespace Project.Components
{
    internal sealed class PlayerSkinComponent : ComponentBase
    {
        [HideInInspector] public SpriteRenderer SpriteRenderer;

        private void Awake()
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
}
