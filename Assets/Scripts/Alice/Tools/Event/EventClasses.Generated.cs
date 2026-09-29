using UnityEngine;

namespace Alice.Events
{
    [CreateAssetMenu(fileName = "BoolEvent", menuName = "Alice/Events/Bool", order = 1 )] public sealed class BoolEvent : GameEvent<bool> {}
    [CreateAssetMenu(fileName = "IntEvent", menuName = "Alice/Events/Int", order = 2 )] public sealed class IntEvent : GameEvent<int> {}
    [CreateAssetMenu(fileName = "FloatEvent", menuName = "Alice/Events/Float", order = 3 )] public sealed class FloatEvent : GameEvent<float> {}
    [CreateAssetMenu(fileName = "Vector2Event", menuName = "Alice/Events/Vector2", order = 4 )] public sealed class Vector2Event : GameEvent<UnityEngine.Vector2> {}
    [CreateAssetMenu(fileName = "Vector3Event", menuName = "Alice/Events/Vector3", order = 5 )] public sealed class Vector3Event : GameEvent<UnityEngine.Vector3> {}
    [CreateAssetMenu(fileName = "StringEvent", menuName = "Alice/Events/String", order = 6 )] public sealed class StringEvent : GameEvent<string> {}
}