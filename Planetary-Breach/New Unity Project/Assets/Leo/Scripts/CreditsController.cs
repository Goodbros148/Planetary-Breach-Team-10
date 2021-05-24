using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{

    private static int nScreens = 6;
    private GameObject[] creditScreens = new GameObject[nScreens];
    private static int swapCount = 0;


    private void Start()
    {
        creditScreens[0] = GameObject.Find("Credits_1");
        creditScreens[1] = GameObject.Find("Credits_2");
        creditScreens[2] = GameObject.Find("Credits_3");
        creditScreens[3] = GameObject.Find("Credits_4");
        creditScreens[4] = GameObject.Find("Credits_5");
        creditScreens[5] = GameObject.Find("Credits_6");


        for (int i = 0; i < nScreens; i++)
        {
            creditScreens[i].SetActive(false);
        }
        creditScreens[0].SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //Toggle
            int currentScene = swapCount % nScreens;
            creditScreens[currentScene].SetActive(false);
            swapCount++;
            currentScene = swapCount % nScreens;
            creditScreens[currentScene].SetActive(true);

        }
    }
    public void ButtonBack()
    {
        SceneManager.LoadScene(0);
    }
}
