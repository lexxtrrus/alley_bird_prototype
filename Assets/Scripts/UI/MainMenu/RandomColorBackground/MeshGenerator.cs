using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    private void Awake() 
    {
        var mesh = new Mesh();

        mesh.vertices = new Vector3[] 
        {
			new Vector2(-5f, -5f),
            new Vector2(-5f, 5f),
            new Vector2(5f, -5f),
            new Vector2(5f, 5f),
		};

        mesh.triangles = new int[] 
        {
			0, 2, 1, 1, 2, 3
		};

        GetComponent<MeshFilter>().mesh = mesh;
    }
}
