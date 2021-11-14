namespace States
{
    public interface IState: IExitableState
    {
        void Enter();
    }
    
    public interface IPayloadedState<TPayload, TAction>: IExitableState
    {
        void Enter(TPayload payload, TAction action);
        
    }

    public interface IExitableState
    {
        void Exit();
    }
}