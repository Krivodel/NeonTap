using UnityEngine;
using UnityEngine.UI;

namespace Project.Components
{
    internal sealed class ColorGammaComponent : ComponentBase
    {
        [HideInInspector] public Image Image;

        private void Awake()
        {
            Image = GetComponent<Image>();
        }
    }
}
