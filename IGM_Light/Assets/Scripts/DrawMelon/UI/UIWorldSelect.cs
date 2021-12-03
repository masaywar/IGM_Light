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
    private Image[] _worldImages;
    private UIManager _uiManager;
    public SpriteDatabaseLoader SpriteDatabase;

    [SerializeField] private Transform _worldContainer;

    private float _distance;
    protected override void Awake()
    {
        _uiManager = UIManager.Instance;

        for(int k=0; k < SpriteDatabase.WorldsSprites.Count; k++)
        {
            int index = k;
            _worldImages[k].sprite = SpriteDatabase.WorldsSprites[k].sprites[UserDataInstance.Instance.WorldsLastClearData[k]];
            _worldImages[k].GetComponent<Button>().onClick.AddListener(()=>OnSelectWorld(index+1));
        }    

        base.Awake();
    }

    public override void Close()
    {
        _worldContainer.localPosition = Vector3.zero;
        base.Close();
    }

    public override void Close(bool isAnim)
    {
        if (isAnim)
        {
            _worldContainer.DOLocalMoveX(0, 0.5f).
            OnStepComplete(() => Close());
        }

        else
        {
            Close();
        }
    }

    public void OnSelectWorld(int index)
    {
        UserDataInstance.Instance.CurrentWorld = index;

        var uiStage = _uiManager.GetWindow<UIStageSelect>("UIStageSelect");
        uiStage.World = UserDataInstance.Instance.CurrentWorld;
        uiStage.Open(true);
    }
}
