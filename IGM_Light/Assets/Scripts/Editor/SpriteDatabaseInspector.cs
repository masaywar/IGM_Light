using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.U2D;

[CustomEditor(typeof(SpriteDatabaseLoader))]
[CanEditMultipleObjects]
public class SpriteDatabaseInspector : Editor
{
    SpriteDatabaseLoader _spriteDatabase;


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); 
        _spriteDatabase = (SpriteDatabaseLoader) target;
        
        if (GUILayout.Button("Load Tile"))
        {
            LoadTile();
        }
        if (GUILayout.Button("Load Character"))
        {
            LoadCharacter();
        }
    }

    public void LoadTile()
    {
        var path = _spriteDatabase.path;
        var Sprites = _spriteDatabase.TileSprites;

        if (Sprites.Count > 0 )
            Sprites.Clear();

        string[] dirPaths = Directory.GetFiles(path[0]);
        
        dirPaths.ForEach(file=>{
            Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(file);
            if(sprite != null)
                Sprites.Add(sprite);
        });
    }

    public void LoadCharacter()
    {
        var path = _spriteDatabase.path;
        var Sprites = _spriteDatabase.TileSprites;

        var CharSpriteDic = _spriteDatabase.CharacterSprites;

        if (CharSpriteDic.Count > 0){
            CharSpriteDic.Clear();
        }

        if (Sprites.Count > 0 )
            Sprites.Clear();

        string[] dirPaths = Directory.GetDirectories(path[1]);
        ColorType cType = ColorType.Basic;
        
        dirPaths.ForEach(dirPath=>
        {
            Debug.Log(cType);

            CharSpriteDic.Add(cType, new List<Sprite>());

            Directory.GetFiles(dirPath)
            .Where(file => !file.Contains(".meta"))
            .ForEach(file=> _spriteDatabase.CharacterSprites[cType]
            .Add(AssetDatabase.LoadAssetAtPath<Sprite>(file)));

            cType++;
        });
    }
}
