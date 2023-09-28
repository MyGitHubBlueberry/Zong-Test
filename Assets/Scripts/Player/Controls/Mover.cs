using System;
using System.ComponentModel;
using Core;
using Core.Input;
using Newtonsoft.Json.Linq;
using Saving;
using TMPro;
using UnityEngine;

namespace Controls
{
    [RequireComponent(typeof(CharacterController))]
    public class Mover : MonoBehaviour, ISaveable
    {
        [SerializeField] float speed = 12f;
        [SerializeField] float gravity = 9.8f;
        [SerializeField] float groundDistance = 0.4f;
        [SerializeField] LayerMask groundMask;
        [SerializeField] float jumpHeight = 3f;

        CharacterController controller;
        GameInput gameInput;
        Vector3 velocity;
        Vector2 moveDirection;
        bool isGrounded, isMoving;


        void Awake()
        {
            controller = GetComponent<CharacterController>();
            gameInput = GetComponent<GameInput>();
        }

        void Start()
        {
            gameInput.OnTryingToJump += Jump;
            gameInput.OnTryingToMove += (moveDir) =>
            {
                isMoving = true;
                moveDirection = moveDir;
            };
            gameInput.OnMovementCanceled += () => isMoving = false;
        }

        private void Jump()
        {
            if (!isGrounded) return;
            velocity.y = Mathf.Sqrt(jumpHeight * 2 * gravity);
        }

        void Update()
        {
            isGrounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);


            if (isMoving) Move(moveDirection);

            ApplyGravity();
        }

        void Move(Vector2 normalizedMoveDirection) //vector normilized on Unity side
        {
            Vector3 direction = transform.right * normalizedMoveDirection.x
                + transform.forward * normalizedMoveDirection.y;

            controller.Move(speed * Time.deltaTime * direction);
        }

        void ApplyGravity()
        {
            if (isGrounded && velocity.y < 0) velocity.y = -gravity;

            velocity.y -= gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
        public JToken CaptureAsJToken()
        {
            return transform.position.ToToken();
        }

        public void RestoreFromJToken(JToken state)
        {
            CharacterController controller = GetComponent<CharacterController>();
            controller.enabled = false;
            transform.position = state.ToVector3();
            controller.enabled = true;
        }
    }
}