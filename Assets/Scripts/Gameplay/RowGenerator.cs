using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RowGenerator : MonoInstaller
{
    [SerializeField] private List<TriggerObjectSettings> triggerObjects;
    [SerializeField] private GameObject rowPrefab;
    private float newPlatformYPos = 0f;
    private HeroMovement hero;
    private Queue<GameObject> platforms = new Queue<GameObject>();
    private Transform tempGO;
    private void Awake() 
    {
        CreateStartPlatforms();
        hero.OnHeroLandedNewPlatform += AddUpPlatform;
    }
    private void OnDestroy() 
    {
        hero.OnHeroLandedNewPlatform -= AddUpPlatform;
    }

    [Inject]
    private void Construct(HeroMovement _hero)
    {
        hero = _hero;
    }

    public override void InstallBindings()
    {
        Container.Bind<RowGenerator>().FromInstance(this).AsSingle().NonLazy();
    }

    private void CreateStartPlatforms()
    {
        CreatePlatform(5);
    }

    private void CreatePlatform(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 pos = new Vector3(0f, newPlatformYPos, 0f);
            Quaternion quar = Quaternion.Euler(0, 0, 90);
            var platform = GameObject.Instantiate(rowPrefab, pos, quar) as GameObject;
            
            if(newPlatformYPos > 0f)
            {
                if(Random.Range(0,11)%2 == 0) AddRandomTriggerObject(platform.transform);
            }

            platforms.Enqueue(platform);
            platform.transform.SetParent(this.transform);
            newPlatformYPos += 2.5f;
        }
    }

    private void RemoveBottomPlatform()
    {
        GameObject platformToRemove = platforms.Peek();
        platforms.Dequeue();
        Destroy(platformToRemove);
    }

    private void AddUpPlatform()
    {
        CreatePlatform(1);
        RemoveBottomPlatform();
    }

    private void AddRandomTriggerObject(Transform platform)
    {
        int randomIndex = Random.Range(0, triggerObjects.Count);
        float xPosEdge = GetScreenWidthBorder(triggerObjects[randomIndex].width);
        float randX = Random.Range(-xPosEdge, xPosEdge);
        float randY = newPlatformYPos + Random.Range(triggerObjects[randomIndex].yMin, triggerObjects[randomIndex].yMax);        
        var triggerObject = GameObject.Instantiate(triggerObjects[randomIndex].prefab) as GameObject;
        triggerObject.transform.position = new Vector3(randX, randY, 0f);
        triggerObject.transform.SetParent(platform);   
    }

    public float GetScreenWidthBorder(float colliderWidth)
    {
        var screenEdge = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f));
        return screenEdge.x - colliderWidth * 0.5f;
    }  
}

 
