using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedlimiter : MonoBehaviour
{
    //public float speedCap should be modifiable by other scripts.
    public float speedCap = 3;
    private Rigidbody2D rb2;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
        //the scrip to prevent the player from speeding 
    {
        //Debug.Log(rb2.velocity);
        if (rb2.velocity.x > speedCap)
        {
            rb2.velocity = new Vector2(speedCap, rb2.velocity.y);
        }
        if (rb2.velocity.x < -speedCap)
        {
            rb2.velocity = new Vector2(-speedCap, rb2.velocity.y);
        }
    }
}
