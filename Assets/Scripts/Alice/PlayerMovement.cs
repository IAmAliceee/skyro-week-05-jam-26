using Alice.Events;
using Alice.Input;
using Alice.Variables;
using UnityEngine;

namespace Alice.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private InputSO moveInput;
        [SerializeField] private FloatVariable playerSpeed;

        [Header("Events")]
        [SerializeField] private BoolEvent setMovementOn;

        private bool movementEnabled = true;

        private void OnEnable() => setMovementOn.Sub(OnSetMovementOn);
        private void OnDisable() => setMovementOn.Unsub(OnSetMovementOn);
        private void OnSetMovementOn(bool b) => movementEnabled = b;

        private void Update()
        {
            if(!movementEnabled) return;

            var moveDisplacement = Vector3.right * (moveInput.ReadValue<Vector2>().x * playerSpeed * Time.deltaTime);
            transform.position = transform.position + moveDisplacement;
        }
    }
}