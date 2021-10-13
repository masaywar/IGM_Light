using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CustomTile : MonoBehaviour
{
    private BoardManager m_boardManager;

    [Header("Tile Properties")]
    public int  Row;

    public int Column;

    public ColorType TileColor;

    public GameObject Occupied;
    public GameObject[] Candidates;

    private void Awake()
    {
        m_boardManager = transform.parent.GetComponent<BoardManager>();
    }

    public void ModTileColor(ColorType colorType)
    {
        TileColor = colorType;
        var former = Occupied;
        Occupied = Candidates[(int)colorType];

        former.SetActive(false);
        Occupied.SetActive(true);
    }    
}
