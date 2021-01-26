using UnityEngine;
using UnityEngine.UI;

using Project.EventBusSystem;

namespace Project
{
    public class ComplexityChangedListenerSlider : MonoBehaviour
    {
        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();

            EventBus.Instance.RegisterListenerEvent(typeof(ComplexityChangedEvent), new EventListener<ComplexityChangedEvent>(OnComplexityChanged));
        }

        private void OnComplexityChanged(ComplexityChangedEvent data)
        {
            _slider.value = (float)data.NewComplexity;
        }
    }
}
