using System;
using System.Collections.Generic;

namespace TopDownShooter
{
    public class FSM
    {
        private FSMStateBase _currentState;

        private Dictionary<Type, FSMStateBase> _states = new();

        public void AddState(FSMStateBase state)
        {
            _states.TryAdd(state.GetType(), state);
        }

        public void SetState<T>() where T : FSMStateBase
        {
            Type type = typeof(T);

            if (_currentState?.GetType() == type) return;

            if(_states.TryGetValue(type, out FSMStateBase newState))
            {
                _currentState?.Exit();
                _currentState = newState;
                _currentState.Enter();
            }   
        }

        public void Update()
        {
            _currentState?.Update();
        }
    }
}


