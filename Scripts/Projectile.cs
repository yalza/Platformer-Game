using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _arrowDamage;
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private Vector2 _knockback = new Vector2(1, 1);

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(_moveSpeed * transform.localScale.x,rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();
        if(damageable != null)
        {
            Vector2 delivedKnockback = transform.localScale.x > 0 ? _knockback : new Vector2(-_knockback.x, _knockback.y);
            if (damageable != null)
            {
                damageable.Hit(_arrowDamage, delivedKnockback);
                Destroy(gameObject);
            }
        }
    }
}
