using UnityEngine;
using UnityEngine.UI;
using Krivodeling.Animation;

using Project.EventBusSystem;

namespace Project
{
    public class GemCounterEffectText : MonoBehaviour
    {
        private Text _text;
        private TransformAnimator _transformAnimator;

        private int step = 10;

        private void Awake()
        {
            _text = GetComponent<Text>();
            _transformAnimator = GetComponent<TransformAnimator>();

            EventBus e = EventBus.Instance;

            e.Register<SettingsCounterStepChangedEvent>(OnSettingsCounterStepChanged);
            e.Register<GemTotalCountChangedEvent>(OnGemTotalCountChanged);
        }

        private void OnSettingsCounterStepChanged(SettingsCounterStepChangedEvent data)
        {
            step = data.CounterStep;
        }

        private void OnGemTotalCountChanged(GemTotalCountChangedEvent data)
        {
            if (data.TotalCount % step != 0)
                return;

            _text.text = data.TotalCount.ToString();

            _transformAnimator.Play();
        }
    }
}
