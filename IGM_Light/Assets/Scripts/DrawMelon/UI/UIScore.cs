using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIScore : UIWindow
{
    public Image[] Scores;
    [SerializeField] private GameController _gameController;

    private void Start() 
    {
        Close();
    }

    public override void Open(bool isAnim)
    {
        base.Open();

        if(isAnim)        
            transform.DOScale(new Vector3(1, 1, 1), 1f);
    }

    public override void Close(bool isAnim)
    {
        if (isAnim)
            transform.DOScale(new Vector3(0.3f, 1, 1), 1f).OnStepComplete(()=>base.Close());
    }

    public override void Close()
    {
        transform.localScale = new Vector3(0.3f, 1, 1);
        base.Close();
    }

    public override void Open()
    {
        transform.localScale = new Vector3(1, 1, 1);
        base.Open();
    }

    public void ShowScore(int score)
    {
        if (score == 1)
        {
            Scores[0].gameObject.SetActive(false);
            Scores[2].gameObject.SetActive(false);
        }

        if (score == 2)
        {
            Scores[0].gameObject.SetActive(true);
            Scores[2].gameObject.SetActive(false);
        }

        if (score == 3)
        {
            Scores[0].gameObject.SetActive(true);
            Scores[2].gameObject.SetActive(true);
        }
            
    }
}
