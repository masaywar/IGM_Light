using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
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

    [SerializeField] private int col, row;

    private void Update()
    {
        col = Column;
        row = Row;
    }

    public void SetTilePosition(int row, int column)
    {
        Row = row;
        Column = column;    
    }
}
