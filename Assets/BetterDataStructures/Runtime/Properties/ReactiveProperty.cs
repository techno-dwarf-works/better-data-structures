using System;
using UnityEngine;

namespace Better.DataStructures.Properties
{
    [Serializable]
    public class ReactiveProperty<T>
    {
        private event Action<T> ValueChangedEvent;
        private ReadOnlyReactiveProperty<T> _cachedReadOnly;

        [SerializeField] protected T _value;

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

        public virtual void Subscribe(Action<T> action)
        {
            ValueChangedEvent += action;
        }

        public virtual void SubscribeWithInvoke(Action<T> action)
        {
            Subscribe(action);
            action?.Invoke(Value);
        }

        public virtual void Unsubscribe(Action<T> action)
        {
            ValueChangedEvent -= action;
        }

        public ReadOnlyReactiveProperty<T> AsReadOnly()
        {
            _cachedReadOnly ??= new ReadOnlyReactiveProperty<T>(this);
            return _cachedReadOnly;
        }
    }
}