using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletDeath : MonoBehaviour
{

    private int health = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            health--;
            if (health <= 0)
            {
                KillSelf();
            }
        }
    }

    private void KillSelf()
    {
        SceneManager.LoadScene("GameOver");
    }
}