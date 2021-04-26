using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health2 : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 50;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    //void Update()
    //For debug purposes.
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        DamagePlayer(10);
    //    }
    //}

    public void DamagePlayer(int damage)
    {
        curHealth -= damage;
        healthBar.SetHealth(curHealth);
    }
}
