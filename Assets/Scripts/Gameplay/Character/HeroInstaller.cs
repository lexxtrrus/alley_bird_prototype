using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HeroInstaller : MonoInstaller
{
    [SerializeField] private GameObject heroPrefab;

    public override void InstallBindings()
    {
        var hero = Container.InstantiatePrefabForComponent<HeroMovement>(heroPrefab, transform);
        Container.Bind<HeroMovement>().FromInstance(hero).AsSingle().NonLazy();
    }
}
