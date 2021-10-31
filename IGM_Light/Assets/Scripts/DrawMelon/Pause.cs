using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //안드로이드 백버튼, esc키 눌릴때 종료
        {
            Quit();
        }

    }

    public void Quit()
    {
        //Application.Quite();
    }

    public void GamePause()
    {
        Time.timeScale = 0;
    }
}
