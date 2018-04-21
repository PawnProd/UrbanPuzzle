using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(Cell))]
public class CellEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Cell script = (Cell)target;
        if (GUILayout.Button("Generate Cell"))
        {
            script.GenerateCell();
        }
    }
}
#endif