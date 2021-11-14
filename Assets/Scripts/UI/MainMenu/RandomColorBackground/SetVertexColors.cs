using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVertexColors : MonoBehaviour
{
    [SerializeField] private RandomVertexColors randomVertexColors;
    private Mesh mesh;

    private void Start() 
    {
        SetColors();
    }

    private void SetColors()
    {
        var pallete = randomVertexColors.GetPalette();
        mesh = gameObject.GetComponent<MeshFilter>().mesh;
        Color[] colors = new Color[mesh.vertices.Length];
        colors[0] = pallete.colorKeys[0].color;
        colors[1] = pallete.colorKeys[1].color;
        colors[2] = pallete.colorKeys[0].color;
        colors[3] = pallete.colorKeys[1].color;

        mesh.colors = colors;
    }
}
