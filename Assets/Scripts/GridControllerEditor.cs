using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(GridController))]
public class GridControllerEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GridController script = (GridController)target;
        if (GUILayout.Button("Generate Grid"))
        {
            script.GenerateGrid();
        }
        if (GUILayout.Button("Clear") && EditorUtility.DisplayDialog("Supprimer la grille ?",
                "Etes vous sur de vouloir supprimer la grille ? Cela supprimera toutes les modifications apportées", "Yes", "No"))
        {
            script.Clear();
        }
    }
}
#endif