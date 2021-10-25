using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager: MonoBehaviour
{
    [SerializeField] public SpriteDatabaseLoader m_spriteDatabase;

    private List<Sprite> _sprites;


    [Space(2)]
    [Header("Board Properties")]
    
    public int World=0;
    public int Stage=0;

    [Range(3, 5)]
    [SerializeField] private int _length=3;
    
    public int Length
    {
        get=>_length;
    }
    
    public CustomTile[] Tiles;

    private void Awake()
    {
        TryInitialize();
    }

    private void TryInitialize()
    {
        _sprites = m_spriteDatabase.TileSprites;
    }

    /// <summary>
    /// Get Tile with column and row. 
    /// </summary>
    /// <param name="col"></param>
    /// <param name="row"></param>
    /// <returns></returns>
    public CustomTile GetTile(int col, int row)
    {
        if (col < 0 || row < 0)
            return null;

        int index = col*Length + row%Length;
        
        if (index > Length*Length)
            return null;
        
        return Tiles[col*Length + row%Length];
    }

/// <summary>
/// Get Tile safely with column and row. And return boolean if get target tile successfully. Or return false.
/// </summary>
/// <param name="col"></param>
/// <param name="row"></param>
/// <param name="customTile"></param>
/// <returns></returns>
    public bool TryGetTile(int col, int row, out CustomTile customTile)
    {
        var target = GetTile(col, row);
        customTile = target;

        return target != null;
    }

    public void SetTileColor(CustomTile tile, ColorType colorType)
    {
        Debug.Log((int)colorType);

        tile?.ModTileColor(m_spriteDatabase.TileSprites[(int)colorType], colorType);
    }

    public void SetTileColor(int col, int row, ColorType colorType)
    {
        if (TryGetTile(col, row, out var target))
            SetTileColor(target, colorType);
    }

    public Sprite GetTileSprite(ColorType colorType)
    {
        int index = (int)colorType;

        if (m_spriteDatabase.TileSprites.Count <= index)
            return null;

        return m_spriteDatabase.TileSprites[index];
    }

    public bool TryGetTileSprite(ColorType colorType, out Sprite sprite)
    {
        sprite = GetTileSprite(colorType);
        return sprite != null;
    }

    public Sprite GetCharacterSprite(ColorType colorType, int index)
    {
        if(m_spriteDatabase.CharacterSprites[colorType].Count <= index)
            return null;

        return m_spriteDatabase.CharacterSprites[colorType][index];
    }

    public bool TryGetCharacterSprite(ColorType colorType, int index, out Sprite sprite)
    {
        sprite = GetCharacterSprite(colorType, index);
        return sprite != null;
    }

    public Sprite GetFilter(ColorType colorType)
    {
        return null;
    }

    public bool TryGetFileter(ColorType colorType, out Sprite sprite)
    {
        sprite = GetFilter(colorType);
        return sprite!=null;
    }

    public void Subscribe(CustomTile tile)
    {
        Tiles[tile.Column*Length + tile.Row%Length] = tile;
    }
}
