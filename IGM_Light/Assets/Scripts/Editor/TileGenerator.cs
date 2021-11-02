using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(BoardManager))]
[CanEditMultipleObjects]
public class TileGenerator : BaseGenerator
{
    Vector2Int _playerPos;

    [SerializeField] private Player _playerPrefab;

    [SerializeField] private BoardManager boardManager;
    [SerializeField] private CustomTile _tilePrefab; 

    [SerializeField] private Transform _tilesParentTransform;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); 
        
        boardManager = FindObjectOfType<BoardManager>();
        _tilesParentTransform = boardManager.transform;

        EditorGUILayout.Space(16);
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("Generate Player and TIles. You can also Save board as prefab");
        var input = EditorGUILayout.Vector2IntField("Player Position", _playerPos);

        SetupPlayer(input);
     
        if (GUILayout.Button("Generate Tiles"))
        {
            Generate();
        }

        if(GUILayout.Button("Generate Player"))
        {
            GeneratePlayer();
        }

        if(GUILayout.Button("Create Board Prefab"))
        {
            CreatePrefab();
        }

        EditorGUILayout.EndVertical();
    }

    private void SetupPlayer(Vector2Int input)
    {
        if (input.x >= boardManager.Length)
            input.x = boardManager.Length-1;

        else if (input.x < 0)
            input.x = 0;

        if (input.y >= boardManager.Length)
            input.y = boardManager.Length-1;

        else if (input.y < 0)
            input.y = 0;

        _playerPos = input;
    }

    public override void Generate()
    {
        boardManager.Tiles = new CustomTile[boardManager.Length * boardManager.Length];
        
        _tilePrefab = Resources.Load<CustomTile>("Prefabs/Tiles/TestTile");

        if (_tilesParentTransform.childCount > 0)
        {
            while(_tilesParentTransform.childCount > 0)
            {
                DestroyImmediate(_tilesParentTransform.GetChild(0).gameObject);
            }
        }
    
        var sumVec = Vector2.zero;

        for (int row=0; row<boardManager.Length; row++)
        {
            for (int col=0; col<boardManager.Length; col++)
            {
                var tile = Instantiate<CustomTile>(_tilePrefab, _tilesParentTransform);
                tile.Column = col;
                tile.Row = row;

                tile.transform.SetPositionAndRotation(new Vector3(col, -row), Quaternion.identity);

                boardManager.Subscribe(tile);     

                Vector2 tilePos = tile.transform.position;
                sumVec += tilePos;
            }
        }   

        float baseRes = 9 / 16;

        var width = Camera.main.pixelWidth;
        var height = Camera.main.pixelHeight;



        Camera.main.orthographicSize = boardManager.Length+(float)width/height;
        Camera.main.transform.position = sumVec/(boardManager.Length*boardManager.Length);
    }

    public void CreatePrefab()
    {
        string path = "Assets/Resources/Prefabs/Worlds/";
        path += String.Format("World_{0}/", boardManager.World);

        DirectoryInfo info = new DirectoryInfo(path);

        if (!info.Exists)
            Directory.CreateDirectory(path);

        if(_tilesParentTransform != null)
            PrefabUtility.SaveAsPrefabAsset(_tilesParentTransform.gameObject, path+string.Format("Stage_{0}.prefab", (target as BoardManager).Stage));
    }

    public void GeneratePlayer()
    {
        if(boardManager.transform.childCount > 0){
            var child = boardManager.transform.GetChild(0).GetComponent<Player>();

            if(child != null && child.GetType() == typeof(Player))
            {
                DestroyImmediate(child.gameObject);
            }
        }

        _playerPrefab = Resources.Load<Player>("Prefabs/Player/TestPlayer");
        Player player = Instantiate<Player>(_playerPrefab, boardManager.transform);

        player.transform.position = boardManager.GetTile(_playerPos.x, _playerPos.y).transform.position;

        player.transform.SetAsFirstSibling();

        player.col = _playerPos.x;
        player.row = _playerPos.y;
    }
}
