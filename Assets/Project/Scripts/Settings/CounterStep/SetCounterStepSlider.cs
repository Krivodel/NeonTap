using UnityEngine;
using UnityEngine.UI;

namespace Project
{
    public class SetCounterStepSlider : MonoBehaviour
    {
        private Slider _slider;

        public Text Text;

        private void Awake()
        {
            _slider = GetComponent<Slider>();

            _slider.onValueChanged.AddListener(OnValueChanged);

            int step = Settings.Instance.GetCounterStep();

            _slider.value = step;
            Text.text = step.ToString();
        }

        private void OnValueChanged(float value)
        {
            int step = (int)value;

            Text.text = step.ToString();

            Settings.Instance.SetCounterStep(step);
        }
    }
}
