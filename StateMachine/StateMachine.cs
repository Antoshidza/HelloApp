using System.Collections.Generic;
using R3;
using Source.Core.Collections;

namespace Source.Core.StateMachine
{
    public class StateMachine<TState>
        where TState : IState
    {
        private readonly TypedMap<TState> _statesMap;
        private readonly ReactiveProperty<TState> _state = new();

        public ReadOnlyReactiveProperty<TState> State => _state;

        public StateMachine(IEnumerable<TState> states) 
            => _statesMap = new TypedMap<TState>(states);

        public void Start<TStateConcrete>()
            where TStateConcrete : TState
        {
            if (!_statesMap.TryGetCast<TStateConcrete>(out var state))
                throw new StateMachineException($"There is no such state as {typeof(TStateConcrete).Name} to start with!");
            SetNewState(state);
        }
        
        public TStateConcrete GetState<TStateConcrete>()
            where TStateConcrete : TState
        {
            _ = _statesMap.TryGetCast<TStateConcrete>(out var state);
            return state;
        }

        public bool TryChangeState(TState state)
        {
            if (_state.Value.Equals(state)) return false;
            _state.Value.OnExit();
            SetNewState(state);
            return true;
        }

        public bool TryChangeState<TStateConcrete>()
            where TStateConcrete : TState 
            => _statesMap.TryGetCast<TStateConcrete>(out var state) && TryChangeState(state);

        private void SetNewState(TState state)
        {
            _state.Value = state;
            state.OnEnter();
        }
    }
}