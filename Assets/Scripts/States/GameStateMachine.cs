using System;
using System.Collections.Generic;
using System.ComponentModel;
using GameLogic;
using Zenject;

namespace States
{
    public class GameStateMachine: IGameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain loadingCurtain)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(EntryPointState)] = new EntryPointState(this, sceneLoader),
                [typeof(LoadingSceneState)] = new LoadingSceneState(this, sceneLoader, loadingCurtain),
                [typeof(MainMenuState)] = new MainMenuState(this, sceneLoader),
                [typeof(GameLoopState)] = new GameLoopState(this, sceneLoader),
            };
        }
        
        public void Enter<TState>() where TState: class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload, TAction>(TPayload payload, TAction onloaded) where TState : class, IPayloadedState<TPayload, TAction>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload, onloaded);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;
            return state;
        }

        public TState GetState<TState>() where TState: class, IExitableState
        {
            return _states[typeof(TState)] as TState;
        }
    }
}