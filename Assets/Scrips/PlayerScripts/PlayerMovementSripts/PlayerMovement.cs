using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Lumin;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed, _rotateSpeed, _jumpHeight, _jumpLenght, _duration, _acceliration;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _player;
    [SerializeField] private PlayerMoving _playerMoving;
    [SerializeField] private PlayerRotating _playerRotating;
    [SerializeField] private PlayerJumping _playerJumping;
    [SerializeField] private AnimationCurve _yAnimation;

    


    private DirectionState _directionState = DirectionState.Forward;
    private MoveState _moveState;
    private JumpState _jumpState;
    private IdleState _idleState;
    private PlayerStateInAir _playerStateInAir;
    private Animator _animator;
    private float _walkTime = 0, _walkCooldown = 0.3f, _jumpCooldown;
    private bool _landed;




    private Vector2 _moveDirection;
    private Vector2 _viewDirection;
    private InputActions _inputActions;


    private void Awake()
    {
        _inputActions = new InputActions();
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _player = gameObject.GetComponent<Transform>();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }



    void Update()
    {
        _moveDirection = _inputActions.PlayerControl.Move.ReadValue<Vector2>();
        MoveStateController(_moveDirection);
        CallMove(_moveDirection);
        SelectCurrentAnimation();
        _viewDirection = _inputActions.PlayerControl.Rotate.ReadValue<Vector2>();
        CallRotate(_viewDirection);
        JumpCondition();
        if (_idleState == IdleState.Idle)
        {
            switch (_directionState)
            {
                case DirectionState.Forward:
                    _rigidbody.velocity = _speed * Time.deltaTime * Vector3.forward;
                    break;
                case DirectionState.Backward:
                    _rigidbody.velocity = _speed * Time.deltaTime * -Vector3.forward;
                    break;
                case DirectionState.Right:
                    _rigidbody.velocity = _speed * Time.deltaTime * Vector3.right;
                    break;
                case DirectionState.Left:
                    _rigidbody.velocity = _speed * Time.deltaTime * -Vector3.right;
                    break;
                default:
                    break;
            }
            _walkTime -= Time.deltaTime;
            if (_walkTime <= 0)
            {
                _idleState = IdleState.Idle;
            }
        }
    }

    private void CallMove(Vector2 moveDirection)
    {
        if (_idleState != IdleState.Idle)
        {
            Vector3 currentMoveDirction = ComputeCurrentMoveDirection(moveDirection, _camera);
            _playerMoving.Move(currentMoveDirction, _camera, _rigidbody, _speed);
            _walkTime = _walkCooldown;
        }
    }

    private void CallRotate(Vector2 viewDirection)
    {
        if (_idleState != IdleState.Idle)
        {
            _playerRotating.Rotate(viewDirection, _camera, _player, _rotateSpeed);
        }
    }

    private void MoveStateController(Vector2 playerMoveCondition)
    {
        if (playerMoveCondition != Vector2.zero)
        {
            _idleState = IdleState.NotIdle;
        }
        else
        {
            _idleState = IdleState.Idle;
        }
    }

    private void JumpCondition()
    {
        if (_playerStateInAir == PlayerStateInAir.InAir)
        {
            _jumpState = JumpState.InJump;
        }
        else
        {
            _jumpState = JumpState.NotInJump;
        }
    }

    private void SelectCurrentAnimation()
    {
        if(_idleState == IdleState.Idle)
        {
            _animator.SetBool("IsIdle", true);

            if (_moveState == MoveState.Walk)
            {
                _animator.SetBool("IsWalking", false);
            }
            else
            {
                _animator.SetBool("IsRunning", false);
            }
        }
        if (_idleState == IdleState.NotIdle)
        {
            _animator.SetBool("IsIdle", false);
            if (_moveState == MoveState.Walk)
            {
                _animator.SetBool("IsRunning", false);
                _animator.SetBool("IsWalking", true);
            }
            else if (_moveState == MoveState.Sprint)
            {
                _animator.SetBool("IsWalking", false);
                _animator.SetBool("IsRunning", true);
            }
        }
       if(_jumpState == JumpState.InJump)
        {
            _animator.SetBool("IsJumping", true);
        }
        else if (_jumpState == JumpState.NotInJump)
        {
            _animator.SetBool("IsJumping", false);
        }
    }

   



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _playerStateInAir = PlayerStateInAir.NotInAir;
            _landed = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.layer == 6)
        {
            _playerStateInAir = PlayerStateInAir.InAir;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.layer == 6)
        {
            _playerStateInAir = PlayerStateInAir.NotInAir;
        }
    }

    public enum DirectionState
    {
        Forward,
        Backward,
        Left,
        Right
    }
    private enum MoveState
    {
        Walk,
        Sprint,
    }
    private enum JumpState
    {
        InJump,
        NotInJump
    }
    private enum PlayerStateInAir
    {
        InAir,
        NotInAir
    }
    private enum IdleState
    {
        Idle,
        NotIdle
    }

    private Vector3 ComputeCurrentMoveDirection(Vector2 moveDirection, Transform camera)
    {
        Vector3 currentPlayerMoveDirection = new Vector3(moveDirection.x, 0f, moveDirection.y);
        Vector3 transformedCameraZoneDirection = camera.TransformDirection(currentPlayerMoveDirection);
        Vector3 currentMoveDirection = new Vector3(transformedCameraZoneDirection.x, 0f, transformedCameraZoneDirection.z);

        return currentMoveDirection;
    }

    private IEnumerator JumpByTime(float duration, Vector3 target)
    {
        var expiredSeconds = 0f;
        var progress = 0f;

        Vector3 startPosirion = _rigidbody.position;

        while (progress < 1)
        {
            expiredSeconds += Time.deltaTime;
            progress = expiredSeconds / duration;

            if (_landed != true)
            {
                Vector3 lerpedvector = Vector3.Lerp(startPosirion.normalized, target, progress);

                //_playerJumping.Jump(_rigidbody, startPosirion + new Vector3(0, _yAnimation.Evaluate(progress) * _jumpHeight, 0) + new Vector3(lerpedvector.x, 0f, lerpedvector.z));

                Vector3 currentposition = _rigidbody.position;
                _playerJumping.Jump(_rigidbody, new Vector3(currentposition.x, startPosirion.y, currentposition.z) + new Vector3(0, _yAnimation.Evaluate(progress) * _jumpHeight, 0));
            }
            yield return null;
        }
    }

    public void CallJump()
    {
        if (_jumpState != JumpState.InJump)
        {
            Vector3 targert = ComputeCurrentMoveDirection(_moveDirection, _camera) * _jumpLenght;
            _landed = false;
            StartCoroutine(JumpByTime(_duration, targert));
        }
    }


    public void SprintCall()
    {
        if (_moveState == MoveState.Walk)
        {
            _speed = _speed * _acceliration;
            _jumpLenght = _jumpLenght * _acceliration;
            _moveState = MoveState.Sprint;
        }
        else 
        {
            _speed = _speed / _acceliration;
            _jumpLenght = _jumpLenght / _acceliration;
            _moveState = MoveState.Walk;
        }
    }


    private void OnDisable()
    {
        _inputActions.Disable();
    }

}
