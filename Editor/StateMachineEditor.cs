using Jacklog.FiniteStateMachine;
using UnityEditor;
using UnityEngine;

namespace Jacklog.FiniteStateMachineEditor
{
    [CustomEditor(typeof(StateMachine))]
    public class StateMachineEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            StateMachine stateMachine = (StateMachine)target;
            if(GUILayout.Button("Initialize"))
            {
                if (!Application.isPlaying) return;
                stateMachine.Initialize();
            }
        }
    }
}