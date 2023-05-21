using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class HealthBar : MonoBehaviour
{
    public TMP_Text healthText;
    public Slider healthSlider;
    Damageable playerDamageable;

    private void Awake()
    {
        
    }

    private void Start()
    {
        playerDamageable = GameObject.FindGameObjectWithTag("Player").GetComponent<Damageable>();
        healthSlider.value = playerDamageable.MaxHealth;
        healthText.text = "HP " + playerDamageable.Health.ToString() + " / " + playerDamageable.MaxHealth.ToString();
    }

    private void Update()
    {
        healthSlider.value = playerDamageable.Health / playerDamageable.MaxHealth;
        healthText.text = "HP " + playerDamageable.Health.ToString() + " / " + playerDamageable.MaxHealth.ToString();
    }
}
