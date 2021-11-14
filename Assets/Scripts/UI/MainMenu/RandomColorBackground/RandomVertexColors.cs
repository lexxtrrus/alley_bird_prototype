using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomVertexColors : MonoBehaviour
{
    [SerializeField] private Gradient gradient;
    private GradientColorKey[] colorKeys = new GradientColorKey[2];
    private GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];  

    private void Awake()
    {
        GenerateRandomGradient();
    }
     public Gradient GetPalette()
    {
        return gradient;
    }

    private void GenerateRandomGradient()
    {
        SetColorToKeys();
        SetKeysToGradient();
    }

    private void SetKeysToGradient()
    {
        gradient.SetKeys(colorKeys, alphaKeys);
    }

    private void SetColorToKeys()
    {
        SetColorToKey(0, GetRandomColor(), 0);
        SetColorToKey(1, GetRandomColor(), 1);
    }

    private Color GetRandomColor()
    {
        Color randomColor = Color.black;

        while(randomColor.r + randomColor.b + randomColor.g < 1f)
        {
            randomColor = new Color(Random.value, Random.value, Random.value);
        }

        return randomColor;
    }    

    private void SetColorToKey(int index, Color randomColor, int time)
    {
        colorKeys[index].color = randomColor;
        colorKeys[index].time = time;
        alphaKeys[index].alpha = 1f;
        alphaKeys[index].time = time;
    }
}
