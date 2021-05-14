using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot2 : MonoBehaviour
{
    Object bulletRef;
    private SideMove2 thePlayer;
    public bool playerInRange;
    public float playerRange;
    public GameObject bullet;
    public Transform Firepoint;
    public SimpleXYTimeMove2 Player;
    private float fireAngle;

    public float bulletSpeed = 20f;

    float lookAngle;
    float lookAngleX;
    float lookAngleY;
    public LayerMask playerLayer;
    // Start is called before the first frame update
    void Start()
    {
        bulletRef = Resources.Load("Bullet");
        thePlayer = FindObjectOfType<SideMove2>();
        fireAngle = Random.Range(-1, -7);

        //lookAngle = Mathf.Atan2(Player.x, Player.y) * Mathf.Rad2Deg;
        Player = FindObjectOfType<SimpleXYTimeMove2>();
        lookAngle = Mathf.Atan2(-1, 0) * Mathf.Rad2Deg;
        Firepoint.rotation = Quaternion.Euler(0, 0, lookAngle);
    }

    // Update is called once per frame
    void Update()
    {

        playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);
        if (playerInRange)
        {
            StartCoroutine(ExampleCoroutine());


        }
    }
    IEnumerator ExampleCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);
        Shoot();
        yield return new WaitForSeconds(3);
    }
void Shoot()
    {
        GameObject bulletClone = Instantiate(bullet);
        bulletClone.transform.position = Firepoint.position;
        bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

        bulletClone.GetComponent<Rigidbody2D>().velocity = Firepoint.right * bulletSpeed;
    }
}
