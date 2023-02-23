using System.Collections.Generic;
using UnityEngine;

namespace Jacklog.FiniteStateMachine
{
    
    [UnityEngine.CreateAssetMenu(fileName = "State", menuName = "Jacklog/StateMachine", order = 0)]
    public class StateMachine : ScriptableObject
    {
        [SerializeField] private List<State> _rootStates;

        public void Initialize()
        {
            foreach (var state in _rootStates)
            {
                //Maybe we only subscribe on enter?
                state.SubscribeTransitionEvents();
                
                //TODO State Events
                //TODO State EventListener;
            }
        }
    }
}