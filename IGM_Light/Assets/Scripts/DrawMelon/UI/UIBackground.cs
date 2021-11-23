using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBackground : UIWindow
{
    [SerializeField] Text _text;

    public GameObject[] stars;

    public GameController _gameController;

    public List<Image> _blockImages;

    public Image BackgroundImage;

    private void Start()
    {
        BackgroundImage = transform.Find("Background").GetComponent<Image>();

        StartCoroutine(waitForReset());
    }
    
    private void Update()
    {
        if(_gameController == null) return;

        if (!_gameController.IsSolved)
        {
            if(stars.Length != 3) return;

            int step =  _gameController.Player.Step;

            int[] standards = _gameController.Standard;
            _text.text = step.ToString();

            if(step <= _gameController.Standard[0]) //star=3
            {
                stars[1].SetActive(false);
                stars[2].SetActive(false);
                stars[0].SetActive(true);
            }
            else if(step <= _gameController.Standard[1])
            {
                stars[0].SetActive(false);
                stars[2].SetActive(false);
                stars[1].SetActive(true);
            }
            else
            {
                stars[0].SetActive(false);
                stars[1].SetActive(false);
                stars[2].SetActive(true);
            }
        }
    }

    public void ResetBackground()
    {
        BackgroundImage.sprite = _gameController
                            .GetComponent<BoardManager>()
                            ._spriteDatabase.BackgroundSprites[_gameController.Worlds-1]
                            .sprites[UserDataInstance.Instance.WorldsLastClearData[_gameController.Worlds-1]];

        int index =0;
        while(index < _blockImages.Count)
        {
            foreach(var row in _gameController.TargetTable)
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
        while(!_gameController)
            yield return new WaitForSeconds(0.02f);

        if(!_gameController.isHack)
            ResetBackground();
    }

    public void OnClickReset()
    {
        _gameController.ResetGame();
    }

    public void OnClickPause()
    {
        //TODO pause 구현
        GameManager.Instance.FadeOut(
            SceneController.activeSceneIndex-1
        );
    }
}
