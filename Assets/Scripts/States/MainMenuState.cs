using GameLogic;
using UnityEngine;

namespace States
{
    public class MainMenuState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public MainMenuState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Exit()
        {
            
        }

        public void Enter()
        {
            Time.timeScale = 1f;
        }
    }
}