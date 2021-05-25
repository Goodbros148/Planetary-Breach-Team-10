using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMove : MonoBehaviour
{
    public float accel = 8;
    private Rigidbody2D rb2;
    private SpriteRenderer sr;
    Vector3 characterScale;
    float characterScaleX;
    public bool facingLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        characterScale = transform.localScale;
        characterScaleX = characterScale.x;
    }

    private void FixedUpdate()
    {
        
        //Move right
        if(Input.GetAxis("Horizontal")>0)
        {
            rb2.AddForce(new Vector2(accel, 0));
        }

        //Move Left
        if (Input.GetAxis("Horizontal") < 0)
        {
            rb2.AddForce(new Vector2(-accel, 0));
        }

    }
    //Flip sprite (still wip)
    void Update()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            //characterScale.x = -characterScaleX;
            facingLeft = true;
        }
        if (facingLeft == true)
        {
            transform.Rotate(0f, 180f, 0f);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            //characterScale.x = characterScaleX;
            facingLeft = false;
        }
        if (facingLeft == false)
        {
            transform.Rotate(0f, 0f, 0f);
        }
        transform.localScale = characterScale;


    }
}
