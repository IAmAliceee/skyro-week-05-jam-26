using Alice.Input;
using UnityEngine;

namespace Alice.Input
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private InputSO[] inputs;

        private void OnEnable()
        {
            foreach (var input in inputs)
            {
                input.Register();
            }
        }

        private void OnDisable()
        {
            foreach (var input in inputs)
            {
                input.Dispose();
            }
        }
    }
}