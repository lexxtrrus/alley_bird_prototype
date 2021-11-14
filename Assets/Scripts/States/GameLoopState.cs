using System;
using GameLogic;
using UnityEngine;

namespace States
{
    public class GameLoopState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public GameLoopState(GameStateMachine stateMachine, SceneLoader sceneLoader)
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