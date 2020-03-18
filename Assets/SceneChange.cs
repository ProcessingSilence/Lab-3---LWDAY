// Script made by Liam Day, GDD-175, Spring semester 2020

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    // String slot for scene name.
    public string sceneName;

     // Start() function extracts number from scene name, converts it to an int.
    void Start()
    {
        // Get the active scene, then convert it to a string.
        var getSceneName = SceneManager.GetActiveScene();
        sceneName = getSceneName.name;
    }
    
    // Update is called once per frame
    void Update()
    {
        // If R pressed...
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Change scene based on sceneName string.
            SceneManager.LoadScene(sceneName);
        }
    }
}

