using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Image _fadeOutPanel;
    [SerializeField] private Image _fadeInPanel;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(_fadeInPanel.transform.parent.gameObject);
        
        StartCoroutine(fadeIn());
    }

    private Coroutine _fadeOutCoroutine = null;

    private void Update()
    {
        switch(SceneController.activeSceneIndex)
        {
            case 0: // Title
            #if UNITY_EDITOR
                if(Input.anyKeyDown)
                {
                    FadeOut();
                }
            #else
                if(Input.touchCount > 0)
                {
                    FadeOut();
                }
                #endif
                break;
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            default:
                break;
        }
    }

    private void OnSceneChange()
    {
        _fadeInPanel.color = new Color(0, 0, 0, 0);
        _fadeOutPanel.color = new Color(0, 0, 0, 1);

        _fadeOutCoroutine = null;
    }

    public void FadeIn()
    {

    }

    public void FadeOut()
    {
        if(_fadeOutCoroutine == null)
            _fadeOutCoroutine = StartCoroutine(fadeOut());
    }

    public void FadeOut(int buildIndex)
    {
        if(_fadeOutCoroutine == null)
            _fadeOutCoroutine= StartCoroutine(fadeOut(buildIndex));
    }

    public void FadeOut(string sceneName)
    {
        if(_fadeOutCoroutine == null)
            _fadeOutCoroutine = StartCoroutine(fadeOut(sceneName));
    }

    private IEnumerator fadeIn()
    {
        while(_fadeInPanel.color.a >= 0)
        {
            _fadeInPanel.color -= new Color(0, 0, 0, 0.05f);
            yield return new WaitForSeconds(0.02f);
        }
    }

    private IEnumerator fadeOut()
    {
        while(_fadeOutPanel.color.a < 1)
        {
            _fadeOutPanel.color += new Color(0, 0, 0, 0.05f);
            yield return new WaitForSeconds(0.02f);
        }
        
        print("asdf");
        SceneController.LoadNextScene();
    }

    private IEnumerator fadeOut(int index)
    {
        while(_fadeOutPanel.color.a < 1)
        {
            _fadeOutPanel.color += new Color(0, 0, 0, 0.05f);
            yield return new WaitForSeconds(0.02f);
        }

        SceneController.LoadSceneByIndex(index);
    }

    private IEnumerator fadeOut(string sceneName)
    {
        while(_fadeOutPanel.color.a < 1)
        {
            _fadeOutPanel.color += new Color(0, 0, 0, 0.05f);
            yield return new WaitForSeconds(0.02f);
        }

        SceneController.LoadSceneByName(sceneName);
    }
}
