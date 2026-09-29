using Alice.Events;
using Alice.Input;
using Alice.Variables;
<<<<<<< Updated upstream
=======
using static UnityEngine.Time;
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        private bool dashEnabled;
=======
        private bool dashEnabled = true;
>>>>>>> Stashed changes

        private void OnEnable()
        {
            moveInput.Sub(OnMoveInput, InputSO.InputActionType.Performed);
            dashInput.Sub(OnDashInput);
        }

        private void OnMoveInput(InputAction.CallbackContext ctx) => lastMoveInput = ctx.ReadValue<Vector2>();

        private void OnDashInput(InputAction.CallbackContext ctx)
        {
<<<<<<< Updated upstream
            if(!dashEnabled) return;
=======
            if(!dashEnabled || dashActive) return;
>>>>>>> Stashed changes
            if (Time.timeSinceLevelLoad < waitUntilTime) return;

            waitUntilTime = Time.timeSinceLevelLoad + dashCooldown;

            dashTimeLeft = dashDuration;
            SetGravityOn.Invoke(false);
<<<<<<< Updated upstream
=======

            dashActive = true;
>>>>>>> Stashed changes
        }

        private void Update()
        {
            if (!dashActive || !dashEnabled) return;
<<<<<<< Updated upstream

            Vector3 dashDisplacement = Vector3.right * (dashSpeed * lastMoveInput * Time.deltaTime);
            transform.position += dashDisplacement;
=======
            if (dashTimeLeft <= 0f)
            {
                dashActive = false;
                SetGravityOn.Invoke(true);
                waitUntilTime = Time.timeSinceLevelLoad + dashCooldown;
                return;
            }

            Vector3 dashDisplacement = new Vector3(1f, 1f, 0f) * (dashSpeed * lastMoveInput * Time.deltaTime);
            transform.position += dashDisplacement;
            dashTimeLeft -= Time.deltaTime;
>>>>>>> Stashed changes
        }
    }
}