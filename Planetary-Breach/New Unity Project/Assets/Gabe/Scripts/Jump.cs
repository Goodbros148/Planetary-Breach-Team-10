using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private SideMove2 thePlayer;
    public float jumpStrength = 400;
    public bool grounded;
    public bool inAir;
    private Rigidbody2D rb2;
    public Animator animator;
    public bool boosted;
    public ParticleSystem BoostParticles;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        thePlayer = FindObjectOfType<SideMove2>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Jump") && grounded == true) 
        {
            rb2.AddForce(new Vector2(0, jumpStrength));
            inAir = true;
            if (Input.GetButtonDown("Jump") && inAir == true)
            {
                rb2.AddForce(new Vector2(0, jumpStrength));
                grounded = false;
                inAir = false;
            }
        }
        if (grounded == true)
        {
            animator.SetBool("isGrounded", true);
        }
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("isGrounded", false);
        }
        
    }

    //detect if player is standing on ground. If not, they cannot jump
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && inAir == true)
        {
            if (Input.GetButtonDown("Jump") && inAir == true)
            {
                grounded = false;
                inAir = false;
            }
        }
        else if (collision.gameObject.CompareTag("SubBullet") && inAir == true)
        {
            if (Input.GetButtonDown("Jump") && inAir == true)
            {
                grounded = false;
                inAir = false;
            }
        }
        else if (collision.gameObject.CompareTag("PlayerBullet") && inAir == true)
        {
            if (Input.GetButtonDown("Jump") && inAir == true)
            {
                grounded = false;
                inAir = false;
            }
        }
        else if (collision.gameObject.CompareTag("Ground") && inAir == false) { grounded = true; inAir = false; }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Input.GetButtonDown("Jump"))
        {
            grounded = false;
            inAir = false;
        }

        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("JumpBoost"))
        {
            StartCoroutine(JumpBoost());
}
    }
    IEnumerator JumpBoost()
    {
        jumpStrength = 600;
        var obj = Instantiate(BoostParticles, transform.position, Quaternion.identity);
        obj.transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, 10);
        yield return new WaitForSeconds(20);
        Destroy(obj, 3f);
        jumpStrength = 400;
    }
}
