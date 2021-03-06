using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CustomTile : MonoBehaviour
{
    private BoardManager _boardManager;

    [Header("Tile Properties")]
    public int Row;

    public int Column;

    public Vector2Int Position
    {
        get => new Vector2Int(Row, Column);
    }

    public ColorType TileColor;
    public SpriteRenderer SpriteRenderer;

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
        _boardManager = transform.parent.GetComponent<BoardManager>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ModTileColor(Sprite tileColor, ColorType colorType)
    {
        TileColor = colorType;
        SpriteRenderer.sprite = tileColor;
    }

    public void OnMadeBlock()
    {
        SpriteRenderer.color = new Color(.7f, .7f, .7f);
        IsInteractable = false;
    }

    public override string ToString()
    {
        return "Row : " + Row + " Column : " + Column;
    }
}
