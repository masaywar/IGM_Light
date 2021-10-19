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
    public SpriteRenderer m_SpriteRenderer;

   

    private void Awake()
    {
        m_boardManager = transform.parent.GetComponent<BoardManager>();
    }

    public void ModTileColor(Sprite tileColor, ColorType colorType)
    {
        TileColor = colorType;
        m_SpriteRenderer.sprite = tileColor;
    }    
}
