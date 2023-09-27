using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Input
{
    public class GameInput : MonoBehaviour
    {
        public event Action<Vector2> OnTryingToMove;
        public event Action OnTryingToJump;
        public event Action OnMovementCanceled;
        public event Action OnTryingToPickup;
        public event Action OnTryingToDrop;
        public event Action OnTryingToToggleInventory;

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
            inputActions.Player.ToggleInventory.performed
                += _ => OnTryingToToggleInventory?.Invoke();
         }

        void OnEnable() => inputActions.Enable();

        void OnDisable() => inputActions.Disable();
    }
}