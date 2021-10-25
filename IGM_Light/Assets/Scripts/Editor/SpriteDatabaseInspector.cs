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
        if (GUILayout.Button("Load Filters"))
        {
            LoadFilters();
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
        var CharSpriteDic = _spriteDatabase.CharacterSprites;

        if (CharSpriteDic.Count > 0){
            CharSpriteDic.Clear();
        }

        string[] dirPaths = Directory.GetDirectories(path[1]);
        ColorType cType = ColorType.Basic;
        
        dirPaths.ForEach(dirPath=>
        {
            CharSpriteDic.Add(cType, new List<Sprite>());

            Directory.GetFiles(dirPath)
            .Where(file => !file.Contains(".meta"))
            .ForEach(file=> _spriteDatabase.CharacterSprites[cType]
            .Add(AssetDatabase.LoadAssetAtPath<Sprite>(file)));

            cType++;
        });
    }

    public void LoadFilters()
    {
        var path = _spriteDatabase.path[2];
        var filters = _spriteDatabase.FilterSprites;

        if (filters.Count > 0)
            filters.Clear();

        Directory.GetFiles(path)
        .Where(file => !file.Contains(".meta")&&!file.Contains(".spriteatlas"))
        .ForEach(file=>filters.Add(AssetDatabase.LoadAssetAtPath<Sprite>(file)));
    }

}
