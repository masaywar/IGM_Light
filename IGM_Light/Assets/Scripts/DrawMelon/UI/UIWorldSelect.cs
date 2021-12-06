using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Lean.Common;
using Lean.Touch;

public class UIWorldSelect : UIWindow
{
    private UIManager _uiManager;
    public SpriteDatabaseLoader SpriteDatabase;
    private WorldSelectScrollRect _worldSelectScrollRect;

    private float _distance;
    protected override void Awake()
    {
        _uiManager = UIManager.Instance;
        _worldSelectScrollRect = FindObjectOfType<WorldSelectScrollRect>();
        base.Awake();
    }

    public void OnSelectWorld(int index)
    {
        UserDataInstance.Instance.CurrentWorld = index;

        var uiStage = _uiManager.GetWindow<UIStageSelect>("UIStageSelect");
        uiStage.World = UserDataInstance.Instance.CurrentWorld;

        foreach(var world in _worldSelectScrollRect.WorldTransforms)
        {
            world.GetComponent<Image>().DOFade(0, 1);
        }

        uiStage.Open(true);
    }
}
