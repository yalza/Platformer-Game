using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class FlyingEye : MonoBehaviour
{
    [SerializeField] private float _flightSpeed = 2f;

    [SerializeField] DetectionZone biteDetectionZone;
    [SerializeField] List<Transform> wayPoints;
    Animator animator;
    Rigidbody2D rb;
    Damageable damageable;

    int waypointNum = 0;
 

    private bool _hasTarget = false;
    public bool HasTarget
    {
        get
        {
            return _hasTarget;
        }
        private set
        {
            _hasTarget = value;
            animator.SetBool(CONSTANT.hasTarget, value);
        }
    }

    public bool CanMove
    {
        get
        {
            return animator.GetBool(CONSTANT.canMove);
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        damageable = GetComponent<Damageable>();
    }

    private void Start()
    {
        waypointNum = 0;
    }

    private void Update()
    {
        HasTarget = biteDetectionZone.detectionColliders.Count > 0; 
    }

    private void FixedUpdate()
    {
        if(damageable.IsAlive)
        {
            if(CanMove)
            {
                Flight();
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    private void Flight()
    {

        FlipDirection();
        if (waypointNum == wayPoints.Count)
        {
            waypointNum = 0;
        }

        Vector3 direction = (wayPoints[waypointNum].position - transform.position).normalized;
        rb.velocity = direction * _flightSpeed;
        if (Vector3.Distance(wayPoints[waypointNum].position,transform.position) < 0.2f)
        {
            waypointNum++;
        }

        
    }

    private void FlipDirection()
    {
        if(rb.velocity.x > 0f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
