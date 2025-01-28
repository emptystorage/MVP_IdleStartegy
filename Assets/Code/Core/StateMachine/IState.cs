using System;

namespace Code.Core.StateMachine
{
    public interface IState<T> : IDisposable
        where T : class, IStateMachineOwner<T>
    {
        T Owner { get; set; }

        void Enter();
        void Update();
        void Exit();
    }
}
