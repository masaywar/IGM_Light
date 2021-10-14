using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WorldsLoader))]
public class WorldsLoaderInspector : Editor
{
    public WorldsLoader loader;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        loader = (WorldsLoader)target;

        if (GUILayout.Button("Worlds Load"))
        {
            loader.Load();
        }
    }
}
