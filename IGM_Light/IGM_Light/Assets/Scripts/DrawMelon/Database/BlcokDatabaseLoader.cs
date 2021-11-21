using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Linq;
using System.IO;

[CreateAssetMenu(fileName = "BlcokDatabaseLoader", menuName = "IGM_Light/BlcokDatabaseLoader", order = 0)]
public class BlcokDatabaseLoader : ScriptableObject 
{
    [System.Serializable]
    public struct BlockList
    {
        public List<GameObject> Blocks;

        public BlockList(List<GameObject> blocks)
        {
            Blocks = blocks;
        }
    }

    public string path;
    public List<BlockList> Blocks = new List<BlockList>();

    #if UNITY_EDITOR
    public void Load()
    {
        if (Blocks.Count>0)
            Blocks.Clear();

        Directory.GetDirectories(path)
        .Where(dir=>!dir.Contains(".meta"))
        .ForEach(dir=>{
            List<GameObject> blocks = new List<GameObject>();
            Directory.GetFiles(dir)
            .Where(file=>!file.Contains(".meta"))
            .ForEach(file=>{
                blocks.Add(AssetDatabase.LoadAssetAtPath<GameObject>(file));
            });
        });
    }
    #endif
}
