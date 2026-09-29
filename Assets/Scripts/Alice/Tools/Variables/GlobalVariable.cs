using System;
using UnityEngine;

namespace Alice.Variables
{
    public abstract class GlobalVariable<T> : ScriptableObject
    {
        [field: SerializeField] public bool IsReadOnly { get; protected set; }
        [SerializeField] protected T _value;

        public T Value
        {
            get => _value;
            set
            {
                if(IsReadOnly) return;
                T previous = _value;
                _value = value;

                OnChanged?.Invoke(new UpdatedValue(previous, _value));
            }
        }

        [Serializable]
        public struct UpdatedValue
        {
            public T previous;
            public T current;

            public UpdatedValue(T previous, T current)
            {
                this.previous = previous;
                this.current = current;
            }
        }

        public event Action<UpdatedValue> OnChanged;

        public static implicit operator T(GlobalVariable<T> variable) => variable.Value;
    }
}