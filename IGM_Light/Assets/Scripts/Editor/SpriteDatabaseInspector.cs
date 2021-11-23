using System.Net.Http;
using System.Linq;
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

        if (GUILayout.Button("Load Backgrounds"))
        {
            LoadBackgrounds();
        }

        if (GUILayout.Button("Load Blocks"))
        {
            LoadBlocks();
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
        var CharSprites = _spriteDatabase.CharacterSprites;
        
        CharSprites.Clear();

        string[] dirPaths = Directory.GetDirectories(path[1]);
        ColorType cType = ColorType.Basic;
        
        dirPaths.ForEach(dirPath=>
        {
            CharSprites.Add(new SpriteDatabaseLoader.Sprites(new List<Sprite>()));
            
            Debug.Log(dirPath);

            Directory.GetFiles(dirPath)
            .Where(file => !file.Contains(".meta"))
            .ForEach(file=> CharSprites[(int)cType].sprites
            .Add(AssetDatabase.LoadAssetAtPath<Sprite>(file)));

            cType++;
        });

        Debug.Log(CharSprites);
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

    public void LoadBlocks()
    {
        var path = _spriteDatabase.path[4];
        var blocksSprites = _spriteDatabase.BlockSprites;

        blocksSprites.Clear();
        blocksSprites.Add(new SpriteDatabaseLoader.Sprites(new List<Sprite>()));

        Directory
        .GetFiles(path)
        .Where(sheet=>!sheet.Contains(".meta"))
        .ForEach(sheet=>{
            sheet = sheet.Split(new string[]{"Resources/"}, StringSplitOptions.None)[1];
            sheet = sheet.Replace('\\', '/');
            sheet = sheet.Replace(".png", "");
            Debug.Log(sheet);
            var spriteSheet = Resources.LoadAll<Sprite>(sheet).ToList();

            blocksSprites.Add(new SpriteDatabaseLoader.Sprites(spriteSheet));
        });
    }

    public void LoadBackgrounds()
    {
        var path = _spriteDatabase.path[3];
        var backgroundSprites = _spriteDatabase.BackgroundSprites;

        backgroundSprites.Clear();

        Directory
        .GetDirectories(path)
        .Where(directory=>!directory.Contains(".meta"))
        .ForEach(directory=>{
            directory = directory.Split(new string[]{"Resources/"}, StringSplitOptions.None)[1];
            directory = directory.Replace('\\', '/');
            var spriteSheet = Resources.LoadAll<Sprite>(directory).ToList();

            backgroundSprites.Add(new SpriteDatabaseLoader.Sprites(spriteSheet));
        });      
    }
}