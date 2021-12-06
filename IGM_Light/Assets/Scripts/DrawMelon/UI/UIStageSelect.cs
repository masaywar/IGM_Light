using System.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Lean.Common;
using Lean.Touch;

public class UIStageSelect : UIWindow
{
    public int World;
    [SerializeField] private Transform _stageContainer;
    [SerializeField] private Transform[] _buttons;

    [SerializeField] private WorldSelectScrollRect _worldSelectScrollRect;

    protected override void Awake()
    {
        base.Awake();
        _worldSelectScrollRect = FindObjectOfType<WorldSelectScrollRect>();
        Close();
    }

    public override void Close()
    {
        FadeChildren();
        base.Close();
    }

    public override void Close(bool isAnim)
    {
        if(isAnim)
        { 
            foreach(var world in _worldSelectScrollRect.WorldTransforms)
            {
                world.GetComponent<Image>().DOFade(1, 1);
            }

            FadeChildren();
            _stageContainer.DOLocalMoveX(0, 1f).
            OnStepComplete(()=>Close());
        }

        else
        {
            Close();
        }
    }

    private void FadeChildren()
    {
        for(int k=0; k<_buttons.Length; k++)
        {
            for(int j=0; j< _buttons[k].childCount; j++)
            {
                var button = _buttons[k].GetChild(j);
                button.GetComponent<Image>().DOFade(0, 1);
            }
        }
    }

    public override void Open()
    {
        if(UserDataInstance.Instance.CurrentWorld == 0)
            return;

        for(int k=0; k<_buttons.Length; k++)
        {
            for(int j=0; j< _buttons[k].childCount; j++)
            {
                _buttons[k].GetChild(j).gameObject.SetActive(false);
            }
        }

        for(int k=0; k<FixedValues.STAGES; k++)
        {
            int stage = k;

            if( UserDataInstance.Instance.UserData.Worlds == UserDataInstance.Instance.CurrentWorld &&
                UserDataInstance.Instance.UserData.Stages == k)
            {
                _buttons[k].GetChild(1).gameObject.SetActive(true);
                _buttons[k].GetChild(1).GetComponent<Button>().onClick.RemoveAllListeners();
                _buttons[k].GetChild(1).GetComponent<Button>().onClick.AddListener(()=>OnClickStageButton(stage));
                continue;
            }

            if(!UserDataInstance.Instance.UserData.UserClearData[
                UserDataInstance.Instance.CurrentWorld-1].userClearData[k])
            {
                _buttons[k].GetChild(0).gameObject.SetActive(true);
                continue;
            }

            _buttons[k].GetChild(
                UserDataInstance.Instance.UserData.UserScoreData[
                    UserDataInstance.Instance.CurrentWorld-1].userScoreData[k]+1)
                .gameObject.SetActive(true);

            _buttons[k].GetChild(
                UserDataInstance.Instance.UserData.UserScoreData[
                    UserDataInstance.Instance.CurrentWorld-1].userScoreData[k]+1)
                .GetComponent<Button>().onClick.RemoveAllListeners();

            _buttons[k].GetChild(
                UserDataInstance.Instance.UserData.UserScoreData[
                    UserDataInstance.Instance.CurrentWorld-1].userScoreData[k]+1)
                .GetComponent<Button>().onClick.AddListener(()=>OnClickStageButton(stage));
        }

        base.Open();
    }

    public override void Open(bool isAnim)
    {
        Open();

        for(int k=0; k<_buttons.Length; k++)
        {
            for(int j=0; j< _buttons[k].childCount; j++)
            {
                _buttons[k].GetChild(j).GetComponent<Image>().DOFade(1, 1);
            }
        }
    }

    public void OnClickStageButton(int stage)
    {
        UserDataInstance.Instance.CurrentWorld = World;
        UserDataInstance.Instance.CurrentStage = stage+1;
        UserDataInstance.Instance.LastClearStage = UserDataInstance.Instance.WorldsLastClearData[World-1];

        GameManager.Instance.FadeOut(
            SceneController.activeSceneIndex + World
        );
    }
}
