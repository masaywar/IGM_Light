using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CustomTile : MonoBehaviour
{

    [Header("Tile Properties")]

    public int Column;
    public int  Row;

    public ColorType TileColor;

    public GameObject Occupied;
    public GameObject[] Candidates;

    public void ModTileColor(ColorType colorType)
    {
        TileColor = colorType;
        var former = Occupied;
        Occupied = Candidates[(int)colorType];

        former.SetActive(false);
        Occupied.SetActive(true);
    }    
}
