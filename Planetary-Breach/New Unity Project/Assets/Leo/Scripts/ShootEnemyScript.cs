using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemyScript : MonoBehaviour
{

    private int health = 10;
    public GameObject healthpick;
    public Transform dropSpot;
    
    public ParticleSystem DeathParticles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            health--;
            if(health <= 0)
            {
                KillSelf();
            }
        }
        if (collision.CompareTag("SubBullet"))
        {
            Destroy(collision.gameObject);
            health = health - 4;
            if (health <= 0)
            {
                KillSelf();
            }
        }
    }

    private void KillSelf()
    {
        Destroy(gameObject);
        var obj = Instantiate(DeathParticles, transform.position, Quaternion.identity);
        Destroy(obj, 3f);
        GameObject healthClone = Instantiate(healthpick);
        healthClone.transform.position = dropSpot.position;
    }
   


}
