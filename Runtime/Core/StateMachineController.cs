using System;
using System.Collections.Generic;
using UnityEngine;

namespace Jacklog.FiniteStateMachine
{
    public class StateMachineController : MonoBehaviour
    {
        [SerializeField] private StateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine.Initialize();
        }
    }
}