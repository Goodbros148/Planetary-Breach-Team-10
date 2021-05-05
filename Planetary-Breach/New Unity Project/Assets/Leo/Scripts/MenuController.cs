﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void ButtonStart()
    {
        SceneManager.LoadScene(2);
    }
    public void ButtonCredits()
    {
        SceneManager.LoadScene(1);
    }
    public void ButtonQuit()
    {
        Application.Quit();
    }

    public void ButtonMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
