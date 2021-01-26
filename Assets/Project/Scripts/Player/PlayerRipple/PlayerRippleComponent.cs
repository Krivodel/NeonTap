using UnityEngine;

namespace Project.Components
{
    internal sealed class PlayerRippleComponent : ComponentBase
    {
        [HideInInspector] public Transform Transform;
        public AudioSource AudioSource;
        public GameObject RipplePrefab;
        public AudioClip DropSound;
        public Vector3 Offset = new Vector3(0.048f, -0.188f, 0f);
    }
}
