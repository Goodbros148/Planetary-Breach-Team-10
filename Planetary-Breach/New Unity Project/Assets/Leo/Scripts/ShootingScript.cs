using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject Bullet;
    public Transform firePoint;

 

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            /*GameObject Bullet = (GameObject)Instantiate(bulletRef);
            Bullet.transform.position = new Vector3(transform.position.x + 0.6f, transform.position.y + 0.2f, -1);*/
            Shoot();
        }

        void Shoot ()
        {
            Instantiate(Bullet, firePoint.position, firePoint.rotation);
        }
    }
}
