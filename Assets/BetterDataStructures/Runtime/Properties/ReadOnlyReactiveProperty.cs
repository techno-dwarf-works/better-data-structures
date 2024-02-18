using System;

namespace Better.DataStructures.Properties
{
    [Serializable]
    public sealed class ReadOnlyReactiveProperty<T>
    {
        private readonly ReactiveProperty<T> _source;

        public T Value => _source.Value;

        public ReadOnlyReactiveProperty(ReactiveProperty<T> source)
        {
            _source = source;
        }

        public void Subscribe(Action<T> action) => _source.Subscribe(action);
        public void SubscribeWithInvoke(Action<T> action) => _source.SubscribeWithInvoke(action);

        public void Unsubscribe(Action<T> action) => _source.Unsubscribe(action);
    }
}