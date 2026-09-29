using UnityEngine;
using UnityEngine.Events;

namespace Alice.Events
{
    public class UnityGameEventBool : MonoBehaviour
    {
        [SerializeField] private GameEvent<bool> gameEvent;
        [SerializeField] private UnityEvent unityEventTrue;
        [SerializeField] private UnityEvent unityEventFalse;

        private void OnEnable() => gameEvent.Sub(OnGameEvent);
        private void OnDisable() => gameEvent.Unsub(OnGameEvent);

        private void OnGameEvent(bool b)
        {
            (b ? unityEventTrue : unityEventFalse).Invoke();
        }
    }
}