using System;
using UnityEngine;

namespace Alice.Events
{
    public class GameEvent<T> : ScriptableObject, IGameEvent
    {
        protected event Action<T> OnEventRaised;

        public void Raise(T value) => OnEventRaised?.Invoke(value);

        public void Sub(Action<T> listener) => OnEventRaised += listener;
        public void Unsub(Action<T> listener) => OnEventRaised -= listener;
        public void Clear() => OnEventRaised = null;

#if UNITY_EDITOR
        [SerializeField] private bool manuallyInvokeEvent;
        [SerializeField] private T invokeValue;

        private void OnValidate()
        {
            if (!manuallyInvokeEvent) return;

            manuallyInvokeEvent = false;

            Raise(invokeValue);
        }

#endif
    }
}