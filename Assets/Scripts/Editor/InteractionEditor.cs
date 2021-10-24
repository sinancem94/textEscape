using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Interaction))]
public class InteractionEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //comment
        base.OnInspectorGUI();
        Interaction interaction = (Interaction)target;

        /*int totalProbability = 0;
        foreach (var outcome in interaction.possibleOutcomes)
        {
            totalProbability += outcome.possibility;
        }

        EditorGUILayout.HelpBox("Total possibility must 100 on possible outcomes", MessageType.Error);*/


    }
}



