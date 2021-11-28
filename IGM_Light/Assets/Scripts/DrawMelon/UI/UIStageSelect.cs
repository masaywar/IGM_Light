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

    protected override void Awake()
    {
        base.Awake();
        Close();
    }

    public override void Close()
    {
        _stageContainer.localPosition = Vector3.zero;
        base.Close();
    }

    public override void Close(bool isAnim)
    {
        if(isAnim)
        {   
            _stageContainer.DOLocalMoveX(0, 0.5f).
            OnStepComplete(()=>Close());
        }

        else
        {
            Close();
        }
    }

    public override void Open()
    {
        base.Open();

        if(UserDataInstance.Instance.CurrentWorld == 0)
            return;

        for(int k=0; k<FixedValues.STAGES; k++)
        {
            int stage = k;

            if( UserDataInstance.Instance.UserData.Worlds == UserDataInstance.Instance.CurrentWorld &&
                UserDataInstance.Instance.UserData.Stages == k)
            {
                _buttons[k].GetChild(1).gameObject.SetActive(true);
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
                .GetComponent<Button>().onClick.AddListener(()=>OnClickStageButton(stage));
        }
    }

    public override void Open(bool isAnim)
    {
        Open();
        
        if (isAnim) 
            _stageContainer.DOMoveX(0, 0.5f);
    }

    public void OnClickStageButton(int stage)
    {
        UserDataInstance.Instance.CurrentWorld = World;
        UserDataInstance.Instance.CurrentStage = stage+1;

        GameManager.Instance.FadeOut(
            SceneController.activeSceneIndex + World
        );
    }
}
