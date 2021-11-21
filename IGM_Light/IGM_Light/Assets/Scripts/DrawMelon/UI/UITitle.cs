using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class UITitle : UIWindow 
{
    [SerializeField] private RectTransform _title;
    [SerializeField] private GameObject _startIndicator;

    private void Start()
    {
        _startIndicator.transform.DOPunchScale(
            new Vector3(.3f, .3f, .3f),
            1, 1, 0.5f
        ).SetLoops(-1);
    }
}