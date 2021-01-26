using UnityEngine;
using System;

namespace Project
{
    [Serializable]
    public struct ColorGammaData
    {
        public Color TargetColor;
        public float Speed;

        public static ColorGammaData Default = new ColorGammaData(Color.white, 1f);

        public ColorGammaData(Color targetColor, float speed)
        {
            TargetColor = targetColor;
            Speed = speed;
        }
    }
}
