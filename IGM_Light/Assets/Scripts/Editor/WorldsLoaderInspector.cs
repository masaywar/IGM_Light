using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(WorldsLoader))]
public class WorldsLoaderInspector : Editor
{
    /*public WorldsLoader loader;

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
                List<GameObject> tempList = new List<GameObject>();
                
                Directory.GetFiles(dir).ForEach(p => {
                    GameObject loaded = (GameObject)AssetDatabase.LoadAssetAtPath(p, typeof(GameObject));
                    if(loaded!=null)
                        tempList.Add(loaded);
                });

                WorldsLoader.Table table = new WorldsLoader.Table();
                table.Stages = tempList.ToArray();
                loader.WorldsTable.Add(table);
            }
        );
    }*/
}
