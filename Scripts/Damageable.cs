using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public UnityEvent<float, Vector2> damageableHit;
    

    Animator animator;

    [SerializeField] private float _invincibleTime = 0.5f;
    [SerializeField] private float _maxHealth = 100;
    public float MaxHealth
    {
        get { return _maxHealth; }
        set
        {
            _maxHealth = value;
        }
    }

    private float _health = 100;
    public float Health
    {
        get { return _health; }
        set
        {
            _health = value;
            if(_health <= 0)
            {
                IsAlive = false;
            }
        }
    }

    private bool _isAlive = true;
    public bool IsAlive
    {
        get { return _isAlive; }
        set
        {
            _isAlive = value;
            animator.SetBool(CONSTANT.isAlive, value);
        }
    }

    public bool IsHit
    {
        get
        {
            return animator.GetBool(CONSTANT.isHit);
        }
        private set
        {
            animator.SetBool(CONSTANT.isHit, value);
        }
    }

    public bool LockVelocity
    {
        get
        {
            return animator.GetBool(CONSTANT.lockVelocity);
        }
        set
        {
            animator.SetBool(CONSTANT.lockVelocity, value);
        }
    }


    private bool _isInvincible = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        
    }
    public void Hit(float damage, Vector2 knockback)
    {
        if(IsAlive && !_isInvincible)
        {
            Health -= damage;
            _isInvincible = true;
            damageableHit?.Invoke(damage, knockback);
            CharacterEvents.characterDamaged(gameObject, damage);
            animator.SetTrigger(CONSTANT.hit);
            StartCoroutine(InvincibleTime(_invincibleTime));
            
        }
    }

    public void Heal(float healthRestore)
    {
        if(IsAlive)
        {
            Health = Mathf.Min(Health + healthRestore,MaxHealth);
            CharacterEvents.characterHealed(gameObject, healthRestore);
        }
    }

    private IEnumerator InvincibleTime(float time)
    {
        yield return new WaitForSeconds(time);
        _isInvincible = false;
    }
}
