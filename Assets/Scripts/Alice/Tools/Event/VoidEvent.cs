using System;
using UnityEngine;

namespace Alice.Events
{
    [CreateAssetMenu(fileName = "VoidEvent", menuName = "Alice/Events/Void", order = 0 )]
    public class VoidEvent : ScriptableObject, IGameEvent
    {
        private event Action OnEventRaised;

        public void Invoke() => OnEventRaised?.Invoke();

        public void Sub(Action listener) => OnEventRaised += listener;
        public void Unsub(Action listener) => OnEventRaised -= listener;
        public void Clear() => OnEventRaised = null;

#if UNITY_EDITOR
        [SerializeField] private bool manuallyInvokeEvent;

        private void OnValidate()
        {
            if (!manuallyInvokeEvent) return;

            manuallyInvokeEvent = false;

            Invoke();
        }

#endif
    }
}
