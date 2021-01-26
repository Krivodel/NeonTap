using UnityEngine;
using UnityEngine.UI;

namespace Project
{
    public class SetSoundSlider : MonoBehaviour
    {
        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();

            _slider.onValueChanged.AddListener(OnValueChanged);

            _slider.value = Settings.Instance.GetSound();
        }

        private void OnValueChanged(float value)
        {
            Settings.Instance.SetSound(value);
        }
    }
}
