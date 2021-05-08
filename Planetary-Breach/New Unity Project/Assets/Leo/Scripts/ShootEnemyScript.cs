using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemyScript : MonoBehaviour
{

    private int health = 5;

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
    }

    private void KillSelf()
    {
        Destroy(gameObject);
    }
}
