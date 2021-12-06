using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

using Lean.Touch;

public class UIScore : UIWindow
{
    public Image[] Scores;
    public GameController _gameController;

    private SwipeInteract _swipe;

    private void Start() 
    {
        Close();
        _swipe = FindObjectOfType<SwipeInteract>();        
    }

    public override void Open(bool isAnim)
    {
        base.Open();

        _swipe.enabled = false;

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
        if (score < 1 || score > 3)
            return;

        if (score == 1)
        {
            Scores[0].gameObject.SetActive(false);
            Scores[2].gameObject.SetActive(false);
        }

        else if (score == 2)
        {
            Scores[0].gameObject.SetActive(true);
            Scores[2].gameObject.SetActive(false);
        }

        else
        {
            Scores[0].gameObject.SetActive(true);
            Scores[2].gameObject.SetActive(true);
        }
    }

    public void OnClickNext()
    {
        UserDataInstance.Instance.CurrentStage++;
        GameManager.Instance.FadeOut(SceneController.activeSceneIndex);
        UnableBlockRaycast();
    }

    public void OnClickHome()
    {
        if(UserDataInstance.Instance.LastClearStage >= UserDataInstance.Instance.WorldsLastClearData[UserDataInstance.Instance.CurrentWorld-1])
        {
            GameManager.Instance.FadeOut(1);
            return;
        }

        GameManager.Instance.FadeOut("ShowProgress");
    }
}
