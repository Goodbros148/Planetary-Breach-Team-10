using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 50;
    public HealthBar healthBar;
    

    // Start the game with full health
    void Start()
    {
        curHealth = maxHealth;        
    }

    // Update is called once per frame
    void Update()
    {
        //For debug purposes.
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        DamagePlayer(10);
        //    }
        //
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
    }
    //Damaging the player is controlled here by tags (as of right now)
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Hazard")) //anything tagged as "Hazard" will deal 10 damage to the player
        {
            DamagePlayer(10);
            if (curHealth < 1)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
        if (col.gameObject.CompareTag("PlusHealth")) //anything tagged as "PlusHealth" will heal 10 damage to the player
        {
            DamagePlayer(-5);
        }
    }

    //The damage script
    //I have yet to add an invincibility period that occurs right after the player gets hit.
    public void DamagePlayer(int damage)
    {
        curHealth -= damage;
        healthBar.SetHealth(curHealth);
        //death
        if (curHealth < 1)
        {
            //Debug.Log("Switch scene");
            SceneManager.LoadScene("MainMenu");
        }
    }
}
