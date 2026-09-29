using UnityEngine;
using UnityEngine.Events;

namespace Alice.Events
{
    public class UnityGameEvent<T> : MonoBehaviour
    {
        [SerializeField] private GameEvent<T> gameEvent;
        [SerializeField] private UnityEvent<T> unityEvent;

        private void OnEnable() => gameEvent.Sub(unityEvent.Invoke);
        private void OnDisable() => gameEvent.Unsub(unityEvent.Invoke);
    }
}