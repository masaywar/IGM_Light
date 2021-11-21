using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Lean.Touch;
using Lean.Common;

public class UIWorldSelect : UIWindow
{
    private Image _backGroundImage;
    private UIManager _uiManager;
    [SerializeField]private int _showingIndex = 0;

    public float Threshold;

    private LeanFingerSwipe _fingerSwipe;
    private LeanTouch _leanTouch;

    [SerializeField] private Image[] _worldImages;
    private float _distance;
    protected override void Awake()
    {
        _uiManager = UIManager.Instance;

        _backGroundImage = GetComponent<Image>();
        _backGroundImage.sprite = _worldImages[0].sprite;

        _fingerSwipe = FindObjectOfType<LeanFingerSwipe>();
        _leanTouch = FindObjectOfType<LeanTouch>();

        base.Awake();
    }

    public void SetNextWorld()
    {
        if (_showingIndex < _worldImages.Length-1)
            _backGroundImage.sprite = _worldImages[++_showingIndex].sprite;
    } 

    public void SetPrevWorld()
    {
        if (_showingIndex != 0)
            _backGroundImage.sprite = _worldImages[--_showingIndex].sprite;
    }
    public void OnSelectWorld()
    {
        UserDataInstance.Instance.CurrentWorld = _showingIndex + 1;

        var uiStage = _uiManager.GetWindow<UIStageSelect>("UIStageSelect");
        uiStage.World = _showingIndex + 1;
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

        if (swipe.y > 0)
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
