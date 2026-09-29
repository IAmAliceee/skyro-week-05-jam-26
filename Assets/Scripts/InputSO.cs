using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Alice.Input
{
    public class InputSO : ScriptableObject, IDisposable
    {
        private Dictionary<Action<InputAction.CallbackContext>, InputActionType> registeredInputs = new();

        [SerializeField] private InputActionReference inputAction;

        public void Register()
        {
            inputAction.action.Enable();
        }
        
        public void Dispose()
        {
            foreach (var action in registeredInputs.Keys)
            {
                Unsub(action);
            }

            registeredInputs.Clear();
            inputAction.action.Disable();
        }

        public enum InputActionType
        {
            Started,
            Canceled,
            Performed
        }

        public void Sub(Action<InputAction.CallbackContext> action, InputActionType type = InputActionType.Started)
        {
            switch (type)
            {
                case InputActionType.Started:
                    inputAction.action.started += action;
                    break;

                case InputActionType.Canceled:
                    inputAction.action.canceled += action;
                    break;

                case InputActionType.Performed:
                    inputAction.action.performed += action;
                    break;
            }

            registeredInputs[action] = type;
        }

        public void Unsub(Action<InputAction.CallbackContext> action)
        {
            if (!registeredInputs.TryGetValue(action, out var type)) return;

            switch (type)
            {
                case InputActionType.Started:
                    inputAction.action.started -= action;
                    break;

                case InputActionType.Canceled:
                    inputAction.action.canceled -= action;
                    break;

                case InputActionType.Performed:
                    inputAction.action.performed -= action;
                    break;
            }
        }
    }
}