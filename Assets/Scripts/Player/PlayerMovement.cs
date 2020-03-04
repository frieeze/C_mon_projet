using System;
using UnityEngine;
using UnityEngine.Serialization;

// Define all player states
public enum Status
{
    idle,
    crouch,
    run,
    slide
}

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInputs playerInputs = default;
    public CharacterController controller;
    public Status playerStatus { get; private set; }
    public float crouchSpeed = 6f;
    public float runSpeed = 10f;
    public float sprintSpeed = 15f;
    public float groundDistance = 0.4f;
    public float jumpForce = 5f;
    public float downGravity = 5f;
    public int airControl = 5;


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
        _speed = getMaxSpeed();
        _originalCharacterHeight = controller.height;
    }

    private void Update()
    {
        _isGrounded = controller.isGrounded;
        playerStatus = setStatus();
        _speed = getMaxSpeed();
        move();
        crouch();
    }


    private Status setStatus()
    {
        if (_moveDirection == new Vector3(0, -10, 0))
            return Status.idle;
        if (_isGrounded)
        {
            if (playerInputs.crouch && _speed > 9)
                return Status.slide;
            if (playerInputs.crouch)
                return Status.crouch;
        }

        return Status.run;
    }

    // Define player max sspeed based on his status
    private float getMaxSpeed()
    {
        if (playerStatus == Status.crouch)
            return crouchSpeed;
        if (playerInputs.sprint)
            return sprintSpeed;
        return runSpeed;
    }

    private void move()
    {
        float x = playerInputs.moveDirection.x;
        float z = playerInputs.moveDirection.y;
        Vector3 tmpMove = _playerTransform.right * x + _playerTransform.forward * z;
        // If sliding or is in air apply air-control
        if (playerStatus == Status.slide || !_isGrounded)
        {
            _verticalVelocity = isJumping() ? jumpForce : _verticalVelocity - 10 * Time.deltaTime;
            // Reduce air control
            _moveDirection += new Vector3((tmpMove.x * Time.deltaTime * airControl), 0,
                (tmpMove.z * Time.deltaTime * airControl));
        }
        else
        {
            _verticalVelocity = isJumping() ? jumpForce : -10;
            _moveDirection = tmpMove;
        }

        _moveDirection.y = 0;
        _moveDirection.Normalize();
        _moveDirection *= _speed;
        _moveDirection.y = _verticalVelocity;
        controller.Move(_moveDirection * Time.deltaTime);
        playerInputs.jump = false;
    }

    private void crouch()
    {
        if (playerInputs.crouch && !playerInputs.jump)
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

    private bool isJumping()
    {
        return playerInputs.jump && _isGrounded;
    }



    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!_isGrounded && hit.normal.y < 0.1f && playerInputs.jump)
        {
            Debug.DrawRay(hit.point, hit.normal, Color.red, 1.5f);
            _verticalVelocity = jumpForce;
            _moveDirection = Vector3.Reflect(_moveDirection, hit.normal) * _speed;
        }
    }
}