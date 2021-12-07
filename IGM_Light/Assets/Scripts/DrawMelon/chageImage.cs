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
        this.gameObject.GetComponent<Image>().sprite = button;
    }
    public void Origin()
    {
        this.gameObject.GetComponent<Image>().sprite = button2;
    }
}
