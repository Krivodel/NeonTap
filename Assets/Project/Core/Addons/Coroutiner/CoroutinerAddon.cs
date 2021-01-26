using UnityEngine;

namespace Project.Addons
{
    public class CoroutinerAddon : MonoBehaviour
    {
        public static CoroutinerAddon Create()
        {
            GameObject obj = new GameObject("[Coroutiner]")
            {
                hideFlags = HideFlags.HideInHierarchy
            };

            return obj.AddComponent<CoroutinerAddon>();
        }
    }
}
