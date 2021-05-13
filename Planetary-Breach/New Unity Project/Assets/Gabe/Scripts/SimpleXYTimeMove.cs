using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleXYTimeMove : MonoBehaviour
{
    private float scaler;
    private SpriteRenderer sr;
    public Animator animator;


    // Update is called once per frame
    void Update()
    {
        //basic movement script       
        scaler = 4; //modify this number to adjust movement speed. Physics of player are controlled by the rigidbody 
        float inX = Time.deltaTime * scaler * Input.GetAxis("Horizontal");        
        transform.position += new Vector3(inX, 0);
        Debug.Log(inX + ", ");

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
        if (Input.GetAxis("Horizontal")<0)
        {
            characterScale.x = -3.123512f; 
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 3.123512f; //this number is the same as the character sprite's scale number in unity. copy and paste that number here if changed.
        }
        transform.localScale = characterScale;
    }

}
