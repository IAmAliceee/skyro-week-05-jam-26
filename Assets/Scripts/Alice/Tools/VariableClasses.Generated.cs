using UnityEngine;

namespace Alice.Variables
{
    [CreateAssetMenu(fileName = "BoolVariable", menuName = "Alice/Variables/Bool", order = 0 )] public sealed class BoolVariable : GlobalVariable<bool> {}
    [CreateAssetMenu(fileName = "IntVariable", menuName = "Alice/Variables/Int", order = 1 )] public sealed class IntVariable : GlobalVariable<int> {}
    [CreateAssetMenu(fileName = "FloatVariable", menuName = "Alice/Variables/Float", order = 2 )] public sealed class FloatVariable : GlobalVariable<float> {}
    [CreateAssetMenu(fileName = "Vector2Variable", menuName = "Alice/Variables/Vector2", order = 3 )] public sealed class Vector2Variable : GlobalVariable<UnityEngine.Vector2> {}
    [CreateAssetMenu(fileName = "Vector3Variable", menuName = "Alice/Variables/Vector3", order = 4 )] public sealed class Vector3Variable : GlobalVariable<UnityEngine.Vector3> {}
    [CreateAssetMenu(fileName = "StringVariable", menuName = "Alice/Variables/String", order = 5 )] public sealed class StringVariable : GlobalVariable<string> {}
    [CreateAssetMenu(fileName = "GameObjectVariable", menuName = "Alice/Variables/GameObject", order = 6 )] public sealed class GameObjectVariable : GlobalVariable<UnityEngine.GameObject> {}
}