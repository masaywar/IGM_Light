using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager: MonoBehaviour
{
    public SpriteDatabaseLoader m_spriteDatabase;

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

    /// <summary>
    /// Get Tile with column and row. 
    /// </summary>
    /// <param name="col"></param>
    /// <param name="row"></param>
    /// <returns></returns>
    public CustomTile GetTile(int row, int col)
    {
        if (col < 0 || row < 0 || row >= Length || col >= Length)
            return null;

        int index = row*Length + col%Length;
        
        if (index >= Length*Length)
            return null;
        
        return Tiles[row*Length + col%Length];
    }

    /// <summary>
    /// Get Tile safely with column and row. And return boolean if get target tile successfully. Or return false.
    /// </summary>
    /// <param name="col"></param>
    /// <param name="row"></param>
    /// <param name="customTile"></param>
    /// <returns></returns>
    public bool TryGetTile(int row, int col, out CustomTile customTile)
    {
        var target = GetTile(row, col);
        customTile = target;

        return target != null;
    }

    public void SetTileColor(CustomTile tile, ColorType colorType)
    {
        tile?.ModTileColor(m_spriteDatabase.TileSprites[(int)colorType], colorType);
    }

    public void SetTileColor(int row, int col, ColorType colorType)
    {
        if (TryGetTile(row, col, out var target))
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
        if(m_spriteDatabase.CharacterSprites[(int)colorType].sprites.Count <= index)
            return null;

        return m_spriteDatabase.CharacterSprites[(int)colorType].sprites[index];
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
        Tiles[tile.Row*Length + tile.Column%Length] = tile;
    }

    public void ResetBoard()
    {
        foreach(var tile in Tiles)
        {
            if(tile.transform.childCount > 0)
                tile.transform.GetChild(0).gameObject.SetActive(true);
            tile.ModTileColor(GetTileSprite(ColorType.Basic), ColorType.Basic);
            tile.IsInteractable = true;
        }
    }
}
