using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Jacklog.FiniteStateMachine
{
    [UnityEngine.CreateAssetMenu(fileName = "State", menuName = "Jacklog/StateMachine/State", order = 0)]
    public class State : ScriptableObject
    {
        public event Action OnEnter;
        public event Action OnExit;
        
        
        [SerializeField] private List<TransitionEvent> _transitions;
        

        public string Id => name;
        public List<TransitionEvent> Transitions => _transitions;
        

        public void DispatchEnterState()
        {
            OnEnter?.Invoke();
        }
        
        public void DispatchExitState()
        {
            OnExit?.Invoke();
        }


        public override bool Equals(object obj)
        {
            var item = obj as State;
            return item != null && item.name == name;
        }
    }
}