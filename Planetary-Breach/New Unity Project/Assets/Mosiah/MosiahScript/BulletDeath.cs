using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletDeath : MonoBehaviour
{

    public int health = 5;
    private bool isNotInvincible = true;
    [SerializeField]
    private float invincibilityDurationSeconds;
    public Color myColor;
    public Color myDamageColor;
    SpriteRenderer myRenderer;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.CompareTag("Bullet")&& isNotInvincible)
        {
            Destroy(collision.gameObject);
            health--;
            StartCoroutine(BecomeTemporarilyInvincible());
            if (health <= 0)
            {
                KillSelf();
            }
        }
    }
    private IEnumerator BecomeTemporarilyInvincible()
    {
        Debug.Log("Player turned invincible!");
        isNotInvincible = false;
        myRenderer.material.color = myDamageColor;
        yield return new WaitForSeconds(invincibilityDurationSeconds);
        myRenderer.material.color = myColor;
        isNotInvincible = true;
        Debug.Log("Player is no longer invincible!");
    }
    private void KillSelf()
    {
        SceneManager.LoadScene("GameOver");
    }
}