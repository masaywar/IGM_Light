using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



[CreateAssetMenu(menuName = "IGM_Light/WorldsLoader")]
public class WorldsLoader : ScriptableObject
{
    [System.Serializable]
    public struct Table
    {
        public GameObject[] Stages;
    }

    [SerializeField]
    public List<Table> WorldsTable = new List<Table>();

    public string path;
}  