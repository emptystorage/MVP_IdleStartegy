using System;
using System.Collections.Generic;

namespace Code.Core.StateMachine
{
    public sealed class StateMachine<T> : IDisposable
        where T : class, IStateMachineOwner<T>
    {
        private readonly Dictionary<Type, IState<T>> StateTable;
        private readonly T Owner;

        private IState<T> _currentState;

        public StateMachine(T owner)
        {
            StateTable = new Dictionary<Type, IState<T>>();
            Owner = owner;
        }

        public void Update()
        {
            _currentState?.Update();
        }

        public void ChangeState<S>(Action<S> callback = null)
            where S : class, IState<T>, new()
        {
            if (_currentState != null && _currentState.GetType().Equals(typeof(S))) return;

            Clear();

            if(!StateTable.TryGetValue(typeof(S), out _currentState))
            {
                _currentState = Activator.CreateInstance<S>();
                _currentState.Owner = Owner;
            }

            callback?.Invoke((S)_currentState);
            _currentState.Enter();
        }

        public void Clear()
        {
            if(_currentState != null)
            {
                StateTable[_currentState.GetType()] = _currentState;
                _currentState.Exit();
                _currentState = null;
            }
        }

        public void Dispose()
        {
            Clear();

            foreach (var item in StateTable)
            {
                item.Value.Dispose();
            }

            StateTable.Clear();

            GC.SuppressFinalize(this);
        }
    }
}
