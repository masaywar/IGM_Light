using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StageDatabase : ScriptableObject
{

    public string Path;
    public List<GameStage[]> stages = new List<GameStage[]>();

    public void OnDatabaseLoad()
    {
        var resources = Resources.LoadAll<GameStage>(Path);
    }
}
