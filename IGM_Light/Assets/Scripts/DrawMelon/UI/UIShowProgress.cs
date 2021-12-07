using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIShowProgress : UIWindow
{
    public Image _lastImage;
    public Image _currentImage;

    public override void Open()
    {
        base.Open();
        ShowProgress();
    }

    public void Open(int last, int current)
    {
        base.Open();
        ShowProgress(last, current);
    }

    public void ShowProgress()
    {
        int currentWorld = UserDataInstance.Instance.CurrentWorld;

        _lastImage.sprite = GameManager.Instance.SpriteDatabase
                            .WorldsSprites[currentWorld-1]
                            .sprites[UserDataInstance.Instance.LastClearStage];

        _currentImage.sprite = GameManager.Instance.SpriteDatabase
                            .WorldsSprites[currentWorld-1]
                            .sprites[UserDataInstance.Instance.WorldsLastClearData[currentWorld-1]];

        _lastImage.DOFade(0, 5);
        _currentImage.DOFade(1, 5)
        .OnComplete(()=>GameManager.Instance.FadeOut(1));
    }

    public void ShowProgress(int last, int current)
    {
        _lastImage.sprite = GameManager.Instance.SpriteDatabase
                            .WorldsSprites[UserDataInstance.Instance.CurrentWorld-1]
                            .sprites[last];

        _currentImage.sprite = GameManager.Instance.SpriteDatabase
                            .WorldsSprites[UserDataInstance.Instance.CurrentWorld-1]
                            .sprites[current];

        _lastImage.DOFade(0, 5);
        _currentImage.DOFade(1, 5)
        .OnComplete(()=>GameManager.Instance.FadeOut(1));             
    }
}
