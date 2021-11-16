using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stage_select : MonoBehaviour
{
    [SerializeField] private UserDataInstance data;
    public Button[] Progress;
    public int w1_clear;
    public int w2_clear;
    public int w3_clear;
    public int w4_clear;
    public int[] w1_success;
    public int[] w2_success;
    public int[] w3_success;
    public int[] w4_success;

    // Start is called before the first frame update
    void Start()
    {
        //ShowProgress(0);

        for (int i = 0; i < data.UserData.UserClearData.Length; i++)
        {
            if (i < 9)
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

        for(int j = 0; j < data.UserData.UserScoreData.Length; j++)
        {
            if (j < 9)
            {
               data.UserData.UserScoreData[j] = w1_success[j];
            }
            else if (j < 18)
            {
                data.UserData.UserScoreData[j] = w2_success[j-9];
            }
            else if (j < 27)
            {
                data.UserData.UserScoreData[j] = w3_success[j-18];
            }
            else if (j < 36)
            {
                data.UserData.UserScoreData[j] = w4_success[j-27];
            }
        }
        ShowProgress();
        //ShowScore();
    }

    public void ShowProgress()  //clear 한 stage 
    {
        Debug.Log(w1_clear);
        switch (w1_clear)
        {
            case 0:
                break;
            case 1:
                Progress[0].gameObject.SetActive(false);
                ShowScore();
                break;
            case 2:
                for (int j = 0; j < 6; j+=5)
                    Progress[j].gameObject.SetActive(false);
                ShowScore();
                break;
            case 3:
                for (int j = 0; j < 11; j += 5)
                    Progress[j].gameObject.SetActive(false);
                ShowScore();
                break;
            case 4:
                for (int j = 0; j < 16; j += 5)
                    Progress[j].gameObject.SetActive(false);
                ShowScore();
                break;
            case 5:
                for (int j = 0; j < 21; j += 5)
                    Progress[j].gameObject.SetActive(false);
                ShowScore();
                break;
            case 6:
                for (int j = 0; j < 26; j += 5)
                    Progress[j].gameObject.SetActive(false);
                ShowScore();
                break;
            case 7:
                for (int j = 0; j < 31; j += 5)
                    Progress[j].gameObject.SetActive(false);
                ShowScore();
                break;
            case 8:
                for (int j = 0; j < 36; j += 5)
                    Progress[j].gameObject.SetActive(false);
                ShowScore();
                break;
            case 9:
                for (int j = 0; j < 41; j += 5)
                    Progress[j].gameObject.SetActive(false);
                ShowScore();
                break;
        }
    }

    public void ShowScore()  //success score
    {
       for(int i=0;i<w1_success.Length;i++)
        {
            switch (w1_success[i])
            {
                case 3: //1-n은 3점
                    if (i == 0)  //1-1은 3점
                    {
                        for (int j = 4; j < 1; j--)
                            Progress[j].gameObject.SetActive(false);
                    }
                    if (i == 1) //1-2은 3점
                    {
                        for (int j = 9; j < 6; j--)
                            Progress[j].gameObject.SetActive(false);
                    }
                    if (i == 2)
                    {
                        for (int j = 14; j < 11; j--)
                            Progress[j].gameObject.SetActive(false);
                    }
                    if (i == 3)
                    {
                        for (int j = 19; j < 16; j--)
                            Progress[j].gameObject.SetActive(false);
                    }
                    if (i == 4)
                    {
                        for (int j = 24; j < 21; j--)
                            Progress[j].gameObject.SetActive(false);
                    }
                    if (i == 5)
                    {
                        for (int j = 29; j < 26; j--)
                            Progress[j].gameObject.SetActive(false);
                    }
                    if (i == 6)
                    {
                        for (int j = 34; j < 31; j--)
                            Progress[j].gameObject.SetActive(false);
                    }
                    if (i == 7)
                    {
                        for (int j = 39; j < 36; j--)
                            Progress[j].gameObject.SetActive(false);
                    }
                    if (i == 8)
                    {
                        for (int j = 44; j < 41; j--)
                            Progress[j].gameObject.SetActive(false);
                    }
                    break;
                case 2: //1-n은 2점
                    if (i == 0)  //1-1은 2점
                    {
                        for (int j = 4; j < 2; j--)
                            Progress[j].gameObject.SetActive(false);
                    }
                    if (i == 1) //1-2은 2점
                    {
                        for (int j = 9; j < 7; j--)
                            Progress[j].gameObject.SetActive(false);
                    }
                    if (i == 2)
                    {
                        for (int j = 14; j < 12; j--)
                            Progress[j].gameObject.SetActive(false);
                    }
                    if (i == 3)
                    {
                        for (int j = 19; j < 17; j--)
                            Progress[j].gameObject.SetActive(false);
                    }
                    if (i == 4)
                    {
                        for (int j = 24; j < 22; j--)
                            Progress[j].gameObject.SetActive(false);
                    }
                    if (i == 5)
                    {
                        for (int j = 29; j < 27; j--)
                            Progress[j].gameObject.SetActive(false);
                    }
                    if (i == 6)
                    {
                        for (int j = 34; j < 32; j--)
                            Progress[j].gameObject.SetActive(false);
                    }
                    if (i == 7)
                    {
                        for (int j = 39; j < 37; j--)
                            Progress[j].gameObject.SetActive(false);
                    }
                    if (i == 8)
                    {
                        for (int j = 44; j < 42; j--)
                            Progress[j].gameObject.SetActive(false);
                    }
                    break;
                case 1: //1-n은 1점
                    if (i == 0)  //1-1은 1점
                    {
                       Progress[4].gameObject.SetActive(false);
                    }
                    if (i == 1)  
                    {
                        Progress[9].gameObject.SetActive(false);
                    }
                    if (i == 2)  
                    {
                        Progress[14].gameObject.SetActive(false);
                    }
                    if (i == 3)  
                    {
                        Progress[19].gameObject.SetActive(false);
                    }
                    if (i == 4)  
                    {
                        Progress[24].gameObject.SetActive(false);
                    }
                    if (i == 5)  
                    {
                        Progress[29].gameObject.SetActive(false);
                    }
                    if (i == 6)
                    {
                        Progress[34].gameObject.SetActive(false);
                    }
                    if (i == 7)
                    {
                        Progress[39].gameObject.SetActive(false);
                    }
                    if (i == 8)
                    {
                        Progress[44].gameObject.SetActive(false);
                    }
                    break;
            }
        }
    }
}
