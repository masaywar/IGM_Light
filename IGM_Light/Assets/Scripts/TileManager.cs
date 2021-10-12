using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager: Singleton<TileManager>
{
    [Range(3, 5)]
    [SerializeField] private int _length;
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
        Tiles = new CustomTile[Length * Length];
    }

    public CustomTile GetTile(int row, int col)
    {
        return Tiles[col*Length + row%Length];
    }

    public void Subscribe(CustomTile tile)
    {
        Tiles[tile.Column*Length + tile.Column%Length] = tile;
    }
}
