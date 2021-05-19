using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubWeaponShooting : MonoBehaviour
{
    public GameObject placeHolder;
    public Transform Firepoint;
    public float bulletSpeed = 10f;
    public GameObject player;
    public bool allowFire;
    public float rateOfFire = 2f;

    Vector2 lookDirection;
    float lookAngle;

    private void Start()
    {
        allowFire = true;
    }

    private void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(player.transform.position.x, player.transform.position.y);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        Firepoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        Debug.Log(allowFire);

        if (Input.GetMouseButtonDown(0) && (allowFire == true))
        {
            StartCoroutine(Fire());

        }
    }

    IEnumerator Fire()
    {
        allowFire = false;

        Shoot();

        yield return new WaitForSeconds(rateOfFire);

        allowFire = true;
    }

    private void Shoot()
    {
        GameObject bulletClone = Instantiate(placeHolder);
        bulletClone.transform.position = Firepoint.position;
        bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

        bulletClone.GetComponent<Rigidbody2D>().velocity = Firepoint.right * bulletSpeed;
    }

}
