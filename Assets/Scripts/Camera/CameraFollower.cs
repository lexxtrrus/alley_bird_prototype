using UnityEngine;
using Zenject;

public class CameraFollower : MonoBehaviour 
{
    private Transform targetTransform;
    private float offsetY = 2.46658f;

    private void Start() 
    {
        targetTransform = GameObject.FindObjectOfType<HeroMovement>().transform;    
    }

    private void LateUpdate() 
    {
        transform.position = new Vector3(0f, targetTransform.position.y + offsetY, - 10f);         
    }
}