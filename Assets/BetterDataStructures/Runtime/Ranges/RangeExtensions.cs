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
            return Math.Clamp(value, range.Min, range.Max);
        }
        
        public static byte Clamp(this Range<byte> range, byte value)
        {
            return Math.Clamp(value, range.Min, range.Max);
        }
    }
}