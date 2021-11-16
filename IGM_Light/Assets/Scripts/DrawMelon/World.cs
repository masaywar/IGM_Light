using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class World : MonoBehaviour
{
    public Image[] Progress;
    [SerializeField] private UserDataInstance data;
    public int w1_clear;
    public int w2_clear;
    public int w3_clear;
    public int w4_clear;

    // Start is called before the first frame update
    void Start()
    { 
        for (int i = 0; i<data.UserData.UserClearData.Length; i++)
        {
            if (i< 9)
            {
                if (data.UserData.UserClearData[i])
                    w1_clear++;
            }
            else if (i < 18)
            {
            if (data.UserData.UserClearData[i])
                w2_clear++;
            }
            else if (i < 27)
            {
                if (data.UserData.UserClearData[i])
                    w3_clear++;
            }
            else if (i < 36)
            {
                if (data.UserData.UserClearData[i])
                     w4_clear++;
            }
        }   
         ShowProgress(w1_clear);
    }

    public void ShowProgress(int success)  //success는 한 stage 개수
    {
        Color color = Progress[1].GetComponent<Image>().color;
        switch (success)
        {
            case 0:
                color.a = 1f;
                Progress[0].GetComponent<Image>().color = color;
                color.a = 0f;
                Progress[1].GetComponent<Image>().color = color;
                Progress[2].GetComponent<Image>().color = color;
                Progress[3].GetComponent<Image>().color = color;
                Progress[4].GetComponent<Image>().color = color;
                Progress[5].GetComponent<Image>().color = color;
                Progress[6].GetComponent<Image>().color = color;
                Progress[7].GetComponent<Image>().color = color;
                Progress[8].GetComponent<Image>().color = color;
                Progress[9].GetComponent<Image>().color = color;
                break;
            case 1:
                color.a = 1f;
                Progress[1].GetComponent<Image>().color = color;
                color.a = 0f;
                Progress[0].GetComponent<Image>().color = color;
                Progress[2].GetComponent<Image>().color = color;
                Progress[3].GetComponent<Image>().color = color;
                Progress[4].GetComponent<Image>().color = color;
                Progress[5].GetComponent<Image>().color = color;
                Progress[6].GetComponent<Image>().color = color;
                Progress[7].GetComponent<Image>().color = color;
                Progress[8].GetComponent<Image>().color = color;
                Progress[9].GetComponent<Image>().color = color;
                break;
            case 2:
                color.a = 1f;
                Progress[2].GetComponent<Image>().color = color;
                color.a = 0f;
                Progress[0].GetComponent<Image>().color = color;
                Progress[1].GetComponent<Image>().color = color;
                Progress[3].GetComponent<Image>().color = color;
                Progress[4].GetComponent<Image>().color = color;
                Progress[5].GetComponent<Image>().color = color;
                Progress[6].GetComponent<Image>().color = color;
                Progress[7].GetComponent<Image>().color = color;
                Progress[8].GetComponent<Image>().color = color;
                Progress[9].GetComponent<Image>().color = color;
                break;
            case 3:
                color.a = 1f;
                Progress[3].GetComponent<Image>().color = color;
                color.a = 0f;
                Progress[0].GetComponent<Image>().color = color;
                Progress[1].GetComponent<Image>().color = color;
                Progress[2].GetComponent<Image>().color = color;
                Progress[4].GetComponent<Image>().color = color;
                Progress[5].GetComponent<Image>().color = color;
                Progress[6].GetComponent<Image>().color = color;
                Progress[7].GetComponent<Image>().color = color;
                Progress[8].GetComponent<Image>().color = color;
                Progress[9].GetComponent<Image>().color = color;
                break;
            case 4:
                color.a = 1f;
                Progress[4].GetComponent<Image>().color = color;
                color.a = 0f;
                Progress[0].GetComponent<Image>().color = color;
                Progress[1].GetComponent<Image>().color = color;
                Progress[2].GetComponent<Image>().color = color;
                Progress[3].GetComponent<Image>().color = color;
                Progress[5].GetComponent<Image>().color = color;
                Progress[6].GetComponent<Image>().color = color;
                Progress[7].GetComponent<Image>().color = color;
                Progress[8].GetComponent<Image>().color = color;
                Progress[9].GetComponent<Image>().color = color;
                break;
            case 5:
                color.a = 1f;
                Progress[5].GetComponent<Image>().color = color;
                color.a = 0f;
                Progress[0].GetComponent<Image>().color = color;
                Progress[1].GetComponent<Image>().color = color;
                Progress[2].GetComponent<Image>().color = color;
                Progress[3].GetComponent<Image>().color = color;
                Progress[4].GetComponent<Image>().color = color;
                Progress[6].GetComponent<Image>().color = color;
                Progress[7].GetComponent<Image>().color = color;
                Progress[8].GetComponent<Image>().color = color;
                Progress[9].GetComponent<Image>().color = color;
                break;
            case 6:
                color.a = 1f;
                Progress[6].GetComponent<Image>().color = color;
                color.a = 0f;
                Progress[0].GetComponent<Image>().color = color;
                Progress[1].GetComponent<Image>().color = color;
                Progress[2].GetComponent<Image>().color = color;
                Progress[3].GetComponent<Image>().color = color;
                Progress[4].GetComponent<Image>().color = color;
                Progress[5].GetComponent<Image>().color = color;
                Progress[7].GetComponent<Image>().color = color;
                Progress[8].GetComponent<Image>().color = color;
                Progress[9].GetComponent<Image>().color = color;
                break;
            case 7:
                color.a = 1f;
                Progress[7].GetComponent<Image>().color = color;
                color.a = 0f;
                Progress[0].GetComponent<Image>().color = color;
                Progress[1].GetComponent<Image>().color = color;
                Progress[2].GetComponent<Image>().color = color;
                Progress[3].GetComponent<Image>().color = color;
                Progress[4].GetComponent<Image>().color = color;
                Progress[5].GetComponent<Image>().color = color;
                Progress[6].GetComponent<Image>().color = color;
                Progress[8].GetComponent<Image>().color = color;
                Progress[9].GetComponent<Image>().color = color;
                break;
            case 8:
                color.a = 1f;
                Progress[8].GetComponent<Image>().color = color;
                color.a = 0f;
                Progress[0].GetComponent<Image>().color = color;
                Progress[1].GetComponent<Image>().color = color;
                Progress[2].GetComponent<Image>().color = color;
                Progress[3].GetComponent<Image>().color = color;
                Progress[4].GetComponent<Image>().color = color;
                Progress[5].GetComponent<Image>().color = color;
                Progress[6].GetComponent<Image>().color = color;
                Progress[7].GetComponent<Image>().color = color;
                Progress[9].GetComponent<Image>().color = color;
                break;
            case 9:
                color.a = 1f;
                Progress[9].GetComponent<Image>().color = color;
                color.a = 0f;
                Progress[0].GetComponent<Image>().color = color;
                Progress[1].GetComponent<Image>().color = color;
                Progress[2].GetComponent<Image>().color = color;
                Progress[3].GetComponent<Image>().color = color;
                Progress[4].GetComponent<Image>().color = color;
                Progress[5].GetComponent<Image>().color = color;
                Progress[6].GetComponent<Image>().color = color;
                Progress[7].GetComponent<Image>().color = color;
                Progress[8].GetComponent<Image>().color = color;
                break;
        }

    }
}
