﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartRocket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene("Level");
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        SceneManager.LoadScene("Level");
    }
}