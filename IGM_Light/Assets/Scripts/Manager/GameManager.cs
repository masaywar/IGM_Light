using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private int _sceneIndex;    

    public List<string> Worlds;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        TryInitialize();
    }

    private void TryInitialize()
    {
        _sceneIndex = SceneManager.GetActiveScene().buildIndex;

        print(_sceneIndex);
    }

    private void Update()
    {
        OnSceneChanged();
    }

    private void OnSceneChanged()
    {
        switch(_sceneIndex)
        {
            case 0:
                LoadScene(1, 2, true);
                break;

            default:
                break;
        }
    }


    private IEnumerator FadeOut(float time, float threshHold)
    {
        while(time <= threshHold)
        {
            time += 0.2f;
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void LoadScene(int index)
    {
        _sceneIndex = index;
        SceneManager.LoadScene(_sceneIndex);
        OnSceneChanged();
    } 

    public void LoadScene(int index, float threshHold, bool fadeOut)
    {
        float time = 0;

        Coroutine coroutine = StartCoroutine(FadeOut(time, threshHold));
        
        LoadScene(index);
    }
}
