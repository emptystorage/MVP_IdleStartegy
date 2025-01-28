namespace Code.Core.StateMachine
{
    public interface IStateMachineOwner<T>
        where T : class, IStateMachineOwner<T>
    {
        StateMachine<T> StateMachine { get; }   
    }
}
