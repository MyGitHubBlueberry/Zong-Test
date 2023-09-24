using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core
{
    public class GameInput : MonoBehaviour
    {
        public event Action<Vector2> OnTryingToMove;
        public event Action OnTryingToJump;
        public event Action OnMovementCanceled;
        public event Action OnTryingToPickup;
        public event Action OnTryingToDrop;

        public static Vector2 MousePositionDelta
        {
            get => Mouse.current.delta.ReadValue();
        }

        private InputActions inputActions;


        void Awake()
        {
            inputActions = new InputActions();

            inputActions.Player.Movement.performed
                += ctx => OnTryingToMove?.Invoke(ctx.ReadValue<Vector2>());
            inputActions.Player.Movement.canceled
                += _ => OnMovementCanceled?.Invoke();
            inputActions.Player.Jump.performed
                += _ => OnTryingToJump?.Invoke();
            inputActions.Player.Pickup.performed
                += _ => OnTryingToPickup?.Invoke();
            inputActions.Player.Drop.performed
                += _ => OnTryingToDrop?.Invoke();
        }

        void OnEnable() => inputActions.Enable();

        void OnDisable() => inputActions.Disable();
    }
}