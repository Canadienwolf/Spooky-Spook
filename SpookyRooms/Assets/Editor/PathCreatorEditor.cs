using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PathCreator))]
public class PathCreatorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Generate Path"))
        {
            PathCreator creator = (PathCreator)target;

            creator.GeneratePath();
        }

        if (GUILayout.Button("Add Path"))
        {
            PathCreator creator = (PathCreator)target;

            creator.AddPath();
        }
    }
}
