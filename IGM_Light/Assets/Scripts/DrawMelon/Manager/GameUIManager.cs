using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class GameUIManager : UIManager 
{
    public GameController Controller;

    public static GameUIManager instance
    {
        get=>(GameUIManager)UIManager.Instance;
    }

    protected override void Initialize()
    {
        base.Initialize();

        Controller = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }
}