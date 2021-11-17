using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBackground : UIWindow
{
    [SerializeField] Text _text;

    public GameController _gameController;

    private void Update()
    {
        if(_gameController == null) return;

        if (!_gameController.IsSolved)
        {
            int step =  _gameController.Player.Step;

            int[] standards = _gameController.Standard;
            string standard = step <= standards[0] ? standards[0].ToString() : standards[1].ToString();

            _text.text = step.ToString();
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
