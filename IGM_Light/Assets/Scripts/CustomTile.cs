using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CustomTile : MonoBehaviour
{
    public int Column
    {
        get;
        private set;
    }

    public int Row
    {
        get;
        private set;
    }

    public void SetTilePosition(int row, int column)
    {
        Row = row;
        Column = column;    
    }
}
