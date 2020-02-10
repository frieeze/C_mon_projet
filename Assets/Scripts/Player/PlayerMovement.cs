using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public CharacterController controller;
        public float speed = 12f;
        public float gravity = -9.81f;

        public Transform groundCheck;
        public float groundDistance = 0.4f;
        public LayerMask groundMask;
        public float jumpHeight = 3f;

        private Transform _playerTransform;
        private Vector3 _velocity;
        private bool _isGrounded;

        // Can wall jump
        private bool _wallJump;

        // New input system
        private InputMaster _controls;

        // Move Direction
        private Vector2 _moveDirection;
        
        // Jump Button
        private bool _jump;
        
        //  Saving Velocity to Wall jump
        private Vector3 _savedVelocity;

        private void Awake()
        {
            _playerTransform = transform;
            _controls = new InputMaster();
            _controls.Player.Movement.performed += ctx => _moveDirection = ctx.ReadValue<Vector2>();
            _controls.Player.Jump.performed += _ => _jump = true;
        }

        private void Update()
        {
            _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (_isGrounded && _velocity.y < 0)
            {
                _velocity.y = gravity;
            }

            float x = _moveDirection.x;
            float z = _moveDirection.y;

            Vector3 move = _playerTransform.right * x + _playerTransform.forward * z;

            controller.Move(move * (speed * Time.deltaTime));

            if (_jump == true)
            {
                if (_isGrounded || _wallJump)
                {
                    _velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
                }
            }


            _jump = false;
            _wallJump = false;

            _velocity.y += gravity * Time.deltaTime;
            controller.Move(_velocity * Time.deltaTime);
        }


        private void OnEnable()
        {
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            _wallJump = true;
        }
    }
}