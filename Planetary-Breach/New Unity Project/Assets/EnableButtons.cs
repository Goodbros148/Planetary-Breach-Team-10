using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableButtons : MonoBehaviour
{

    public GameObject Button1;
    public GameObject Button2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ButtonEnable());
    }

    // Update is called once per frame
    private IEnumerator ButtonEnable()
    {
        Button1.SetActive(false);
        Button2.SetActive(false);
        yield return new WaitForSeconds(2);
        Button1.SetActive(true);
        Button2.SetActive(true);
    }
}
