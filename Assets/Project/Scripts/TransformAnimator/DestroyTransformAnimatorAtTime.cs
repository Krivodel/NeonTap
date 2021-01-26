using UnityEngine;
using Krivodeling.Animation;

namespace Project
{
    public class DestroyTransformAnimatorAtTime : MonoBehaviour
    {
        public float Time = 8f;

        private void Start()
        {
            Destroy(GetComponent<TransformAnimator>(), Time);
            Destroy(this, Time);
        }
    }
}
