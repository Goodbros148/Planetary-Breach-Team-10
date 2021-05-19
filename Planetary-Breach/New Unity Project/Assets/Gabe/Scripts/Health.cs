using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 64;
    public HealthBar healthBar;
    private bool isNotInvincible = true;
    [SerializeField]
    private float invincibilityDurationSeconds;
    [SerializeField]
    private float invincibilityDurationSecondsHazard;
    public Color myColor;
    public Color myBuffColor;
    public Color myBuffSmallColor;
    public Color myDamageColor;
    SpriteRenderer myRenderer;
    public float speedCap = 5;
    private Rigidbody2D rb2;

    private float scaler;
    private SpriteRenderer sr;
    public Animator animator;
    // Start the game with full health
    void Start()
    {
        curHealth = maxHealth;
        myRenderer = GetComponent<SpriteRenderer>();
        rb2 = GetComponent<Rigidbody2D>();
        scaler = 6;
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
        if (rb2.velocity.x > speedCap)
        {
            rb2.velocity = new Vector2(speedCap, rb2.velocity.y);
        }
        if (rb2.velocity.x < -speedCap)
        {
            rb2.velocity = new Vector2(-speedCap, rb2.velocity.y);
        }
            if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        if (curHealth <= 10)
        {
           speedCap = 30;
            scaler = 9;
            myRenderer.material.color = myBuffColor;
        }
        else { speedCap = 5; scaler = 6; }
        if (curHealth <= 20 && curHealth > 10)
        {
            speedCap = 15;
            scaler = 7;
            myRenderer.material.color = myBuffSmallColor;
        }
        else if(curHealth > 10) { speedCap = 5; scaler = 6; }

        //basic movement script       
        //modify this number to adjust movement speed. Physics of player are controlled by the rigidbody 
        float inX = Time.deltaTime * scaler * Input.GetAxis("Horizontal");
        transform.position += new Vector3(inX, 0);
        //Debug.Log(inX + ", ");

        //walking animation
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else if (Input.GetAxis("Horizontal") == 0)
        {
            animator.SetBool("isWalking", false);
        }


        //flip sprite
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -5f;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 5f; //this number is the same as the character sprite's scale number in unity. copy and paste that number here if changed.
        }
        transform.localScale = characterScale;
    }
    //Damaging the player is controlled here by tags (as of right now)
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Hazard")&& isNotInvincible) //anything tagged as "Hazard" will deal 10 damage to the player
        {
            DamagePlayer(8);
            StartCoroutine(BecomeTemporarilyInvincibleHazard());
            if (curHealth < 1)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
            if (col.CompareTag("Bullet") && isNotInvincible)
            {
                Destroy(col.gameObject);
                DamagePlayer(4);
                StartCoroutine(BecomeTemporarilyInvincible());
                if (curHealth < 1)
                {
                    SceneManager.LoadScene("GameOver");
                }
            }
        if (col.gameObject.CompareTag("PlusHealth")) //anything tagged as "PlusHealth" will heal 10 damage to the player
        {
            DamagePlayer(-3);
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
    private IEnumerator BecomeTemporarilyInvincibleHazard()
    {
        Debug.Log("Player turned invincible!");
        isNotInvincible = false;
        myRenderer.material.color = myDamageColor;
        yield return new WaitForSeconds(invincibilityDurationSecondsHazard);
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
