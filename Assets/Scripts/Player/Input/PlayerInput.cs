using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Input
{
    public class PlayerInput : MonoBehaviour
    {
        private PlayerInputActions _inputActions;

        public Vector2 Position {  get; private set; }
        public bool IsPressed {  get; private set; }

        private void Awake()
        {
            _inputActions = new PlayerInputActions();
        }

        private void OnEnable()
        {
            _inputActions.Enable();

            _inputActions.Player.TouchPosition.performed += OnMove;

            _inputActions.Player.TouchPress.performed += OnPressedEnter;
            _inputActions.Player.TouchPress.canceled += OnPressedExit;
        }

        private void OnDisable()
        {
            _inputActions.Player.TouchPosition.performed -= OnMove;

            _inputActions.Player.Swipe.performed -= OnPressedEnter;
            _inputActions.Player.Swipe.canceled -= OnPressedExit;

            _inputActions.Disable();
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            Position = context.ReadValue<Vector2>();
        }

        private void OnPressedEnter(InputAction.CallbackContext context)
        {
            IsPressed = true;
        }

        private void OnPressedExit(InputAction.CallbackContext context)
        {
            IsPressed = false;
        }
    }
}