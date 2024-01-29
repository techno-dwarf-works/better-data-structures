using System;
using System.Collections.Generic;
using UnityEngine;

namespace Better.DataStructures.Ranges
{
    [Serializable]
    public class Range<T> : IEquatable<Range<T>>
    {
        [SerializeField] private T min;
        [SerializeField] private T max;

        public Range()
        {
            min = default;
            max = default;
        }

        public Range(T min, T max)
        {
            this.min = min;
            this.max = max;
        }

        public T Min => min;

        public T Max => max;

        public bool Equals(Range<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<T>.Default.Equals(min, other.min) && EqualityComparer<T>.Default.Equals(max, other.max);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Range<T>)obj);
        }

        public Range<T> UpdateMax(T maxValue)
        {
            return new Range<T>(min, maxValue);
        }

        public Range<T> UpdateMin(T minValue)
        {
            return new Range<T>(minValue, max);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<T>.Default.GetHashCode(min) * 397) ^ EqualityComparer<T>.Default.GetHashCode(max);
            }
        }
    }
}