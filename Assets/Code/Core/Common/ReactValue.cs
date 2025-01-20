using System;

namespace Code.Core.Common
{
    public sealed class ReactValue<T> : IDisposable
    {
        private T _value;

        public ReactValue(T value) : base()
        {
            _value = value;
            ValueChanged = vaule => { };
        }

        public ReactValue()
        {
            ValueChanged = vaule => { };
        }

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                ValueChanged.Invoke(_value);
            }
        }

        public event Action<T> ValueChanged;

        public void Dispose()
        {
            ValueChanged = null;

            GC.SuppressFinalize(this);
        }
    }
}
