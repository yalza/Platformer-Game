using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public float wallSpeed = 3f;
    private Vector2 _walkDirectionVector;

    Rigidbody2D rb;
    TouchingDirections touchingDirections;

    public enum WalkableDirection { Right,Left }
    private WalkableDirection _walkableDirection;
    public WalkableDirection WalkDirection
    {
        get { return _walkableDirection; }
        set
        {
            if(_walkableDirection != value)
            {

                gameObject.transform.localScale *= new Vector2(-1, 1);
                if (value == WalkableDirection.Right)
                {
                    _walkDirectionVector = Vector2.right;
                }
                else if(value == WalkableDirection.Left)
                {
                    _walkDirectionVector = Vector2.left;
                }
            }

            _walkableDirection = value;

        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
    }

    private void FixedUpdate()
    {
        if(touchingDirections.IsGrounded && touchingDirections.IsOnWall)
        {
            FlipDirection();
        }
        rb.velocity = new Vector2(wallSpeed * _walkDirectionVector.x,rb.velocity.y);
    }

    private void FlipDirection()
    {
        if(WalkDirection == WalkableDirection.Left)
        {
            WalkDirection = WalkableDirection.Right;
        }
        else if(WalkDirection == WalkableDirection.Right)
        {
            WalkDirection = WalkableDirection.Left;
        }
    }
}
