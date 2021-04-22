using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardousObject : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject HP = GameObject.Find("HP");
        Health Health = HP.GetComponent<Health>();
    }
    public Health Damage;

    void update()
    {
        Damage.GetComponent<Health>().DamagePlayer(0);
        
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        //Damage control, will continue to deal damage to player unless the health is at 0 or lower.
        while (col.gameObject.CompareTag("Player") && Health.curHealth > 0)
        {
            //Debug.Log("collided with something painful...");
            Damage.GetComponent<Health>().DamagePlayer(10);            
        }
        if (col.gameObject.CompareTag("Player"))
        {

        }
    }   
}
