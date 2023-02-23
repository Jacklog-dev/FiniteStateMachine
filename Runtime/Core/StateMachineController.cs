using System;
using System.Collections.Generic;
using UnityEngine;

namespace Jacklog.FiniteStateMachine
{
    public class StateMachineController : MonoBehaviour
    {
        [SerializeField] private StateMachine _stateMachine;
        [SerializeField] private bool _initializeOnAwake;

        private void Awake()
        {
            _stateMachine.Initialize();
        }
    }
}