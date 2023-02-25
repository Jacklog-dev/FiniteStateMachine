using System;
using UnityEngine;
using UnityEngine.Events;

namespace Jacklog.FiniteStateMachine
{
    public class StateEventListener : MonoBehaviour
    {
        [SerializeField] private State _state;
        [SerializeField] private UnityEvent _initialize;
        [SerializeField] private UnityEvent _onEnter;
        [SerializeField] private UnityEvent _onExit;

        private void OnEnable()
        {
            _initialize.Invoke();
            _state.OnEnter += DispatchOnEnter;
            _state.OnExit += DispatchOnExit;
        }

        private void OnDisable()
        {
            _state.OnEnter -= DispatchOnEnter;
            _state.OnExit -= DispatchOnExit;
        }

        private void DispatchOnExit()
        {
            _onExit.Invoke();
        }

        private void DispatchOnEnter()
        {
            _onEnter.Invoke();
        }
    }
}