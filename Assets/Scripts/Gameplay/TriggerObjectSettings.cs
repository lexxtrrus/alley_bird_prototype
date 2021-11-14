using UnityEngine;

[CreateAssetMenu(fileName = "TriggerObjectSettings", menuName = "alley_bird_prototype/TriggerObjectSettings", order = 0)]
public class TriggerObjectSettings : ScriptableObject 
{
    [SerializeField] public GameObject prefab;
    [SerializeField] public float yMin;
    [SerializeField] public float yMax;
    [SerializeField] public float width;
}