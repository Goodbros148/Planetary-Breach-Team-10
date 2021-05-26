using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubWeaponShooting : MonoBehaviour
{
    public GameObject placeHolder;
    public Transform Firepoint;
    public float bulletSpeed = 10f;
    public GameObject player;
    public bool allowFire;
    public float rateOfFire = 2f;
    public int maxAmmo = 25;
    public int curAmmo = 0;
    public Text ammoAmount;
    public bool hasGun = false;

    public GameObject SubFireUI;
    Vector2 lookDirection;
    float lookAngle;
    

    private void Start()
    {
        allowFire = false;
        SubFireUI.SetActive(false);
        curAmmo = 5;
    }

    private void Update()
    {
        
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(player.transform.position.x, player.transform.position.y);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        Firepoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        Debug.Log(allowFire);

        if (Input.GetMouseButtonDown(1) && (allowFire == true))
        {
            StartCoroutine(Fire());
        }

        //Ammo UI Programming
        ammoAmount.text = curAmmo.ToString();

        //Prevents Ammo count from going above max. If no ammo, allowFire is set to False
        if (curAmmo > maxAmmo)
        {
            curAmmo = maxAmmo;
        }
        if (curAmmo < 0)
        {
            curAmmo = 0;
        }
        if (curAmmo == 0)
        {
            allowFire = false;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SubWeaponGet"))
        {
            allowFire = true;
            SubFireUI.SetActive(true);
            hasGun = true;
        }
        if (collision.gameObject.CompareTag("PlusAmmo"))
        {
            curAmmo += 2;
        }
        if (collision.gameObject.CompareTag("PlusAmmo") && hasGun == true)
        {
            allowFire = true;
        }
    }
    IEnumerator Fire()
    {
        allowFire = false;

        Shoot();

        curAmmo--;
    
        yield return new WaitForSeconds(rateOfFire);

        allowFire = true;

    }

    private void Shoot()
    {
        GameObject bulletClone = Instantiate(placeHolder);
        bulletClone.transform.position = Firepoint.position;
        bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
        SoundManager.PlaySound("Laser");
        bulletClone.GetComponent<Rigidbody2D>().velocity = Firepoint.right * bulletSpeed;

    }

}
