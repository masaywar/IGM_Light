using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBackground : UIWindow
{
    [SerializeField] Text _text;

    public GameController _gameController;
    public GameObject[] stars;

    private void Update()
    {
        if(_gameController == null) return;

        if (!_gameController.IsSolved)
        {
            int step =  _gameController.Player.Step;

            int[] standards = _gameController.Standard;
            string standard = step <= standards[0] ? standards[0].ToString() : standards[1].ToString();

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
