using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chageImage : MonoBehaviour
{
    public Sprite button;
    public Sprite button2;

    public void Change()
    {
        if(GetComponent<Image>().sprite != button)
        {
            //Debug.Log("enter");
            GetComponent<Image>().sprite = button;
            return;
        }
        if (GetComponent<Image>().sprite != button2)
        {
            //Debug.Log("Enter");
            GetComponent<Image>().sprite = button2;
            return;
        }
    }
}
