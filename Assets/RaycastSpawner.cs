// Script made by Liam Day, GDD-175, Spring semester 2020

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastSpawner : MonoBehaviour
{
    // Offset in the y spawning position.
    public float yOffset = 4;
    
    // Spawning location for the instantiated object.
    private Vector3 spawnPoint;
    
    public GameObject deformerObject;
    public GameObject regularBall;
    public GameObject PlaneObject; 
    private Plane my_plane_script;
    public Text sizeText;

    public float scaleSize = 1f;
    // Keeps track of num of objects in objectArray.
    private int arrayNum = 0;

    // Left = false, Right = true
    private bool rightOrLeft;

    private int numberPressed;

    // Put keycodes in an array to make them easier to track within a for-loop.
    private KeyCode[] keyCodes = {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7,
        KeyCode.Alpha8,
        KeyCode.Alpha9,
        KeyCode.Alpha0,
    };
    
    // Set the spawnPoint y position to yOffset; the y axis of spawnPoint will never change.
    void Start()
    {
        spawnPoint.y = yOffset;
        my_plane_script = PlaneObject.GetComponent<Plane>();
    }

    // Detect single click and start HandleInput().
    void LateUpdate () 
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleInput(rightOrLeft = false);
        }
        if (Input.GetMouseButtonDown(1))
        {
            HandleInput(rightOrLeft = true);
        }

        for (int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                numberPressed = i + 1;
            }
        }

        switch (numberPressed)
        {
            case 1: scaleSize = 0.2f;
                break;
            case 2: scaleSize = 0.4f;
                break;
            case 3: scaleSize = 0.6f;
                break;
            case 4: scaleSize = 0.8f;
                break;
            case 5: scaleSize = 1f;
                break;
            case 6: scaleSize = 1.2f;
                break;
            case 7: scaleSize = 1.4f;
                break;
            case 8: scaleSize = 1.6f;
                break;
            case 9: scaleSize = 1.8f;
                break;
            case 10: scaleSize = 1.9f;
                break;
        }
        
        if (scaleSize < 1.9f)
            sizeText.text = "Scale: " + scaleSize;
        
        // Object size cannot go to 2 or the plane will not bend, going to lie about the size being 2 to make it feel even.
        else
            sizeText.text = "Scale: " + (scaleSize + 0.1f);
    }

    void HandleInput (bool rightOrLeft) {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
		
        if (Physics.Raycast(inputRay, out hit))
        {
            // Get the mouse raycast x and z position of hit object.
            Debug.Log(hit.point);
            spawnPoint.x = hit.point.x;
            spawnPoint.z = hit.point.z;
            
            // Both objects get instantiated on raycast x and z position.
            
            // Spawn deformer from left click
            if (rightOrLeft == false)
            {   
                // Set scale of object to chosen scaleSize scale.
                deformerObject.transform.localScale = new Vector3(scaleSize, scaleSize, scaleSize);
                
                // Add instantiated object to deformerList in Plane.cs script.
                my_plane_script.deformerList.Add
                    (Instantiate(deformerObject, spawnPoint, Quaternion.identity) as GameObject);
                
                // Add space to lists so that they can be used for the deformer object.
                my_plane_script.argxList.Add(0);
                my_plane_script.argzList.Add(0);
                my_plane_script.deepnessList.Add(0);
            }
            
            // Spawn regular orb from right click.
            else
            {
                regularBall.transform.localScale = new Vector3(scaleSize, scaleSize, scaleSize);
                Instantiate(regularBall, spawnPoint, Quaternion.identity);
            }
        }
    }
}
