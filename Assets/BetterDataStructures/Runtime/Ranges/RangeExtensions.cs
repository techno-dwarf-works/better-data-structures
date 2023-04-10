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