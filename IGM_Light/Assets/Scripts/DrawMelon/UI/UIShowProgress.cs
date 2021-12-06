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

    public void ShowProgress()
    {
        _lastImage.sprite = GameManager.Instance.SpriteDatabase
                            .WorldsSprites[UserDataInstance.Instance.CurrentWorld-1]
                            .sprites[UserDataInstance.Instance.LastClearStage];

        _currentImage.sprite = GameManager.Instance.SpriteDatabase
                                .WorldsSprites[UserDataInstance.Instance.CurrentWorld-1]
                                .sprites[UserDataInstance.Instance.CurrentStage];

        _lastImage.DOFade(0, 5);
        _currentImage.DOFade(1, 5)
        .OnComplete(()=>GameManager.Instance.FadeOut(1));
    }
}
