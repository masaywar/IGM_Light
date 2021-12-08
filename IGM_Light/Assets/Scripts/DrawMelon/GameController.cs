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

    public bool isHack;

    public int Size;
    
    public bool IsSolved
    {
        get  
        {
            if(SolvedList.Count == _numOfBlocks)
            {
                return true;
            }

            return false;
        }
    }

    public int Worlds;
    public int Stages;
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
        _length = _boardManager.Length;

        Worlds = _boardManager.World;
        Stages = _boardManager.Stage; 
         
        Player = _boardManager.GetComponentInChildren<Player>();

        foreach(var row in TargetTable)
        {
            _numOfBlocks += row.Blocks.Count;
        }
    }   

    private void Start()
    {
        if(!isHack)
            UIManager.Instance.GetWindow<UIBackground>("UIBackground").ResetBackground();
    }

    public void Match(ColorType colorType)
    {
        var valids = TargetTable[(int)colorType];
        int nums = valids.Blocks.Count;

        for(int index=0; index < nums; index++)
        {
            var block = valids.Blocks.Pop();
            bool isFind = false;

            if(block == null)
            {
                return;
            }

            for(int dRow=0; dRow<_length; dRow++)
            {
                for(int dCol=0; dCol<_length; dCol++)
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
                            print(block.BlockType);
                            print(form);
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
            if(isFind)
                break;

            valids.Blocks.Insert(index, block);
        }

        if (IsSolved)
            OnSolved();
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

        uiScore.Open();
        uiScore.ShowScore(score);   

        UserDataInstance.Instance.UpdateUserData(score);
    }

    public void ResetGame()
    {
        GameManager.Instance.FadeOut(UserDataInstance.Instance.CurrentWorld+1);
    }
}

