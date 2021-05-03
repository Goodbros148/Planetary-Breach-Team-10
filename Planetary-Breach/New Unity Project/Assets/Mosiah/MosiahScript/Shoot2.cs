using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot2 : MonoBehaviour
{
    Object bulletRef;
    private SideMove2 thePlayer;
    public bool playerInRange;
    public float playerRange;

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
            GameObject Bullet = (GameObject)Instantiate(bulletRef);
            Bullet.transform.position = new Vector3(transform.position.x + 1f, transform.position.y - 2f, 1);
            //Bullet.transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, -1);
        }
    }
}
