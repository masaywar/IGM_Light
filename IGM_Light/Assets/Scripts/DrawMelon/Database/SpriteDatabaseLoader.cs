using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "IGM_Light/SpriteDatabaseLoader")]
public class SpriteDatabaseLoader : ScriptableObject
{
    private static SpriteDatabaseLoader instance;

    public static SpriteDatabaseLoader Instance
    {
        get
        {
            if(instance != null)
                return Instance;

            return null;
        }
    }

    [Serializable]
    public class Sprites
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
    public List<Sprites> BackgroundSprites;

    public List<Sprites> CharacterSprites = new List<Sprites>(); 
    public List<Sprites> BlockSprites = new List<Sprites>();

    public List<Sprites> WorldsSprites = new List<Sprites>();

    [Tooltip("0 : Tile, 1 : Character, 2 : Filter, 3 : Background, 4 : Blocks, 5: WorldImage")]
    /// <summary>
    ///  0 : Tile Sprite
    ///  1 : Character Sprite
    ///  2 : Filter Sprite
    ///  3 : Background Sprite
    ///  4 : Blocks Sprite
    /// </summary>
    public string[] path;


    public Sprite GetWorldSprite(int world, int stage)
    {
        if(WorldsSprites.Count > world)
            return null;

        if(WorldsSprites[world].sprites.Count > stage)
            return null;

        return WorldsSprites[world].sprites[stage];
    }

}
