using System;
using UnityEngine;

namespace Better.DataStructures.Properties
{
    [Serializable]
    public class ReactiveProperty<T>
    {
        public event Action<T> ValueChangedEvent;

        [SerializeField]
        protected T _value;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                SetDirty();
            }
        }

        public ReactiveProperty(T defaultValue = default)
        {
            _value = defaultValue;
        }

        public virtual void SetDirty()
        {
            ValueChangedEvent?.Invoke(Value);
        }
    }
}