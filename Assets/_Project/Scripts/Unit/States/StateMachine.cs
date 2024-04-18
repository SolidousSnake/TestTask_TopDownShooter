using System;
using System.Collections.Generic;

namespace _Project.Scripts.Unit.States
{
    public sealed class StateMachine
    {
        private readonly Dictionary<Type, IUpdateableState> _registeredStates;
        private IUpdateableState _updateableState;
        
        public StateMachine()
        {
            _registeredStates = new Dictionary<Type, IUpdateableState>();
        }
        
        public void RegisterState(IUpdateableState state) 
        {
            _registeredStates.Add(state.GetType(), state);
        }

        public void Enter<T>() where T : class, IUpdateableState
        {
            _updateableState = ChangeState<T>();
        }

        private T ChangeState<T>() where T : class, IUpdateableState
        {
            return GetState<T>();
        }

        public void Update()
        {
            _updateableState?.Update();
        }
        
        private T GetState<T>() where T : class, IUpdateableState => _registeredStates[typeof(T)] as T;
    }
}