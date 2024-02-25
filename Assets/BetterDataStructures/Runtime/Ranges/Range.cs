using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Better.DataStructures.Ranges
{
    [Serializable]
    public class Range<T> : IEquatable<Range<T>>
    {
        [FormerlySerializedAs("min")]
        [SerializeField] private T _min;
        [FormerlySerializedAs("max")]
        [SerializeField] private T _max;

        public Range()
        {
            _min = default;
            _max = default;
        }

        public Range(T min, T max)
        {
            _min = min;
            _max = max;
        }

        public T Min => _min;

        public T Max => _max;

        public bool Equals(Range<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<T>.Default.Equals(_min, other._min) && EqualityComparer<T>.Default.Equals(_max, other._max);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Range<T>)obj);
        }

        public Range<T> UpdateMax(T maxValue)
        {
            return new Range<T>(_min, maxValue);
        }

        public Range<T> UpdateMin(T minValue)
        {
            return new Range<T>(minValue, _max);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<T>.Default.GetHashCode(_min) * 397) ^ EqualityComparer<T>.Default.GetHashCode(_max);
            }
        }
    }
}