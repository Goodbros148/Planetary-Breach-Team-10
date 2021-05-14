using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleXYTimeMove2 : MonoBehaviour
{
    private float scaler;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scaler = 2;
        float inX = Time.deltaTime * scaler * Input.GetAxis("Horizontal");        
        transform.position += new Vector3(inX, 0);
        //Debug.Log(inX + ", ");     
    }

}
