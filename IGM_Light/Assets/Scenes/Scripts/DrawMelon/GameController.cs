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

        if(!uiScore.IsOpen())
        {
            uiScore.Open(true);
            uiScore.ShowScore(score);

            if (UserDataInstance.Instance.UserData.Stages != FixedValues.STAGES 
                && UserDataInstance.Instance.CurrentStage > UserDataInstance.Instance.UserData.Stages)
                UserDataInstance.Instance.UserData.Stages++;
            
            else if(UserDataInstance.Instance.UserData.Stages == FixedValues.STAGES)
            {
                UserDataInstance.Instance.UserData.Worlds++;
                UserDataInstance.Instance.UserData.Stages = 0;
            }

            UserDataInstance.Instance.UserData.UserClearData[
                UserDataInstance.Instance.CurrentWorld-1].userClearData[
                UserDataInstance.Instance.CurrentStage-1] = true;
            
            UserDataInstance.Instance.UserData.UserScoreData[
                UserDataInstance.Instance.CurrentWorld-1].userScoreData[
                UserDataInstance.Instance.CurrentStage-1]
                = Mathf.Max(score, UserDataInstance.Instance.UserData.UserScoreData[
                UserDataInstance.Instance.CurrentWorld-1].userScoreData[
                UserDataInstance.Instance.CurrentStage-1]);

            UserDataInstance.Instance.SaveData();
            UserDataInstance.Instance.LoadData();
        }
    }

    public void ResetGame()
    {
        int loop = SolvedList.Count;
        SolvedList.Clear();

        Player.ResetPlayer();
        _boardManager.ResetBoard();
    }
}

