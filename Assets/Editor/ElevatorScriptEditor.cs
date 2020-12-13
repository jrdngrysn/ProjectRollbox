using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ElevatorScript))]
public class ElevatorScriptEditor : Editor
{


    public override void OnInspectorGUI()
    {
       
        ElevatorScript scr = (ElevatorScript)target;

        Rigidbody2D rb = scr.GetComponent<Rigidbody2D>();
        scr.rb = rb;

        base.OnInspectorGUI();

        if (scr.usedButton == null && !scr.alwaysActive)
        {
            EditorGUILayout.HelpBox("No button is assigned! Assign a button in the scene or enable Always Active.", MessageType.Error);
        }
        else if (!scr.usedButton.GetComponent<ButtonScript>() && !scr.alwaysActive)
        {
            EditorGUILayout.HelpBox("The 'Used Button' does not have a ButtonScript.cs component attached! The elevator/door will not function.",MessageType.Error);
        }

        GUILayout.Space(10);
        EditorGUILayout.LabelField("Set Platform Positions",EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Sets the target move position for the platform. Position on scene start will be its starting position.",EditorStyles.miniLabel);

        if (!Application.isPlaying)
        {
            scr.PlatStart = scr.rb.position;
        
            if (GUILayout.Button("Set Target Position"))
            {
                scr.CreateEndPosition();
            }
        }



        EditorGUILayout.LabelField("Start Position: " + scr.PlatStart);
        EditorGUILayout.LabelField("Target Position: " + scr.PlatEnd);

    }
}
