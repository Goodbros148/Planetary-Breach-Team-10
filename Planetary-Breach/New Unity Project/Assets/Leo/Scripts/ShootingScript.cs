using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    Object bulletRef;

    // Start is called before the first frame update
    void Start()
    {
        bulletRef = Resources.Load("Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject Bullet = (GameObject)Instantiate(bulletRef);
            Bullet.transform.position = new Vector3(transform.position.x + 1f, transform.position.y + 0.2f, -1);
        }
    }
}
