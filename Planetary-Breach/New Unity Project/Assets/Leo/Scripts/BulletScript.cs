using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
   


    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", 1);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            DestroySelf();
        }

        /*if (collision.gameObject.CompareTag("Hazard"))
        {
            DestroySelf();
        }*/
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}

