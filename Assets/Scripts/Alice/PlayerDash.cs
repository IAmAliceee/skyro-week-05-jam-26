using Alice.Events;
using Alice.Input;
using Alice.Variables;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Alice.Movement
{
    public class PlayerDash : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;

        [Header("Inputs")]
        [SerializeField] private InputSO moveInput;
        [SerializeField] private InputSO dashInput;

        [Header("Variables")]
        [SerializeField] private FloatVariable dashCooldown;
        [SerializeField] private FloatVariable dashDuration;
        [SerializeField] private FloatVariable dashSpeed;

        [Header("Events")]
        [SerializeField] private BoolEvent SetGravityOn;

        private Vector2 lastMoveInput;
        private float waitUntilTime = 0f;
        private float dashTimeLeft = 0f;

        private bool dashActive;
        private bool dashEnabled;

        private void OnEnable()
        {
            moveInput.Sub(OnMoveInput, InputSO.InputActionType.Performed);
            dashInput.Sub(OnDashInput);
        }

        private void OnMoveInput(InputAction.CallbackContext ctx) => lastMoveInput = ctx.ReadValue<Vector2>();

        private void OnDashInput(InputAction.CallbackContext ctx)
        {
            if(!dashEnabled) return;
            if (Time.timeSinceLevelLoad < waitUntilTime) return;

            waitUntilTime = Time.timeSinceLevelLoad + dashCooldown;

            dashTimeLeft = dashDuration;
            SetGravityOn.Invoke(false);
        }

        private void Update()
        {
            if (!dashActive || !dashEnabled) return;

            Vector3 dashDisplacement = Vector3.right * (dashSpeed * lastMoveInput * Time.deltaTime);
            transform.position += dashDisplacement;
        }
    }
}