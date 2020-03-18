// Script heavily edited by Liam Day, GDD-175, Spring semester 2020

// Original script made by Professor Luther, G., Quinnipiac University

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
public class Plane: MonoBehaviour
{
	// Width, Height ints
	public int width, height;
	
	// Offset of crater xz position to object position
	// **0.25f Offset recommended**
	public float xOffset = 0.25f;
	public float zOffset = 0.25f;
	
	public float scale;

	
	public float total;
	
	public List<float>argxList = new List<float>();
	public List<float>argzList = new List<float>();
	
	private Mesh _mesh;
	private MeshFilter _meshFilter;
	private MeshCollider _meshCollider;
	
	// Keeps track of all the objects that have been spawned through mouse clicks.
	public List<GameObject> deformerList = new List<GameObject>();

	// Keeps track of the deepness that all objects have.
	public List<float> deepnessList = new List<float>();


	
	// Get Collider + Filter components
    private void Start()
	{
		_meshFilter = GetComponent<MeshFilter>();
		_meshCollider = GetComponent<MeshCollider>();
	}

    private void FixedUpdate()
    {
		// Only run if there's an object in the list.
	    if (deformerList.Count != 0)
	    {
		    // Iterate through each object in the list in for loop to check on y-pos.
		    for (int k = 0; k < deepnessList.Count; k++)
		    {
			    // Deepness will not go above 0, otherwise the ground will rise up and the object will never fall through. 
			    if (deformerList[k].transform.position.y > 1f)
			    {
				    deepnessList[k] = 0;
			    }
			    
			    // Deform the ground based on object's y-pos -1.
			    // The ground will not deform if it's at the object's exact position.
			    else
			    {
				    deepnessList[k] = deformerList[k].transform.position.y - 1f;
			    }
		    }
	    }
    }

    private void Update()
    {
	    // Declare new mesh and clear it.
	    _mesh = new Mesh();
	    _mesh.Clear();
		
	    // Use CalculateVertices and CalculateTriangles to get properties of the mesh.
	    _mesh.vertices = CalculateVertices();
	    _mesh.triangles = CalculateTriangles();
		
	    // Recalculate normals of Mesh from triangles and vertices.
	    _mesh.RecalculateNormals();
		
	    // Set meshFilter and meshCollider to new created _mesh.
	    _meshFilter.mesh = _mesh;
	    _meshCollider.sharedMesh = _mesh;
    }

	private Vector3[] CalculateVertices()
	{
		// width * height = Vertices number		
		Vector3[] vertices = new Vector3[width * height];
		
		// Unity time variable
		float timeVar = Time.time;
		
		// Use nested for loop with width and height to generate grid.
		// Create line of vertices on z axis, iterate through each x axis after z axis row is created.
		// Both x and z are multiplied by given scale.
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				vertices[i + j * width] = new Vector3(i * scale, CalculateY(timeVar, i, j), j * scale);
			}
		}
		return vertices;
	}
	
	
	// Use X and Z position for the object that gets placed on the plane.
	private float CalculateY(float timeVar, float x, float z)
	{	
		// Restart the total each time the function is called, otherwise it will infinitely add-up.
        total = 0;
        // Iterate through for loop to get deepness of the crater for each object.
        for (int k = 0; k < deformerList.Count; k++)
        {
	        argxList[k] = (-deformerList[k].transform.position.x+ xOffset + (x - width / 2) * scale) +6;
	        argzList[k] = (-deformerList[k].transform.position.z+ zOffset + (z - width / 2) * scale) +6;
	        total += deepnessList[k] * Mathf.Exp(-argxList[k] * argxList[k] - argzList[k] * argzList[k]);
        }
		return total;
	}
	
	
	// Calculate the triangles based on all the vertices positions
	private int[] CalculateTriangles()
	{
		// Subtract width and height by 1 so it starts at 0 when incremented.
		int[] triangles = new int[(width - 1) * (height - 1) * 6];
		
		// Nested height within width FOR loop to create triangles on the mesh.
		for (int i = 0; i < width - 1; i++)
		{
			for (int j = 0; j < height - 1; j++)
			{
				int index = (i + j * (width - 1)) * 6;
				triangles[index] = i + j * width;
				triangles[index + 1] = i + (j + 1) * width;
				triangles[index + 2] = i + j * width + 1;
				triangles[index + 3] = i + j * width + 1;
				triangles[index + 4] = i + (j + 1) * width;
				triangles[index + 5] = i + (j + 1) * width + 1;
			}
		}
		return triangles;
	}
}
