using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private float _healthPickup = 20f;
    private Vector3 spinRotationSpeed = new Vector3(0, 180, 0);

    private void Update()
    {
        transform.Rotate(spinRotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();
        if (damageable)
        {
            damageable.Heal(_healthPickup);
            Destroy(gameObject);
        }
    }
}
