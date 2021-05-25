using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void ButtonStart()
    {
        SceneManager.LoadScene("cutscene");
    }
    public void ButtonRetry()
    {
        SceneManager.LoadScene("Level");
    }
    public void ButtonCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void ButtonQuit()
    {
        Application.Quit();
    }

    public void ButtonMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
