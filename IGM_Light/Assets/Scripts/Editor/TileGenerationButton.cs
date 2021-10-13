using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BoardManager))]
public class TileGenerationButton : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); 

        BoardManager generator = (BoardManager)target;
        if (GUILayout.Button("Generate Cubes"))
        {
            generator.GenerateTiles();
        }
    }
}
