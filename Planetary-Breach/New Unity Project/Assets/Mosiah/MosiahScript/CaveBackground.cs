using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveBackground : MonoBehaviour
{


    public GameObject CaveBackgroundobj;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("CaveExit"))
        {
            CaveBackgroundobj.SetActive(false);
        }

        if (col.gameObject.CompareTag("CaveEnter"))
        {
            CaveBackgroundobj.SetActive(true);
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("CaveExit"))
        {
            CaveBackgroundobj.SetActive(false);
        }

        if (col.gameObject.CompareTag("CaveEnter"))
        {
            CaveBackgroundobj.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("CaveExit"))
        {
            CaveBackgroundobj.SetActive(false);
        }

        if (col.gameObject.CompareTag("CaveEnter"))
        {
            CaveBackgroundobj.SetActive(true);
        }
    }
}
