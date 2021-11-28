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
    private Image _backGroundImage;
    private UIManager _uiManager;
    public SpriteDatabaseLoader SpriteDatabase;

    [SerializeField]private int _showingIndex = 0;
    [SerializeField] private Transform _worldContainer;
    [SerializeField] private Transform[] _buttons;

    public float Threshold;
    
    private LeanFingerSwipe _fingerSwipe;
    private LeanTouch _leanTouch;

    private float _distance;
    protected override void Awake()
    {
        _uiManager = UIManager.Instance;

        _backGroundImage = GetComponent<Image>();
        _backGroundImage.sprite = SpriteDatabase.BackgroundSprites[_showingIndex].sprites[UserDataInstance.Instance.WorldsLastClearData[_showingIndex]];
    
        _fingerSwipe = FindObjectOfType<LeanFingerSwipe>();
        _leanTouch = FindObjectOfType<LeanTouch>();

        base.Awake();
    }

    public override void Close()
    {
        _worldContainer.localPosition = Vector3.zero;
        _fingerSwipe.enabled = true;
        _leanTouch.enabled = true;
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

    public void SetNextWorld()
    {
        if (_showingIndex < SpriteDatabase.BackgroundSprites.Count-1)
            _backGroundImage.sprite = SpriteDatabase.BackgroundSprites[++_showingIndex].sprites[UserDataInstance.Instance.WorldsLastClearData[_showingIndex]];
    } 

    public void SetPrevWorld()
    {
        if (_showingIndex != 0)
            _backGroundImage.sprite = SpriteDatabase.BackgroundSprites[--_showingIndex].sprites[UserDataInstance.Instance.WorldsLastClearData[_showingIndex]];
    }
    public void OnSelectWorld()
    {
        UserDataInstance.Instance.CurrentWorld = _showingIndex + 1;

        var uiStage = _uiManager.GetWindow<UIStageSelect>("UIStageSelect");
        uiStage.World = UserDataInstance.Instance.CurrentWorld;
        uiStage.Open(true);
    }

    #if UNITY_EDITOR
    private void Update()
    {

    }
    #endif

    public void OnSwipe(Vector3 swipe)
    {
        if(_distance <= Threshold)
        {
            OnSelectWorld();
            return;
        }

        if (swipe.x < 0)
        {
            SetNextWorld();
        }

        else
        {
            SetPrevWorld();
        }
    }

    public void OnDistance(Single distance)
    {
        _distance = distance;
    }
}
