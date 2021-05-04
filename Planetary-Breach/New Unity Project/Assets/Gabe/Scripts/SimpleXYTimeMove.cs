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
        scaler = 2;
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
            characterScale.x = -2.269044f;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 2.269044f;
        }
        transform.localScale = characterScale;
    }

}
