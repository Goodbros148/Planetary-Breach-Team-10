using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemyScript : MonoBehaviour
{

    public int health = 11;
    public GameObject healthpick;
    public Transform dropSpot;

    public Color myNormalColor;
    public Color myDamageColor;
    SpriteRenderer myRenderer;

    public ParticleSystem DeathParticles;

    // Start is called before the first frame update
    void Start()
    {
        myDamageColor = Color.cyan;
        myNormalColor = Color.white;
        myRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            health = health - 1;
            
            StartCoroutine(DamageIndicator());
            if (health <= 0)
            {
                KillSelf();
            }
        }
        if (collision.CompareTag("SubBullet"))
        {
            Destroy(collision.gameObject);
            health = health - 2;
            
            StartCoroutine(DamageIndicator());
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

    private IEnumerator DamageIndicator()
    {
        myRenderer.material.color = myDamageColor;
        yield return new WaitForSeconds(1);
        myRenderer.material.color = myNormalColor;
    }

}
