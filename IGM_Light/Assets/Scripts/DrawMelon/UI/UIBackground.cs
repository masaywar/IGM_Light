using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBackground : UIWindow
{
    [SerializeField] Text _text;

    private void Update()
    {
       /* if (!UIManager.Instance.Controller.IsSolved)
        {
            //int step =  UIManager.instance.Controller.Player.Step;

           // int[] standards = GameUIManager.instance.Controller.Standard;
            //string standard = step <= standards[0] ? standards[0].ToString() : standards[1].ToString();

           // _text.text = step.ToString();
        }*/
    } 
}
