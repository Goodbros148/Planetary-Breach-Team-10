﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 50;
    public HealthBar healthBar;
    private bool isNotInvincible = true;
    [SerializeField]
    private float invincibilityDurationSeconds;
    public Color myColor;
    public Color myDamageColor;
    SpriteRenderer myRenderer;
    // Start the game with full health
    void Start()
    {
        curHealth = maxHealth;
        myRenderer = GetComponent<SpriteRenderer>();
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
        if (col.gameObject.CompareTag("Hazard")&& isNotInvincible) //anything tagged as "Hazard" will deal 10 damage to the player
        {
            DamagePlayer(10);
            StartCoroutine(BecomeTemporarilyInvincible());
            if (curHealth < 1)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
            if (col.CompareTag("Bullet") && isNotInvincible)
            {
                Destroy(col.gameObject);
                DamagePlayer(5);
                StartCoroutine(BecomeTemporarilyInvincible());
                if (curHealth < 1)
                {
                    SceneManager.LoadScene("GameOver");
                }
            }
        if (col.gameObject.CompareTag("PlusHealth")) //anything tagged as "PlusHealth" will heal 10 damage to the player
        {
            DamagePlayer(-5);
        }
    }

    //The damage script
    //I have yet to add an invincibility period that occurs right after the player gets hit.

    private IEnumerator BecomeTemporarilyInvincible() //Invunerability frames used for making player invulnerable to attacks.
    {
        Debug.Log("Player turned invincible!");
        isNotInvincible = false;
        myRenderer.material.color = myDamageColor;
        yield return new WaitForSeconds(invincibilityDurationSeconds);
        myRenderer.material.color = myColor;
        isNotInvincible = true;
        Debug.Log("Player is no longer invincible!");
    }
    public void DamagePlayer(int damage)
    {
        curHealth -= damage;
        healthBar.SetHealth(curHealth);
        //death
        if (curHealth < 1)
        {
            //Debug.Log("Switch scene");
            SceneManager.LoadScene("GameOver");
        }
    }
}
