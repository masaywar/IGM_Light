using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager: MonoBehaviour
{
    [Space(2)]
    [Header("Board Properties")]
    
    [SerializeField] Transform _tilesParentTransform;

    public int Level=0;

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
    }

    /// <summary>
    /// Get Tile with column and row. 
    /// </summary>
    /// <param name="col"></param>
    /// <param name="row"></param>
    /// <returns></returns>
    public CustomTile GetTile(int col, int row)
    {
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
        tile?.ModTileColor(colorType);
    }

    public void SetTileColor(int col, int row, ColorType colorType)
    {
        if (TryGetTile(col, row, out var target))
            SetTileColor(target, colorType);
    }

    public void Subscribe(CustomTile tile)
    {
        Tiles[tile.Column*Length + tile.Row%Length] = tile;
    }
}
