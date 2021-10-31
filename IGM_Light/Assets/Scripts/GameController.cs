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
    
    private BoardManager m_boardManager;
    private int _length;    

    private Queue<CustomTile> _drawingQueue;
    [SerializeField] private Vector2Int[] _formData;

    [SerializeField, Range(3, 4)] private int _blockElements;
    public CustomBlocks[] TargetTable;

    private void Awake()
    {
        TryInitialize();
    }   

    private void TryInitialize()
    {
        m_boardManager = GetComponent<BoardManager>();
        _formData = new Vector2Int[Size];
        _length = m_boardManager.Length;
    }

    
    public bool Match(ColorType colorType)
    {
        var elements = TargetTable[(int)colorType];

        for(int k=0; k < elements.Blocks.Count; k++)
        {
           var element = elements.Blocks[k];
           foreach(var form in element.Form)
           {
                if(_formData.HasSameValue(form))
                {
                    elements.Blocks.RemoveAt(k);
                    return true;
                }
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

                _formData[k].x -= minRow;
                _formData[k].y -= minCol;
            }
            return true;
        }

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
            if (_drawingQueue.Count == 0)
                _drawingQueue.Enqueue(tile);

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
}

