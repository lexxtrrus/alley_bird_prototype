using System;
using GameLogic;
using Zenject;

namespace States
{
    public class EntryPointState :  IState
    {
        private const string InitScene = "InitScene";
        private const string MainMenuScene = "MainMenuScene";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public EntryPointState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load(name: InitScene, onLoaded: LoadMainMenu);
        }

        public void Exit()
        {
             
        }

        private void LoadMainMenu()
        {
            _stateMachine.Enter<LoadingSceneState, string, Action>(payload: MainMenuScene, onloaded: OnMainMenuLoaded);
        }

        private void OnMainMenuLoaded()
        {
            _stateMachine.Enter<MainMenuState>();
        }

        private void RegisterServices()
        {
            
        }
    }
} 