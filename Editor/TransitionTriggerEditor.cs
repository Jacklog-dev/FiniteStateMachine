using Jacklog.FiniteStateMachine;
using UnityEditor;
using UnityEngine;

namespace Jacklog.FiniteStateMachineEditor
{
    [CustomEditor(typeof(TransitionTrigger))]
    public class TransitionTriggerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            TransitionTrigger trigger = (TransitionTrigger)target;
            if(GUILayout.Button("Initialize"))
            {
                trigger.Dispatch();
            }
        }
    }
}