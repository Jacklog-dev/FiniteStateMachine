using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Jacklog.FiniteStateMachine
{
    [UnityEngine.CreateAssetMenu(fileName = "State", menuName = "Jacklog/StateMachine/State", order = 0)]
    public class State : ScriptableObject
    {
        public event Action<State> OnChangeState;
        
        [SerializeField] private string _identifier;

        [SerializeField] private List<State> _children;
        
        [SerializeField] private List<TransitionEvent> _transitions;
        

        private State _parent;

        public void AssignParent(State parent)
        {
            _parent = parent;
        }

        public bool HasChild(State childState)
        {
            return Enumerable.Contains(_children, childState);
        }

        public void SubscribeTransitionEvents()
        {
            foreach (var transitionEvent in _transitions)
            {
                transitionEvent.OnTransitionTriggerd += HandleTransitionTriggerd;
            }
        }

        public void UnsubscribeEvents()
        {
            foreach (var transitionEvent in _transitions)
            {
                transitionEvent.OnTransitionTriggerd -= HandleTransitionTriggerd;
            }
        }

        private void HandleTransitionTriggerd(State newState)
        {
            if (!_parent.HasChild(newState))
            {
                return; 
            }

            OnChangeState?.Invoke(newState);
        }

        public override bool Equals(object obj)
        {
            var item = obj as State;
            return item != null && item._identifier.Equals(_identifier);
        }
    }
}