using System;

namespace Project
{
    public static class Random
    {
        private const double InvMaxIntExOne = 1.0 / (int.MaxValue + 1.0);
        private const double InvIntMax = 1.0 / int.MaxValue;

        private static int seed;

        private static uint t;
        private static uint _x;
        private static uint _y = 715895001;
        private static uint _z = 901002486;
        private static uint _w = 147302569;

        private static int lastResult;

        private const int div = 100;
        private const int infinity = 0x7fffffff;
        private const int
            a = 1002547121,
            b = 1888500161,
            c = 100110001,
            d = 48545,
            e = 19,
            f = 8,
            g = 11;

        private static void SetSeed()
        {
            seed += Environment.TickCount / div - lastResult;
            t = _x ^ (_x << g);
            _x = (uint)(seed * a + seed * b + seed * c + seed * d);
            _y ^= _x;
            _z ^= _y;
            _w ^= _z;
            _y = _w;
        }

        public static int Range(int min, int max)
        {
            SetSeed();

            if (min >= max)
                return min;

            int result = min + (int)(InvMaxIntExOne * (int)(infinity & (_w = _w ^ (_w >> e) ^ t ^ (t >> f))) * (max - min));
            lastResult = result;

            return result;
        }

        public static int Range(int max)
        {
            return Range(0, max);
        }

        public static float Range(float min, float max, bool includeMax = true)
        {
            SetSeed();

            if (min >= max)
                return min;

            float result = min + (float)((includeMax ? InvIntMax : InvMaxIntExOne) * (infinity & (_w = _w ^ (_w >> e) ^ t ^ (t >> f))) * (max - min));
            lastResult = (int)result;

            return result;
        }

        public static float Range(float max)
        {
            return Range(0f, max);
        }

        public static bool Boolean()
        {
            lastResult = (Environment.TickCount ^ lastResult) % 2;

            return lastResult == 0;
        }

        public static float One()
        {
            return Boolean() ? 1f : -1f;
        }

        public static float OneZero()
        {
            return Boolean() ? (Boolean() ? 1f : -1f) : 0f;
        }
    }
}
