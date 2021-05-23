using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFolowPoint : MonoBehaviour
{
    public float rateOfChange;
    public GameObject Self;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            StartCoroutine(TempDisable());
        }
    }
    private IEnumerator TempDisable()
    {
        Self.SetActive(false);
        yield return new WaitForSeconds(rateOfChange);
        Self.SetActive(true);
    }
}
