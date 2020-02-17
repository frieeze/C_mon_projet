using System;
using UnityEngine;

// Define all player states
public enum Status { idle, crouch, run, slide }
public class PlayerMovement : MonoBehaviour
{
   [SerializeField]
   private PlayerInputs _playerInputs = default;
   public CharacterController controller;
   public Status playerStatus { get; private set; }
   public float crouchSpeed = 6f;
   public float runSpeed = 8f;
   public float sprintSpeed = 12f;
   public float groundDistance = 0.4f;
   public float jumpForce = 5f;
   public float downGravity = 5f;
   public int airControl = 5;
   public LayerMask groundMask;
   public LayerMask wallMask;


   private Transform _playerTransform;
   private Vector3 _velocity;
   private Vector3 _moveDirection;
   private Vector3 _wallNormal;
   private bool _isGrounded;
   private float _speed;
   private float _originalCharacterHeight;
   private Vector3 _preJumpMovement;
   private RaycastHit _wallJumpRaycastHit;

   private float _verticalVelocity;

   // Can wall jump
   private bool _wallJump;

   private void Awake()
   {
      playerStatus = Status.idle;
      _playerTransform = transform;
      _speed = runSpeed;
      _originalCharacterHeight = controller.height;
   }

   private void Update()
   {
      _isGrounded = controller.isGrounded;
      _speed = getCurrentSpeed();
      //_wallJump = isOnWall();
      // resetGravity();
      move();
      // jump();
      crouch();
   }

   // Define player speed based on his status
   private float getCurrentSpeed()
   {
      if (_playerInputs.crouch && !_isGrounded)
         return crouchSpeed;
      if (_playerInputs.sprint)
         return sprintSpeed;
      return runSpeed;
   }

   private void move()
   {
      float x = _playerInputs.moveDirection.x;
      float z = _playerInputs.moveDirection.y;
      Vector3 tmpMove = _playerTransform.right * x + _playerTransform.forward * z;
      if (_isGrounded)
      {
         _verticalVelocity = -10;
         _moveDirection = tmpMove;
         if (_playerInputs.jump)
         {
            _verticalVelocity = jumpForce;
         }
      }
      else
      {
         _verticalVelocity -= 10 * Time.deltaTime;
         // Reduce air control
         _moveDirection += new Vector3((tmpMove.x * Time.deltaTime * airControl), 0, (tmpMove.z * Time.deltaTime * airControl));
      }
      _moveDirection.y = 0;
      _moveDirection.Normalize();
      _moveDirection *= _speed;
      _moveDirection.y = _verticalVelocity;
      controller.Move(_moveDirection * Time.deltaTime);
      _playerInputs.jump = false;

   }

   private void crouch()
   {
      if (_playerInputs.crouch)
      {
         controller.height = _originalCharacterHeight / 2f;
         playerStatus = Status.crouch;
      }
      else
      {
         controller.height = _originalCharacterHeight;
         playerStatus = Status.idle;
      }
   }

   private void resetGravity()
   {
      if (_isGrounded && _velocity.y < 0)
      {
         _velocity = Physics.gravity;
      }
   }


   private void OnControllerColliderHit(ControllerColliderHit hit)
   {
      if (!_isGrounded && hit.normal.y < 0.1f && _playerInputs.jump)
      {
         Debug.DrawRay(hit.point, hit.normal, Color.red, 1.5f);
         _verticalVelocity = jumpForce;
         _moveDirection = Vector3.Reflect(_moveDirection, hit.normal) * _speed;
      }
   }
   private Vector3 wallJumpAngle()
   {
      return Vector3.zero;
   }

}
