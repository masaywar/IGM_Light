using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CustomTile : MonoBehaviour
{
    private BoardManager m_boardManager;

    [Header("Tile Properties")]
    public int Row;

    public int Column;

    public Vector3 Position
    {
        get => new Vector3(Row, Column);
    }

    public ColorType TileColor;
    public SpriteRenderer m_SpriteRenderer;

    public bool HasObstacle
    {
        get
        {
            if(Obstacle == null)
                return false;

            return Obstacle.gameObject.activeSelf;
        }
    }

    public bool HasFilter
    {
        get
        {
            if(Filter == null)
                return false;

            return Filter.gameObject.activeSelf;
        }
    }

    public bool IsInteractable = true;

    public Filter Filter;
    public Obstacle Obstacle;

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
