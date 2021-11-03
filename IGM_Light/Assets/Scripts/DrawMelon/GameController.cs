using System.Data;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public partial class GameController : MonoBehaviour
{
    [Serializable]
    public struct CustomBlocks
    {
        public List<CustomBlock> Blocks;

        public CustomBlocks(List<CustomBlock> blocks)
        {
            Blocks = blocks;
        }
    }

    public int Size;
    
    public bool IsSolved
    {
        get 
        {
            foreach(var row in TargetTable)
            {
                if (row.Blocks.Count != 0)
                    return false;
            }

            return true;
        }
    }

    private BoardManager m_boardManager;
    public Player Player;
    public int[] Standard;

    private int _length;    

    private Queue<CustomTile> _drawingQueue = new Queue<CustomTile>();
    [SerializeField] private Vector2Int[] _formData;

    [Tooltip("0 : Basic, 1 : Blue, 2 : Cyan, 3 : Green, 4 : Pink, 5 : Purple, 6 : Red, 7 : Yellow")]
    public CustomBlocks[] TargetTable;

    private void Awake()
    {
        TryInitialize();
    }   

    private void TryInitialize()
    {
        m_boardManager = GetComponent<BoardManager>();
        Player = m_boardManager.GetComponentInChildren<Player>();
        _formData = new Vector2Int[Size];
        _length = m_boardManager.Length;
    }

    
    public bool Match(ColorType colorType)
    {
        var elements = TargetTable[(int)colorType];

        for(int k=0; k < elements.Blocks.Count; k++)
        {
           var element = elements.Blocks[k];
            if(_formData.HasSameValue(element.Form))
            {
                elements.Blocks[k].OnSolved();
                elements.Blocks.RemoveAt(k);

                if(IsSolved)
                    OnSolved();

                return true;
            }
        }

        return false;
    }

    public bool TryMakeBlock(int row, int col)
    {
        if(DFS(0, row, col))
        {
            int minRow = _length, minCol = _length;

            for (int k=0; k<Size; k++)
            {
                var tile = _drawingQueue.Dequeue();
                _formData[k] = new Vector2Int(tile.Row, tile.Column);

                minRow = Mathf.Min(minRow, tile.Row);
                minCol = Mathf.Min(minCol, tile.Column);

                tile.IsInteractable = false;
            }

            for(int k=0; k<Size; k++)
            {
                _formData[k].x -= minRow;
                _formData[k].y -= minCol;
            }
            
            return true;
        }

        _drawingQueue.Clear();
        return false;
    }

    private bool DFS(int count, int row, int col)
    {
        if (count == Size)
        {
            return true;
        }
        
        if(m_boardManager.TryGetTile(row, col, out var tile))
        {
            if(!tile.IsInteractable)
                return false;

            if (_drawingQueue.Count == 0)
            {
                _drawingQueue.Enqueue(tile);
                return 
                    DFS(count+1, row+1, col) ||
                    DFS(count+1, row-1, col) ||
                    DFS(count+1, row, col+1) ||
                    DFS(count+1, row, col-1);
            }

            else
            {
                if(_drawingQueue.Peek().TileColor == tile.TileColor)
                {
                    if(!_drawingQueue.Contains(tile))
                    {
                        _drawingQueue.Enqueue(tile);
                        return DFS(count+1, row+1, col) ||
                            DFS(count+1, row-1, col) ||
                            DFS(count+1, row, col+1) ||
                            DFS(count+1, row, col-1);
                    }
                }

                else
                    return false;
            }
        }
            
        return false;
    }

    public void OnSolved()
    {
        int step = Player.mov;
        
        int score = 0;

        if (step <= Standard[0])
            score = 3;
        else if(step <= Standard[1])
            score = 2;
        else
            score = 1;

        var uiScore = GameUIManager.Instance.GetWindow<UIScore>("UIScore");

        uiScore.Open(true);
        uiScore.ShowScore(score);
    }
}

