using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBackground : UIWindow
{
    [SerializeField] Text _text;

    public Image[] stars;

    public GameController gameController;

    public List<Image> _blockImages;

    public Image BackgroundImage;

    private void Start()
    {
        StartCoroutine(waitForReset());
    }
    
    private void Update()
    {
        if(gameController == null) return;

        if (!gameController.IsSolved)
        {
            if(stars.Length != 3) return;

            int step =  gameController.Player.Step;

            int[] standards = gameController.Standard;
            _text.text = step.ToString();

            if(step <= gameController.Standard[0]) //star=3
            {
                //stars[1].gameObject.SetActive(false);
                //stars[2].gameObject.SetActive(false);
                //stars[0].gameObject.SetActive(true);
            }
            else if(step <= gameController.Standard[1])  //star2
            {
                stars[0].gameObject.SetActive(false);
                //stars[2].gameObject.SetActive(false);
                //stars[1].gameObject.SetActive(true);
            }
            else  //star1
            {
                stars[0].gameObject.SetActive(false);
                stars[1].gameObject.SetActive(false);
                //stars[2].gameObject.SetActive(true);
            }
        }
    }

    public void ResetBackground()
    {
        int lastData = UserDataInstance.Instance.WorldsLastClearData[gameController.Worlds-1];

        lastData = lastData == FixedValues.STAGES ? lastData - 1 : lastData;

        BackgroundImage.sprite = GameManager.Instance
                            .SpriteDatabase.BackgroundSprites[gameController.Worlds-1]
                            .sprites[lastData];

        int index =0;
        while(index < _blockImages.Count)
        {
            foreach(var row in gameController.TargetTable)
            {
                foreach(var block in row.Blocks)
                {
                    _blockImages[index].gameObject.SetActive(true);
                    _blockImages[index].sprite = block.ShowingBlock;
                    _blockImages[index].SetNativeSize();
                    index++;
                }
            }

            break;
        }
    }

    private IEnumerator waitForReset()
    {
        while(!gameController)
            yield return new WaitForSeconds(0.02f);

        if(!gameController.isHack)
            ResetBackground();
    }

    public void OnClickReset()
    {
        gameController.ResetGame();
    }

    public void OnClickPause()
    {
        //TODO pause 구현
        GameManager.Instance.FadeOut(
            SceneController.activeSceneIndex-1
        );
    }
}
