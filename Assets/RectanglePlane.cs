using UnityEngine;
using System.Collections;

//Ignore or delete this, was starting to write a more generalized version of the other class

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
public class RectanglePlane: MonoBehaviour
{
	public float x, y, w, h;
	public int verticesPerUnit;

	private Mesh _mesh;
	private Vector2 _offset, _size;
	private float _verticesPerUnit;
	private MeshFilter _meshFilter;
	private MeshCollider _meshCollider;

	private void Start()
	{
		_meshFilter = GetComponent<MeshFilter>();
		_meshCollider = GetComponent<MeshCollider>();
	}

	private int[] CalculateTriangles()
	{
		return new int[0];
	}

	private void Update()
	{
		
	}
}
