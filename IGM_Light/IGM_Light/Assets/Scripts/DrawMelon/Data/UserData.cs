using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class UserData
{
    public int Worlds;
    public int Stages;

    public bool[] UserClearData;

    public int[] UserScoreData;

    public UserData(
        int worlds,
        int stages,
        bool[] userClearData,
        int[] userScoreData)
    {
        Worlds = worlds;
        Stages = stages;
        UserClearData = userClearData;
        UserScoreData = userScoreData;
    }
}
