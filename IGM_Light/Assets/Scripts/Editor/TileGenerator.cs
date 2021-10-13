using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(BoardManager))]
public class TileGenerator : BaseGenerator
{
    public Transform _tilesParentTransform;
    public CustomTile _tilePrefab; 

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); 

        _tilesParentTransform = GameObject.Find("Tiles").transform;
        if (GUILayout.Button("Generate Tiles"))
        {
            Generate();
        }

        if(GUILayout.Button("Create Board Prefab"))
        {
            CreatePrefab();
        }
    }

    public override void Generate()
    {
        BoardManager boardManager = (BoardManager)target;
        boardManager.Tiles = new CustomTile[boardManager.Length * boardManager.Length];

        
        _tilePrefab = Resources.Load<CustomTile>("Prefabs/Tiles/TestTile");

        if (_tilesParentTransform.childCount > 0)
        {
            while(_tilesParentTransform.childCount > 0)
            {
                DestroyImmediate(_tilesParentTransform.GetChild(0).gameObject);
            }
        }
    
        for (int row=0; row<boardManager.Length; row++)
        {
            for (int col=0; col<boardManager.Length; col++)
            {
                var tile = Instantiate<CustomTile>(_tilePrefab, _tilesParentTransform);
                tile.Column = col;
                tile.Row = row;

                tile.transform.SetPositionAndRotation(new Vector3(col, -row), Quaternion.identity);

                boardManager.Subscribe(tile);     
            }
        }
    }

    public void CreatePrefab()
    {
        string path = "Assets/Resources/Prefabs/Board/";

        DirectoryInfo info = new DirectoryInfo(path);

        if (!info.Exists)
            Directory.CreateDirectory(path);

        if(_tilesParentTransform != null)
            PrefabUtility.SaveAsPrefabAsset(_tilesParentTransform.gameObject, path+string.Format("Board{0}.prefab", (target as BoardManager).Level));
    }
}
