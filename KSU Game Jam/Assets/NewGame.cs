﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;


public class NewGame : MonoBehaviour {

    void startNewGame()
    {
        if (Input.GetKeyDown("space"))
            
        {
            
            SceneManager.LoadScene("ErnieScene");
        }
    }
}
