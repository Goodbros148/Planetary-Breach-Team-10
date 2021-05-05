using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewShootingScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform Firepoint;
    public float bulletSpeed = 20f;

    Vector2 lookDirection;
    float lookAngle;

    private void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        Firepoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletClone = Instantiate(bullet);
            bulletClone.transform.position = Firepoint.position;
            bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

            bulletClone.GetComponent<Rigidbody2D>().velocity = Firepoint.right * bulletSpeed;
        }
    }

}
