using System.Xml.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

[CreateAssetMenu(menuName = "IGM_Light/SpriteDatabaseLoader")]
public class SpriteDatabaseLoader : ScriptableObject
{
    [Serializable]
    public struct Sprites
    {
        public List<Sprite> sprites;
        
        public Sprites(List<Sprite> sprites)
        {
            this.sprites = sprites;
        }

        public void SetSprites(List<Sprite> sprites)
        {
            this.sprites = sprites;
        }
    }

    public List<Sprite> TileSprites;
    public List<Sprite> FilterSprites;
    public List<Sprite> BackgroundSprites;

    public List<Sprites> CharacterSprites = new List<Sprites>(); 
    public List<Sprites> BlockSprites = new List<Sprites>();

    [Tooltip("0 : Tile, 1 : Character, 2 : Filter, 3 : Background, 4 : Blocks")]
    /// <summary>
    ///  0 : Tile Sprite
    ///  1 : Character Sprite
    ///  2 : Filter Sprite
    ///  3 : Background Sprite
    ///  4 : Blocks Sprite
    /// </summary>
    
    public string[] path;
}
