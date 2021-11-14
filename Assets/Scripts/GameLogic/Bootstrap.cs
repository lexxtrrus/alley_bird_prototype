using UnityEngine;
using Zenject;

namespace GameLogic
{
    public class Bootstrap: MonoInstaller
    {
        [SerializeField] private EntryApplicationPoint entryApplicationPoint;
        [SerializeField] private LoadingCurtain loadingCurtain;

        public override void InstallBindings()
        {
            BingLoadingCurtain();
            BingGameInstance();
        }

        private void BingGameInstance()
        {
            var entry = Container.InstantiatePrefabForComponent<EntryApplicationPoint>(entryApplicationPoint);
            Container.Bind<EntryApplicationPoint>().FromInstance(entry).AsSingle().NonLazy();
        }

        private void BingLoadingCurtain()
        {
            var curtain = Container.InstantiatePrefabForComponent<LoadingCurtain>(loadingCurtain);
            Container.Bind<LoadingCurtain>().FromInstance(curtain).AsSingle().NonLazy();
        }
    }
}