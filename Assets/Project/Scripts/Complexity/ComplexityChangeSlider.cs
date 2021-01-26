using UnityEngine;
using UnityEngine.UI;

using Project.EventBusSystem;

namespace Project
{
    public class ComplexityChangeSlider : MonoBehaviour
    {
        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();

            _slider.onValueChanged.AddListener(Change);
        }

        private void Change(float newValue)
        {
            Complexity newComplexity = newValue == 0f ? Complexity.Easy : newValue == 1f ? Complexity.Normal : Complexity.Heavy;

            EventBus.Instance.PostEvent(new ComplexityChangedEvent(newComplexity));
        }
    }
}
