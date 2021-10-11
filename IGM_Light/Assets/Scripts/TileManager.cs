using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager: MonoBehaviour
{
    [SerializeField] private Tile _baseTile;
    [SerializeField] private int _length;
    public int Length
    {
        get=>_length;
    }
    
    [SerializeField] private Tile[] _tiles;

    public Tile[] Tiles
    {
        get 
        {
            if(_tiles == null)
            {
                _tiles = new Tile[Length*Length];
            }

            return _tiles;
        }
    } 

   

    private void Awake()
    {
        TryInitialize();
    }

    private void TryInitialize()
    {
        _tiles = new Tile[Length*Length];
        SpawnTiles();
    }

    private void SpawnTiles()
    {
        for (int idx=0; idx < Length*Length; idx++)
        {
            Tiles[idx] = Instantiate(_baseTile, transform);
            Tiles[idx].SetTilePosition(idx/Length, idx%Length);
        }
    }
}
