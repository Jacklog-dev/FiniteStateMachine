using System;
using UnityEngine;

namespace Jacklog.FiniteStateMachine
{
    [UnityEngine.CreateAssetMenu(fileName = "State", menuName = "Jacklog/StateMachine/TransitionEvent", order = 0)]
    public abstract class TransitionEvent : ScriptableObject
    {
        public event Action<State> OnTransitionTriggerd; 

        [SerializeField] private State _targetState;

        public void Dispatch()
        {
            
        }
    }
}