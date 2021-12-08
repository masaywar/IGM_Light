using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chageImage : MonoBehaviour
{
    public Sprite button;
    public Sprite button2;
    public GameObject buttonobj;

    public void Change()
    {
        if(buttonobj.GetComponent<Image>().sprite != button)
        {
            //Debug.Log("enter");
            buttonobj.GetComponent<Image>().sprite = button;
            return;
        }
        if (buttonobj.GetComponent<Image>().sprite != button2)
        {
            //Debug.Log("Enter");
            buttonobj.GetComponent<Image>().sprite = button2;
            return;
        }
    }
}
