using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stage_select : UIWindow
{ 
    public Image[] s_Progress;
    // Start is called before the first frame update
    void Start()
    {
        //Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public void ShowProgress(int success)  //success는 한 stage 개수
    {
        switch (success)
        {
            case 0:
                Progress[0].gameObject.SetActive(true);
                break;
            case 1:
                Progress[1].gameObject.SetActive(true);
                break;
            case 2:
                Progress[2].gameObject.SetActive(true);
                break;
            case 3:
                Progress[3].gameObject.SetActive(true);
                break;
            case 4:
                Progress[4].gameObject.SetActive(true);
                break;
            case 5:
                Progress[5].gameObject.SetActive(true);
                break;
            case 6:
                Progress[6].gameObject.SetActive(true);
                break;
            case 7:
                Progress[7].gameObject.SetActive(true);
                break;
            case 8:
                Progress[8].gameObject.SetActive(true);
                break;
            case 9:
                Progress[9].gameObject.SetActive(true);
                break;
        }

    }*/
}
