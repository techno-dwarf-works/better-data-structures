using System;
using UnityEngine;

namespace Better.DataStructures.Ranges
{
    public static class RangeExtensions
    {
        public static int Clamp(this Range<int> range, int value)
        {
            return Mathf.Clamp(value, range.Min, range.Max);
        }

        public static float Clamp(this Range<float> range, float value)
        {
            return Mathf.Clamp(value, range.Min, range.Max);
        }
        
        public static float Random(this Range<float> range)
        {
            return UnityEngine.Random.Range(range.Min, range.Max);
        }

        public static int Random(this Range<int> range)
        {
            return UnityEngine.Random.Range(range.Min, range.Max + 1); // +1 to have inclusive random
        }

        public static float Lerp(this Range<float> range, float t)
        {
            return Mathf.Lerp(range.Min, range.Max, t);
        }

        public static int Lerp(this Range<int> range, float t)
        {
            return Mathf.RoundToInt(Mathf.Lerp(range.Min, range.Max, t));
        }

        public static bool Contains(this Range<float> range, float value)
        {
            return value >= range.Min && value <= range.Max;
        }

        public static bool Contains(this Range<int> range, int value)
        {
            return value >= range.Min && value <= range.Max;
        }

        public static double Clamp(this Range<double> range, double value)
        {
#if UNITY_2021_3_OR_NEWER

            return Math.Clamp(value, range.Min, range.Max);
#else
            if (value < range.Min)
                value = range.Min;
            else if (value > range.Max)
                value = range.Max;
            return value;
#endif
        }

        public static byte Clamp(this Range<byte> range, byte value)
        {
#if UNITY_2021_3_OR_NEWER
            return Math.Clamp(value, range.Min, range.Max);
#else
            if (value < range.Min)
                value = range.Min;
            else if (value > range.Max)
                value = range.Max;
            return value;
#endif
        }
    }
}