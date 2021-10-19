using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

[CreateAssetMenu(menuName = "IGM_Light/SpriteDatabaseLoader")]
public class SpriteDatabaseLoader : ScriptableObject
{
    public List<Sprite> Sprites;

    public Dictionary<Enum, Dictionary<string, Sprite>> SpritesDict;

    public string path;
}
