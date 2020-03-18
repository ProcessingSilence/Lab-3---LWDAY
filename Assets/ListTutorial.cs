// Script made based on Unity C# Tutorials: Part 19 - Lists: https://youtu.be/lE18lucGJh4

// This script was made to teach me how to use lists in Unity. It does not serve any functional purpose in the project.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListTutorial : MonoBehaviour
{
    // Declaration
    // List <type> name;
    private List<int> myList = new List<int>();
    
    // Initialization 
    // List <type> name = new List <type>();
    List<int> anotherList = new List<int>(){1,2,3,4,5};

    private List<Vehicle> myVehicles;
    
    // Start is called before the first frame update
    void Start()
    {
        // Add an element.
        anotherList.Add(6);
        
        // Remove an element.
        anotherList.Remove(6);
        
        // Remove an indexed element.
        anotherList.RemoveAt(4);
        
        // Display number of elements.
        Debug.Log(anotherList.Count);
        
        // Get an item at a specific index.
        Debug.Log(anotherList[0]);

        // Set an item in the list (changine first element in the list to 0).
        anotherList[0] = 0;
    }
}

public class Vehicle
{
    
}
