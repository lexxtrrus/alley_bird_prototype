using System;
using GameLogic;
using Zenject;

namespace States
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState : class, IState;
        void Enter<TState, TPayload, TAction>(TPayload payload, TAction onloaded) where TState : class, IPayloadedState<TPayload, TAction>;
    }
}