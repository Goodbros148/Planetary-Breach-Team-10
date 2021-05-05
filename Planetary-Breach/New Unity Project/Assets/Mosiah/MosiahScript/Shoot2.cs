using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot2 : MonoBehaviour
{
    Object bulletRef;
    private SideMove2 thePlayer;
    public bool playerInRange;
    public float playerRange;
    public GameObject Bullet;
    public Transform firePoint;

    public LayerMask playerLayer;
    // Start is called before the first frame update
    void Start()
    {
        bulletRef = Resources.Load("Bullet");
        thePlayer = FindObjectOfType<SideMove2>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);
        if (playerInRange)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        Instantiate(Bullet, firePoint.position, firePoint.rotation);
    }
}
