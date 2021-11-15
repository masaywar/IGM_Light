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
        get => SolvedList.Count == _numOfBlocks;
    }

    public Player Player;
    public int[] Standard;
   

    [Tooltip("0 : Basic, 1 : Blue, 2 : Cyan, 3 : Green, 4 : Pink, 5 : Purple, 6 : Red, 7 : Yellow")]
    public CustomBlocks[] TargetTable;
    [Tooltip("0 : Basic, 1 : Blue, 2 : Cyan, 3 : Green, 4 : Pink, 5 : Purple, 6 : Red, 7 : Yellow")]
    public List<CustomBlock> SolvedList;

    private BoardManager _boardManager;
    private int _length; 
    private int _numOfBlocks;


    private void Awake()
    {
         _boardManager = GetComponent<BoardManager>();
        Player = _boardManager.GetComponentInChildren<Player>();

        _length = _boardManager.Length;

        foreach(var row in TargetTable)
        {
            _numOfBlocks += row.Blocks.Count;
        }
    }   

    public void Match(ColorType colorType)
    {
        var valids = TargetTable[(int)colorType];

        for(int index=0; index < valids.Blocks.Count; index++)
        {
            var block = valids.Blocks[index];
            bool isFind = false;
            if(block == null)
            {
                valids.Blocks.Add(block);
                return;
            }

            for(int dRow=0; dRow<Size; dRow++)
            {
                for(int dCol=0; dCol<Size; dCol++)
                {
                    int count = 0;
                    foreach(var form in block.Form)
                    {
                        if(!_boardManager.TryGetTile(form.x+dRow, form.y+dCol, out var tile))
                            break;

                        if(tile.IsInteractable && tile.TileColor == colorType)
                            count += 1;
                    }

                    if (count == Size)
                    {
                        foreach(var form in block.Form)
                        {
                            var tile = _boardManager.GetTile(form.x+dRow, form.y+dCol); 
                            tile.OnMadeBlock();
                        }

                        SolvedList.Add(block);
                        isFind = true;
                        break;
                    }
                }
                if(isFind)
                    break;
            }
        }
    }

    public void OnSolved()
    {
        int step = Player.Step;
        
        int score = 0;

        if (step <= Standard[0])
            score = 3;
        else if(step <= Standard[1])
            score = 2;
        else
            score = 1;

        var uiScore = UIManager.Instance.GetWindow<UIScore>("UIScore");

        uiScore.Open(true);
        uiScore.ShowScore(score);
    }

    public void ResetGame()
    {
        int loop = SolvedList.Count;
        SolvedList.Clear();

        Player.ResetPlayer();
        _boardManager.ResetBoard();
    }
}

