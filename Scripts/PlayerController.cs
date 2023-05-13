using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private float _walkSpeed = 100f;
    private float _runSpeed = 200f;
    public float CurrentMoveSpeed
    {
        get
        {
            if (IsMoving)
            {
                if (IsRunning) return _runSpeed;
                else return _walkSpeed;
            }
            else return 0;
        }
    }

    private bool _isMoving = false;
    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }
        private set
        {
            _isMoving = value;
            animator.SetBool(CONSTANT.isMoving, value);
        }
    }

    private bool _isRunning = false;
    public bool IsRunning
    {
        get
        {
            return _isRunning;
        }

        private set
        {
            _isRunning = value;
            animator.SetBool(CONSTANT.isRunning, value);
        }
    }

    private bool _isFacingRight = true;
    public bool IsFacingRight
    {
        get
        {
            return _isFacingRight;
        }
        private set
        {
            if(_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
        }
    }


    private Vector2 _moveInput;
    Rigidbody2D rb;
    Animator animator;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        
    }

    
    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(_moveInput.x * CurrentMoveSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();

        IsMoving = _moveInput != Vector2.zero;

        SetFacingDirection(_moveInput);

    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if(moveInput.x > 0 && !IsFacingRight)
        {
            IsFacingRight = true;
        }
        else if(IsFacingRight && moveInput .x< 0)
        {
            IsFacingRight = false;
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsRunning = true;
        }
        else if (context.canceled)
        {
            IsRunning = false;
        }
    }
}
