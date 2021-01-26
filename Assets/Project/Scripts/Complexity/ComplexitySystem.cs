using UnityEngine;

using Project.EventBusSystem;

namespace Project.Systems
{
    internal sealed class ComplexitySystem : SystemBase
    {
        private string lastComplexityKey = "LastComplexity";

        protected override void OnCreate()
        {
            EventBus.Instance.RegisterListenerEvent(typeof(ComplexityChangedEvent), new EventListener<ComplexityChangedEvent>(OnComplexityChanged));
        }

        private void OnComplexityChanged(ComplexityChangedEvent data)
        {
            Profile.Instance.Complexity = data.NewComplexity;

            switch (data.NewComplexity)
            {
                case Complexity.Easy:
                    Time.timeScale = 1f;
                    break;
                case Complexity.Normal:
                    Time.timeScale = 1.25f;
                    break;
                case Complexity.Heavy:
                    Time.timeScale = 1.5f;
                    break;
            }

            PlayerPrefs.SetInt(lastComplexityKey, (int)data.NewComplexity);
        }
    }
}
