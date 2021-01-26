using UnityEngine;

using Project.EventBusSystem;
using Project.Components;

namespace Project.Systems
{
    internal sealed class ColorGammaSystem : SystemBase, IUpdatable
    {
        private ColorGammaComponent Current;

        private ColorGammaData data;

        private Color currentColor;

        private float deltaTime;

        protected override void OnCreate()
        {
            SetColorGammaData(ColorGammaData.Default);

            EventBus.Instance.Register<ColorGammaDataChangeEvent>(OnColorGammaDataChange);
            EventBus.Instance.Register<StopGameEvent>(OnStopGame);

            Components = Entities.Instance.With<ColorGammaComponent>();
        }

        private void OnColorGammaDataChange(ColorGammaDataChangeEvent data)
        {
            SetColorGammaData(data.Data);
        }

        private void OnStopGame(StopGameEvent data)
        {
            SetColorGammaData(ColorGammaData.Default);
        }

        public void OnUpdate(float deltaTime)
        {
            CalculateInputs(deltaTime);
            SetColor();

            for (int i = 0; i < Components.Count; i++)
            {
                Current = (ColorGammaComponent)Components[i];

                Current.Image.color = currentColor;
            }
        }

        private void CalculateInputs(float deltaTime)
        {
            this.deltaTime = deltaTime;
        }

        private void SetColorGammaData(ColorGammaData data)
        {
            this.data = data;
        }

        private void SetColor()
        {
            currentColor = Color.Lerp(currentColor, data.TargetColor, data.Speed * deltaTime);
        }
    }
}
