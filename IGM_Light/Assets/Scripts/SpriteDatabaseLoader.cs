using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

[CreateAssetMenu(menuName = "IGM_Light/SpriteDatabaseLoader")]
public class SpriteDatabaseLoader : ScriptableObject
{
    public List<Sprite> TileSprites;
    public List<Sprite> FilterSprites;
    public List<Sprite> BackgroundSprites;
    public Dictionary<ColorType, List<Sprite>> CharacterSprites = new Dictionary<ColorType, List<Sprite>>();

    /// <summary>
    ///  0 : Tile Sprite
    ///  1 : Charachter Sprite
    ///  2 : Filter Sprite
    ///  3 : Background Sprite
    /// </summary>
    public string[] path;
}
