using UnityEngine;

namespace Jacklog.FiniteStateMachine
{
    public class TransitionTrigger : MonoBehaviour
    {
        [SerializeField] private TransitionEvent _event;

        public void Dispatch()
        {
            _event.Dispatch();
        }
    }
}