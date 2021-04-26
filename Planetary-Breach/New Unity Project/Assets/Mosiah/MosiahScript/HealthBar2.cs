using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar2 : MonoBehaviour
{
    public Slider healthBar2;
    public Health playerHealth;

    //Align health with the UI elements
    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        healthBar2 = GetComponent<Slider>();
        healthBar2.maxValue = playerHealth.maxHealth;
        healthBar2.value = playerHealth.maxHealth;
    }

    public void SetHealth(int hp)
    {
        healthBar2.value = hp;
    }
}
