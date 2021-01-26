using UnityEngine;

namespace Project
{
    public class CameraResolutionController : MonoBehaviour
    {
        private void Awake()
        {
            Reinitialize();
        }

        public void Reinitialize()
        {
            Camera camera = GetComponent<Camera>();

            float initialSize = camera.orthographicSize;
            float targetAspect = 720f / 1440f;

            float constantWidthSize = initialSize * (targetAspect / camera.aspect);

            camera.orthographicSize = constantWidthSize;
        }
    }
}
