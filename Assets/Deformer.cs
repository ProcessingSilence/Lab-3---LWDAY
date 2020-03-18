/*
A failed script. I tried to see if I could get scripts attached to instantiated deformers to
connect to the Plane.cs script. However, the calculations that were required could not be done
separately from the Plane.cs script via a different connected script. So because of this, I had
to scrap this script.
*/

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deformer : MonoBehaviour
{
    private Plane my_plane_script;

    private float deepness;
    
    public float scale = 0.25f;

    public float xOffset = 0.25f;
    public float zOffset = 0.25f;

    public Vector3 total;
    
    private Transform my_transform;

    private int width, height;
    // Start is called before the first frame update
    void Start()
    {
        my_transform = gameObject.GetComponent<Transform>();
        width = my_plane_script.width;
        height = my_plane_script.height;
    }

    private void Update()
    {
        float timeVar = Time.time;
        total = new Vector3(CalculateY(timeVar, my_plane_script.i, my_plane_script.j), my_plane_script.j * scale);
        my_plane_script.total += total;
    }

    private void FixedUpdate()
    {
        // Prevent the ground from rising when the Ypos of object is above 1.
        if (my_transform.position.y > 1f)
        {
            deepness = 0;
        }
        // The deepness of the crater needs offset of -1, otherwise a crater will never form.
        else
        {
            deepness = my_transform.position.y - 1f;
        }	    
    }

    private float CalculateY(float timeVar, float x, float z)
    {
        float tnow = 2*Mathf.PI*timeVar/10;
		
        float dist = 3;
        float dist1 = 0;
		
        float argx = (-my_transform.position.x+ xOffset + (x - width / 2) * scale) +6;
        float argz = (-my_transform.position.z+ zOffset + (z - height / 2) * scale) +6;

        // Deepness of the crater
        return deepness*Mathf.Exp (-argx*argx -argz*argz);
    }
}
*/