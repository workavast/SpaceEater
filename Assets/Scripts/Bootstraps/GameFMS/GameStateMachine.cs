using System;
using System.Collections.Generic;

namespace SourceCode.Bootstraps.GameFMS
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, GameStateBase> _states;
        private GameStateBase _activeState; 

        public GameStateMachine(Type initialState, List<GameStateBase> states)
        {
            _states = new Dictionary<Type, GameStateBase>();
            foreach (var state in states)
                _states.Add(state.GetType(), state);

            _activeState = _states[initialState];
            _activeState.Enter();
        }

        public void ManualUpdate()
        {
            _activeState.ManualUpdate();
        }

        public void ManualFixedUpdate()
        {
            _activeState.ManualFixedUpdate();
        }

        public void SetState<TGameState>() 
            where TGameState : GameStateBase
        {
            var type = typeof(TGameState);
            
            if(_activeState.GetType() == type)
                return;
            
            _activeState.Exit();
            _activeState = _states[type];
            _activeState.Enter();
        }
    }
}