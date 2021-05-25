using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject Player = GameObject.Find("Player");
        Health playerScript = Player.GetComponent<Health>();
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}