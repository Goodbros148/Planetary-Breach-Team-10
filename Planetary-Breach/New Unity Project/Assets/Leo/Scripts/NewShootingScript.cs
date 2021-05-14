﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewShootingScript : MonoBehaviour
{
    public GameObject playerBullet;
    public Transform Firepoint;
    public float bulletSpeed = 20f;
    public GameObject player;

    Vector2 lookDirection;
    float lookAngle;

    private void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(player.transform.position.x, player.transform.position.y);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        Firepoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletClone = Instantiate(playerBullet);
            bulletClone.transform.position = Firepoint.position;
            bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

            bulletClone.GetComponent<Rigidbody2D>().velocity = Firepoint.right * bulletSpeed;
        }
    }

}
