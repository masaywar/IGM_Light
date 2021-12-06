using UnityEngine;
using System;

[Serializable]
public class UserData
{
    public int Worlds;
    public int Stages;

    public ClearData[] UserClearData;

    public ScoreData[] UserScoreData;

    public UserData(
        int worlds,
        int stages,
        ClearData[] userClearData,
        ScoreData[] userScoreData)
    {
        Worlds = worlds;
        Stages = stages;
        UserClearData = userClearData;
        UserScoreData = userScoreData;
    }
}

[Serializable]
public class ClearData
{
    public bool[] userClearData = new bool[FixedValues.STAGES];

    public ClearData()
    {
        for(int k=0; k<userClearData.Length; k++)
        {
            userClearData[k] = false; 
        }
    }
}

[Serializable]
public class ScoreData
{
    public int[] userScoreData = new int[FixedValues.STAGES];

    public ScoreData()
    {
        for(int k=0; k<userScoreData.Length; k++)
        {
            userScoreData[k] = 0; 
        }
    }
}