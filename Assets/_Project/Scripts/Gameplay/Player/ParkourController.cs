using UnityEngine;
using UnityEngine.InputSystem;
namespace Skybound.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class ParkourController : MonoBehaviour
    {
        [SerializeField] private float walkSpeed = 5f, sprintMultiplier = 1.6f, jumpVelocity = 7f, gravity = -20f, doubleJumpMultiplier = 0.8f;
        [SerializeField] private bool doubleJumpUnlocked, glideUnlocked;
        [SerializeField] private float glideFallRate = -2f;
        [SerializeField] private Transform cameraTransform;
        private CharacterController _cc;
        private Vector2 _moveInput;
        private bool _sprint, _jumpHeld;
        private float _yVel;
        private int _airJumps;
        private bool _isGliding;

        private void Awake() => _cc = GetComponent<CharacterController>();
        public void OnMove(InputAction.CallbackContext c) => _moveInput = c.ReadValue<Vector2>();
        public void OnSprint(InputAction.CallbackContext c) => _sprint = c.ReadValueAsButton();
        public void OnJump(InputAction.CallbackContext c)
        {
            if (c.performed)
            {
                if (_cc.isGrounded) { _yVel = jumpVelocity; _airJumps = 0; }
                else if (doubleJumpUnlocked && _airJumps < 1) { _yVel = jumpVelocity * doubleJumpMultiplier; _airJumps++; }
            }
            _jumpHeld = c.ReadValueAsButton();
        }

        private void Update()
        {
            var fwd = cameraTransform ? cameraTransform.forward : Vector3.forward;
            var right = cameraTransform ? cameraTransform.right : Vector3.right;
            fwd.y = 0; right.y = 0; fwd.Normalize(); right.Normalize();
            var dir = fwd * _moveInput.y + right * _moveInput.x;
            float speed = walkSpeed * (_sprint ? sprintMultiplier : 1f);
            _isGliding = glideUnlocked && !_cc.isGrounded && _jumpHeld && _yVel < 0;
            _yVel = _cc.isGrounded ? -1f : _yVel + (_isGliding ? glideFallRate : gravity) * Time.deltaTime;
            _cc.Move((dir * speed + Vector3.up * _yVel) * Time.deltaTime);
            if (dir.sqrMagnitude > 0.01f) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 12f * Time.deltaTime);
        }

        public void UnlockDoubleJump() => doubleJumpUnlocked = true;
        public void UnlockGlide() => glideUnlocked = true;
    }
}
