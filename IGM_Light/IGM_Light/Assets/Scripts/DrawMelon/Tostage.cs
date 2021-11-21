using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tostage : MonoBehaviour
{
    public void stageSelect()
    {
        SceneManager.LoadScene("stage_select");
    }
}
