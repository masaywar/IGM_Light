using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIScore : UIWindow
{
    public Image Successimg;
    public Image[] Scores;
    public GameController gameController;

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

        
        //Invoke("showSuccess", 0.1f);
        Invoke("showCenter", 0.5f);

        if (score == 2) //가운데>왼쪽
        {
            Invoke("showLeft", 1f);
        }

        else if(score == 3)//가운데>왼쪽>오른쪽
        {
            Invoke("showLeft", 1f);
            Invoke("showRight", 1.5f);
        }
    }

    public void showCenter()
    {
        Scores[0].color = new Color(Scores[0].color.r, Scores[0].color.g, Scores[0].color.b, 0f);//.SetActive(false);
        Scores[1].color = new Color(Scores[1].color.r, Scores[1].color.g, Scores[1].color.b, 1f);
        Scores[2].color = new Color(Scores[2].color.r, Scores[2].color.g, Scores[2].color.b, 0f);//.gameObject.color.alpha = 0;//.SetActive(false);
    }
    public void showLeft()
    {
        Scores[0].color = new Color(Scores[0].color.r, Scores[0].color.g, Scores[0].color.b, 1f);//.SetActive(false);
    }

    public void showRight()
    {
        Scores[2].color = new Color(Scores[2].color.r, Scores[2].color.g, Scores[2].color.b, 1f);//.SetActive(true);
    }

    public void ShowSuccess()
    {
        Successimg.color = new Color(Successimg.color.r, Successimg.color.g, Successimg.color.b, 1f);//.SetActive(true);
    }

    public void OnClickNext()
    {
        UserDataInstance.Instance.CurrentStage++;
        if(UserDataInstance.Instance.CurrentStage > FixedValues.STAGES)
        {
            UserDataInstance.Instance.CurrentStage--;
            OnClickHome();
            return;
        }

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
