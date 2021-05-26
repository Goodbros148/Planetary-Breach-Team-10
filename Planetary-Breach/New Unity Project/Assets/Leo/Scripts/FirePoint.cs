using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public SpriteRenderer Sr;
    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        Sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player.GetComponent<Health>().facingLeft == true)
        {
            Sr.flipX = true;
            Sr.flipY = true;
        }

        if (player.GetComponent<Health>().facingLeft == false)
        {
            Sr.flipX = false;
            Sr.flipY = false;
        }

    }
}

  
