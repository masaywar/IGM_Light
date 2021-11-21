using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chageImage : MonoBehaviour
{
    public Sprite button;

   public void Change()
    {
        this.gameObject.GetComponent<Image>().sprite = button;
    }
}
