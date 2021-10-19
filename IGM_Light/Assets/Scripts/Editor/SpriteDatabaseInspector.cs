using System.Reflection;
using System.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(SpriteDatabaseLoader))]
[CanEditMultipleObjects]
public class SpriteDatabaseInspector : Editor
{
    SpriteDatabaseLoader _spriteDatabase;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); 
        _spriteDatabase = (SpriteDatabaseLoader) target;
        
        if (GUILayout.Button("Load"))
        {
            Load();
        }
    }

    public void Load()
    {
        var Sprites = _spriteDatabase.Sprites;
        var path = _spriteDatabase.path;

        if (Sprites.Count > 0 )
            Sprites.Clear();

        string[] dirPaths = Directory.GetFiles(path);
        
        dirPaths.ForEach(file=>{
            Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(file);
            if(sprite != null)
                Sprites.Add(sprite);
        });
    }
}
