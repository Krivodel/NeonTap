using UnityEngine;

namespace Project
{
    public static class Vector3Extensions
    {
        private const float InvertFloat = -1f;

        public static void SetX(ref this Vector3 vector, float newX)
        {
            vector.x = newX;
        }

        public static void SetY(ref this Vector3 vector, float newY)
        {
            vector.y = newY;
        }

        public static void SetXY(ref this Vector3 vector, float newX, float newY)
        {
            vector.x = newX;
            vector.y = newY;
        }

        public static void InvertX(ref this Vector3 vector)
        {
            vector.x *= InvertFloat;
        }
    }
}
