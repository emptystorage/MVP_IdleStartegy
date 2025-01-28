using System;

namespace Code.Core.StateMachine
{
    public abstract class State<T> : IState<T>
        where T : class, IStateMachineOwner<T>
    {
        public T Owner { get; set; }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
