using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public static int curHealth = 0;
    public int maxHealth = 50;
    public HealthBar healthBar;
    private bool isInvincible = false;
    private float invincibilityDurSec;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }


    // Update is called once per frame
    //For debug purposes.
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        DamagePlayer(10);
    //    }
    //}

    public void DamagePlayer(int damage)
    {
        if (isInvincible) return;

        curHealth -= damage;
        healthBar.SetHealth(curHealth);
        //death
        if (curHealth < 1)
        {
            SceneManager.LoadScene("Death");
            return;
        }
    }

}
