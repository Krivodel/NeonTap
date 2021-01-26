using UnityEngine;

namespace Project.Components
{
    internal sealed class PlayerControllerComponent : ComponentBase
    {
        public Rigidbody2D Rigidbody;
        public Vector3 JumpForce = new Vector3(0f, 256f, 0f);
        public float HorizontalSpeed = 3f;

        [HideInInspector] public bool isRight;
    }
}
