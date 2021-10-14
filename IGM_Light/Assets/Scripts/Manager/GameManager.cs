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
    }

    private void OnEachScenes()
    {
        switch(_sceneIndex)
        {
            default:
                break;
        }
    }

    private IEnumerator FadeOut(float time, float threshHold)
    {
        yield return null;
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(Worlds[index]);
    } 

    public void LoadScene(int index, float threshHold, bool fadeOut)
    {
        float time = 0;

        Coroutine coroutine = StartCoroutine(FadeOut(time, threshHold));
        while(time <= threshHold)
        {
            continue;
        }

        LoadScene(index);
    }
}
