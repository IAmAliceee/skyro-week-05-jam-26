using UnityEngine;
using UnityEngine.Events;

namespace Alice.Events
{
    public class UnityGameEventVoid : MonoBehaviour
    {
        [SerializeField] private VoidEvent gameEvent;
        [SerializeField] private UnityEvent unityEvent;

        private void OnEnable() => gameEvent.Sub(unityEvent.Invoke);
        private void OnDisable() => gameEvent.Unsub(unityEvent.Invoke);
    }
}