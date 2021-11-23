using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

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
            Load();
        }
    }

    
    public void Load()
    {
        if (loader.WorldsTable.Count>0)
            loader.WorldsTable.Clear();

        Directory.GetDirectories(loader.path).ForEach(
            dir => {
                dir = dir.Replace('\\', '/');
                List<GameController> tempList = new List<GameController>();
                
                Directory.GetFiles(dir).ForEach(p => {
                    GameController loaded = AssetDatabase.LoadAssetAtPath<GameController>(p);
                    if(loaded!=null)
                        tempList.Add(loaded);
                });

                WorldsLoader.Table table = new WorldsLoader.Table();
                table.Stages = tempList;
                loader.WorldsTable.Add(table);
            }
        );
    }
}
