using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyMove : MonoBehaviour
{
    private SideMove2 thePlayer;
    public GameObject playerObject;
    public GameObject followPoint;
    public float moveSpeed;

    private float playerRange = 20;

    public LayerMask playerLayer;

    public bool playerInRange;




    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<SideMove2>();

    }

    // Update is called once per frame
    void Update()
    {
        playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);

        if (playerInRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, playerRange);
    }
}
