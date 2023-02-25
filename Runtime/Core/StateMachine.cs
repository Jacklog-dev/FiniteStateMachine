using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Jacklog.FiniteStateMachine
{
    
    [UnityEngine.CreateAssetMenu(fileName = "State", menuName = "Jacklog/StateMachine", order = 0)]
    public class StateMachine : ScriptableObject
    {
        [SerializeField] private List<State> _states;
        [SerializeField] private State _initialState;
        [Header("Debug")]
        [SerializeField] private string _currentStateId;
        
        private State _currentState;

        public void Initialize()
        {
            EnterState(_initialState);
        }

        private void HandleTransitionTriggerd(State newState)
        {
            if (!_states.Contains(newState))
            {
                return; 
            }

            LeaveState(_currentState);
            EnterState(newState);;
        }

        private void LeaveState(State currentState)
        {
            _currentState.DispatchExitState();
            UnsubscribeEvents(_currentState.Transitions);
        }

        private void EnterState(State newStateTransition)
        {
            _currentState = newStateTransition;
            _currentStateId = _currentState.Id;
            
            SubscribeTransitionEvents(_currentState.Transitions);
            _currentState.DispatchEnterState();
        }

        private void SubscribeTransitionEvents(List<TransitionEvent> transitions)
        {
            foreach (var transitionEvent in transitions)
            {
                transitionEvent.OnTransitionTriggerd += HandleTransitionTriggerd;
            }
        }


        private void UnsubscribeEvents(List<TransitionEvent> transitions)
        {
            foreach (var transitionEvent in transitions)
            {
                transitionEvent.OnTransitionTriggerd -= HandleTransitionTriggerd;
            }
        }
    }
}