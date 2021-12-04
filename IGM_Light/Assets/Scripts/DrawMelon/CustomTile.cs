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

    public int enterNum = 1;
    public int index;

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

    public bool HasWeakTile
    {
        get
        {
            if (wt == null)
                return false;

            return wt.gameObject.activeSelf;
        }
    }

    public bool HasIceTile
    {
        get
        {
            if (it == null)
                return false;

            return it.gameObject.activeSelf;
        }
    }

    public bool HasWhitePortal
    {
        get
        {
            if (w_portal == null)
                return false;

            return w_portal.gameObject.activeSelf;
        }
    }

    public bool HasBlackPortal
    {
        get
        {
            if (b_portal == null)
                return false;

            return b_portal.gameObject.activeSelf;
        }
    }

    public bool IsInteractable = true;

    public Filter Filter;
    public Obstacle Obstacle;
    public WeakTile wt;
    public IceTile it;
    public Portal w_portal;
    public Portal b_portal;

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
