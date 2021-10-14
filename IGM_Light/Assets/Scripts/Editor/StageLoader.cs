using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;



[CreateAssetMenu(menuName = "IGM_Light/WorldsLoader")]
public class WorldsLoader : DatabaseLoader
{
    [System.Serializable]
    public struct Table
    {
        public GameObject[] Stages;
    }

    [SerializeField]
    public List<Table> WorldsTable = new List<Table>();

    public override void Load()
    {
        if (WorldsTable.Count>0)
            WorldsTable.Clear();

        Directory.GetDirectories(path).ForEach(
            dir => {
                dir = dir.Replace('\\', '/');
                List<GameObject> tempList = new List<GameObject>();
                
                Directory.GetFiles(dir).ForEach(p => {
                    GameObject loaded = (GameObject)AssetDatabase.LoadAssetAtPath(p, typeof(GameObject));
                    if(loaded!=null)
                        tempList.Add(loaded);
                });

                Table table = new Table();
                table.Stages = tempList.ToArray();
                WorldsTable.Add(table);
            }
        );
    }
}  